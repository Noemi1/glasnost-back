using AutoMapper;
using glasnost_back.Entities;
using glasnost_back.Helpers;
using glasnost_back.Models.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;
using System.Security.Cryptography;

namespace glasnost_back.Services
{
    public interface IAccountService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        void Register(RegisterRequest model, string origin);
        void VerifyEmail(string token);
        void ForgotPassword(ForgotPasswordRequest model, string origin);
        void ValidateResetToken(ValidateResetTokenRequest model);
        void ResetPassword(ResetPasswordRequest model);
    }

    public class AccountService : IAccountService
    {
        private readonly ModelDBContext _db;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public AccountService(
            ModelDBContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IEmailService emailService)
        {
            _db = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var account = _db.Account.SingleOrDefault(x => x.Email == model.Email);

            if (account == null || !BC.Verify(model.Password, account.PasswordHash))
                throw new Exception("E-mail ou senha estão incorretos.");

            if (!account.IsVerified)
                throw new Exception("Sua conta está desativada. Verifique seu email para ativar sua conta.");

            if (account.DataDesativado.HasValue)
                throw new Exception("Sua conta está desativada. Entre em contato com o administrador.");

            // remove old refresh tokens from account
            removeOldRefreshTokens(account);

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = generateJwtToken(account);
            RefreshToken refreshToken = generateRefreshToken(ipAddress);
            refreshToken.Account_Id = account.Id;
            account.RefreshToken.Add(refreshToken);

            // save changes to db
            _db.Update(account);
            _db.SaveChanges();

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;
            return response;
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var (refreshToken, account) = getRefreshToken(token);

            // replace old refresh token with a new one and save
            var newRefreshToken = generateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            account.RefreshToken.Add(newRefreshToken);

            removeOldRefreshTokens(account);

            _db.Update(account);
            _db.SaveChanges();

            // generate new jwt
            var jwtToken = generateJwtToken(account);

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;
            return response;
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var (refreshToken, account) = getRefreshToken(token);

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            _db.RefreshToken.Update(refreshToken);
            _db.SaveChanges();
        }

        public void Register(RegisterRequest model, string origin)
        {
            if (_db.Account.Any(x => x.Email == model.Email))
            {
                //sendAlreadyRegisteredEmail(model.Email, origin);
                throw new AppException("Esse email já está cadastrado! Se você não lembra sua senha clique em 'esqueci minha senha' na página de login. ");
            }

            Account account = new Account()
            {
                Email = model.Email,
                Name = model.Name,
                TelefoneCelular = model.TelefoneCelular,
                AcceptTerms = model.AcceptTerms,
                DataDesativado = DateTime.Now,
                Verified = null,
            };

            // first registered account is an admin
            var isFirstAccount = _db.Account.Count() == 0;
            account.PerfilAcesso_Id = isFirstAccount ? (int)AccountRole.Master : (int)AccountRole.ComplianceOfficer;
            account.Created = DateTime.UtcNow;
            account.VerificationToken = randomTokenString();

            account.PasswordHash = BC.HashPassword(model.Password);

            _db.Account.Add(account);
            _db.SaveChanges();

            sendVerificationEmail(account, origin);
        }


        public void VerifyEmail(string token)
        {
            var account = _db.Account
                .SingleOrDefault(x => x.VerificationToken == token);

            if (account == null)
                throw new AppException("Verificação falhou.");

            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            _db.Account.Update(account);
            _db.SaveChanges();
        }

        public void ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var account = _db.Account.SingleOrDefault(x => x.Email == model.Email);

            // always return ok response to prevent email enumeration
            if (account == null) return;

            // create reset token that expires after 1 day
            account.ResetToken = randomTokenString();
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

            _db.Account.Update(account);
            _db.SaveChanges();

            // send email
            sendPasswordResetEmail(account, origin);
        }

        public void ValidateResetToken(ValidateResetTokenRequest model)
        {
            var account = _db.Account.SingleOrDefault(x =>
                x.ResetToken == model.Token &&
                x.ResetTokenExpires > DateTime.UtcNow);

            if (account == null)
                throw new AppException("Invalid token");
        }

        public void ResetPassword(ResetPasswordRequest model)
        {
            var account = _db.Account.SingleOrDefault(x =>
                x.ResetToken == model.Token &&
                x.ResetTokenExpires > DateTime.UtcNow);

            if (account == null)
                throw new AppException("Token inválido");

            // update password and remove reset token
            account.PasswordHash = BC.HashPassword(model.Password);
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;

            _db.Account.Update(account);
            _db.SaveChanges();
        }


        // helper methods
        public (RefreshToken, Account) getRefreshToken(string token)
        {
            var accounts = _db.Account
                .Include(x => x.RefreshToken)
                .Include(x => x.PerfilAcesso)
                .ToList();
            var account = accounts.SingleOrDefault(u => u.RefreshToken.Any(t => t.Token == token));
            if (account == null)
                throw new AppException("Token inválido.");
            var refreshToken = account.RefreshToken.Single(x => x.Token == token);
            if (!refreshToken.IsActive)
                throw new AppException("Token inválido.");

            return (refreshToken, account);
        }

        public string generateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var now = DateTime.Now.ToUniversalTime();
            var tokenDate = DateTimeOffset.FromUnixTimeSeconds(1680366360).UtcDateTime;


            return tokenHandler.WriteToken(token);
        }

        public RefreshToken generateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = randomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        public void removeOldRefreshTokens(Account account)
        {
            account.RefreshToken = account.RefreshToken.Where(x => x.IsActive && x.Created.AddDays(_appSettings.RefreshTokenTTL) > DateTime.UtcNow).ToList();
        }

        public string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        public void sendVerificationEmailRegisterAccounts(Account account, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/Planner/account/verify-email?token={account.VerificationToken}";
                message = $@"<p>Foi realizado um cadastro no Planner com o seu e-mail.</p>
                             <p>Por favor, clique no link abaixo para verificar sua conta:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>
                            ";
            }
            else
            {
                message = $@"<p>Por favor, utilize o token abaixo para verificar sua conta com a seguinte rota da api<code>/accounts/verify-email</code>:</p>
                             <p><code>{account.VerificationToken}</code></p>";
            }
            _emailService.Send(
                to: account.Email,
                subject: "Planner - Verificar Email",
                html: $@"<h4>Verificação de e-mail</h4>
                         <p>Obrigado pelo registro!</p>
                         {message}
                        <br>
                        <br>
                        <br>
                        <p><small> Aviso: Esta mensagem automatica é destinada exclusivamente para a(s) pessoa(s) a quem é dirigida, podendo conter informação confidencial e legalmente protegida. Se você não for destinatário desta mensagem, desde já fica notificado de abster-se a divulgar, copiar, distribuir, examinar ou, de qualquer forma, utilizar a informação contida nesta mensagem, por ser ilegal. Caso você tenha recebido esta mensagem por engano, pedimos que responda essa mensagem informando o acontecido.</small></p>"
            );
        }

        public void sendVerificationEmail(Account account, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/Planner/account/verify-email?token={account.VerificationToken}";
                message = $@"<p>Você realizou um cadastro no Planner.</p>
                             <p>Por favor, clique no link abaixo para verificar sua conta:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>
                             <p>Se não realizou nenhum cadastro, por favor ignore este e-mail.</p>
                            ";
            }
            else
            {
                message = $@"<p>Use a chave de acesso abaixo para verificar sua conta em <code>/accounts/verify-email</code> api route:</p>
                             <p><code>{account.VerificationToken}</code></p>";
            }

            _emailService.Send(
                to: account.Email,
                subject: "Planner - Verificação de email do Planner",
                html: $@"<h4>Verificação de Email</h4>
                         <p>Obrigado por se registrar!</p>
                         {message}
                        <br>
                        <br>
                        <br>
                        <p><small> Aviso: Esta mensagem automatica é destinada exclusivamente para a(s) pessoa(s) a quem é dirigida, podendo conter informação confidencial e legalmente protegida. Se você não for destinatário desta mensagem, desde já fica notificado de abster-se a divulgar, copiar, distribuir, examinar ou, de qualquer forma, utilizar a informação contida nesta mensagem, por ser ilegal. Caso você tenha recebido esta mensagem por engano, pedimos que responda essa mensagem informando o acontecido.</small></p>"
            );
        }

        public void sendAlreadyRegisteredEmail(string email, string origin)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
                message = $@"<p>Se você não lembra da sua senha, por favor, acesse nosso site em: <a href=""{origin}/account/forgot-password"">Esqueci minha senha</a>.</p>";
            else
                message = "<p>Se você não lembra da sua senha, você pode resetá-la pela rota <code>/accounts/forgot-password</code> da nossa api.</p>";

            _emailService.Send(
                to: email,
                subject: "Planner - Email já cadastrado",
                html: $@"<h4>Email já cadastrado/h4>
                         <p>Seu email <strong>{email}</strong> já foi previamente registrado no planner.</p>
                         {message}<br>
                        <br>
                        <br>
                        <p><small> Aviso: Esta mensagem automatica é destinada exclusivamente para a(s) pessoa(s) a quem é dirigida, podendo conter informação confidencial e legalmente protegida. Se você não for destinatário desta mensagem, desde já fica notificado de abster-se a divulgar, copiar, distribuir, examinar ou, de qualquer forma, utilizar a informação contida nesta mensagem, por ser ilegal. Caso você tenha recebido esta mensagem por engano, pedimos que responda essa mensagem informando o acontecido.</small></p>"
            );
        }

        public void sendPasswordResetEmail(Account account, string url)
        {
            string message;
            if (!string.IsNullOrEmpty(url)) // Se a request vier de um navegador
            {
                var resetUrl = $"{url}/Planner/account/reset-password?token={account.ResetToken}";
                message = $@"<p>Por favor, clique no link abaixo para restaurar sua senha:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>
                             <br>   
                             <p>Obs.: O link é válido por 1 dia.</p>
                            ";
            }
            else // Se a request vier de um postman ?
            {
                message = $@"<p>Por favor, utilise o token abaixo para restaurar sua senha a rota <code>/accounts/reset-password</code>:</p>
                             <p>Código: <code>{account.ResetToken}</code></p>";
            }

            _emailService.Send(
                to: account.Email,
                subject: "Planner - Recuperação de Senha",
                html: $@"<h4>Email de recuperação de senha</h4>
                         {message}
                        <br>
                        <br>
                        <br>
                        <p><small> Aviso: Esta mensagem automatica é destinada exclusivamente para a(s) pessoa(s) a quem é dirigida, podendo conter informação confidencial e legalmente protegida. Se você não for destinatário desta mensagem, desde já fica notificado de abster-se a divulgar, copiar, distribuir, examinar ou, de qualquer forma, utilizar a informação contida nesta mensagem, por ser ilegal. Caso você tenha recebido esta mensagem por engano, pedimos que responda essa mensagem informando o acontecido.</small></p>"
            );
        }
    }
}
