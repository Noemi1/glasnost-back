using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace glasnost_back.Entities
{
    public partial class Account : BaseEntity
    {
        public Account()
        {
            Comunicado_Account_Rel = new HashSet<Comunicado_Account_Rel>();
            Comunicado_UserEnvio = new HashSet<Comunicado>();
            Comunicado_UserCriacao = new HashSet<Comunicado>();
            Cliente_Responsavel = new HashSet<Empresa_Responsavel>();
            Denuncia = new HashSet<Denuncia>();
            DueDiligence_Consulta = new HashSet<DueDiligence_Consulta>();
            Denuncia_Relatorio = new HashSet<Denuncia_Relatorio>();
            RefreshToken = new HashSet<RefreshToken>();
            Log = new HashSet<Log>();
            LogEntities = new HashSet<LogEntities>();
            LogError = new HashSet<LogError>();
            Organograma_Treinamento_Envio = new HashSet<Organograma_Treinamento_Envio>();
            Prospect_Arquivo = new HashSet<Prospect_Arquivo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long TelefoneCelular { get; set; }
        public string PasswordHash { get; set; }
        public bool AcceptTerms { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? DataDesativado { get; set; }
        public int Cliente_Id { get; set; }
        public int PerfilAcesso_Id { get; set; }
        public int Pessoa_Id { get; set; }

        public AccountPerfilAcesso PerfilAcesso { get; set; }
        public Empresa Cliente { get; set; }
        public Pessoa Pessoa { get; set; }

        public ICollection<Comunicado_Account_Rel> Comunicado_Account_Rel { get; set; }
        public ICollection<Comunicado> Comunicado_UserEnvio { get; set; }
        public ICollection<Comunicado> Comunicado_UserCriacao { get; set; }
        public ICollection<Empresa_Responsavel> Cliente_Responsavel { get; set; }
        public ICollection<Denuncia> Denuncia { get; set; }
        public ICollection<Denuncia_Relatorio> Denuncia_Relatorio { get; set; }
        public ICollection<DueDiligence_Consulta> DueDiligence_Consulta { get; set; }
        public ICollection<RefreshToken> RefreshToken { get; set; }
        public ICollection<Log> Log { get; set; }
        public ICollection<LogEntities> LogEntities { get; set; }
        public ICollection<LogError> LogError { get; set; }
        public ICollection<Organograma_Treinamento_Envio> Organograma_Treinamento_Envio { get; set; }
        public ICollection<Prospect_Arquivo> Prospect_Arquivo { get; set; }

        public bool OwnsToken(string token)
        {
            var list = this.RefreshToken.ToList().Find(x => x.Token == token) != null;
            return list;
        }
    }
}
