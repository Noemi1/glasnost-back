using glasnost_back.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace glasnost_back.Helpers
{
    public partial class ModelDBContext : DbContext
    {
        private readonly IConfiguration Configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ModelDBContext(IConfiguration configuration, IHttpContextAccessor _httpContextAccessor)
        {
            Configuration = configuration;
            httpContextAccessor = _httpContextAccessor;
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountPerfilAcesso> AccountPerfilAcesso { get; set; }
        public virtual DbSet<Acionista> Acionista { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cliente_Cnae> Cliente_Cnae { get; set; }
        public virtual DbSet<Cliente_Cnae_Rel> Cliente_Cnae_Rel { get; set; }
        public virtual DbSet<Cliente_Responsavel> Cliente_Responsavel { get; set; }
        public virtual DbSet<Cliente_RiscoCompliance> Cliente_RiscoCompliance { get; set; }
        public virtual DbSet<Cliente_Tipo> Cliente_Tipo { get; set; }
        public virtual DbSet<Comunicado> Comunicado { get; set; }
        public virtual DbSet<Comunicado_Account_Rel> Comunicado_Account_Rel { get; set; }

        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<Denuncia_Acao> Denuncia_Acao { get; set; }
        public virtual DbSet<Denuncia_Arquivo> Denuncia_Arquivo { get; set; }
        public virtual DbSet<Denuncia_Assunto> Denuncia_Assunto { get; set; }
        public virtual DbSet<Denuncia_Canal> Denuncia_Canal { get; set; }
        public virtual DbSet<Denuncia_Categoria> Denuncia_Categoria { get; set; }
        public virtual DbSet<Denuncia_Denunciante> Denuncia_Denunciante { get; set; }
        public virtual DbSet<Denuncia_Envolvido> Denuncia_Envolvido { get; set; }
        public virtual DbSet<Denuncia_Envolvido_Acao> Denuncia_Envolvido_Acao { get; set; }
        public virtual DbSet<Denuncia_Gravidade> Denuncia_Gravidade { get; set; }
        public virtual DbSet<Denuncia_Historico_Status> Denuncia_Historico_Status { get; set; }
        public virtual DbSet<Denuncia_Relatorio> Denuncia_Relatorio { get; set; }
        public virtual DbSet<Denuncia_Status> Denuncia_Status { get; set; }
        public virtual DbSet<Denuncia_Urgencia> Denuncia_Urgencia { get; set; }
        public virtual DbSet<Denuncia_Validacao> Denuncia_Validacao { get; set; }

        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Documento_Anexo> Documento_Anexo { get; set; }
        public virtual DbSet<Documento_Aprovacao> Documento_Aprovacao { get; set; }
        public virtual DbSet<Documento_Modelo> Documento_Modelo { get; set; }
        public virtual DbSet<Documento_Modelo_Anexo> Documento_Modelo_Anexo { get; set; }
        public virtual DbSet<Documento_Tipo> Documento_Tipo { get; set; }
        public virtual DbSet<Documento_Tipo_Categoria> Documento_Tipo_Categoria { get; set; }
        public virtual DbSet<DueDiligence_Pessoa> DueDiligence_Pessoa { get; set; }
        public virtual DbSet<DueDiligence_Parecer> DueDiligence_Parecer { get; set; }
        public virtual DbSet<DueDiligence_Status> DueDiligence_Status { get; set; }
        public virtual DbSet<DueDiligence_ListaRestrita> DueDiligence_ListaRestrita { get; set; }
        public virtual DbSet<DueDiligence_ListaRestrita_Dados> DueDiligence_ListaRestrita_Dados { get; set; }
        public virtual DbSet<DueDiligence_ListaRestrita_Dados_Alias> DueDiligence_ListaRestrita_Dados_Alias { get; set; }
        public virtual DbSet<DueDiligence_ListaRestrita_Origem> DueDiligence_ListaRestrita_Origem { get; set; }
        public virtual DbSet<DueDiligence_Consulta> DueDiligence_Consulta { get; set; }
        public virtual DbSet<DueDiligence_Consulta_Resultado> DueDiligence_Consulta_Resultado { get; set; }

        public virtual DbSet<Estado> Estado { get; set; }

        public virtual DbSet<Estatutario> Estatutario { get; set; }

        public virtual DbSet<Log> Log { get; set; }

        public virtual DbSet<Organograma> Organograma { get; set; }
        public virtual DbSet<Organograma_Treinamento> Organograma_Treinamento { get; set; }
        public virtual DbSet<Organograma_Treinamento_Envio> Organograma_Treinamento_Envio { get; set; }
        public virtual DbSet<Organograma_Treinamento_Acesso> Organograma_Treinamento_Acesso { get; set; }
        public virtual DbSet<Organograma_Treinamento_List> Organograma_Treinamento_List { get; set; }

        public virtual DbSet<ParteRelacionada> ParteRelacionada { get; set; }
        public virtual DbSet<ParteRelacionada_Tipo> ParteRelacionada_Tipo { get; set; }

        public virtual DbSet<PDFKey> PDFKey { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Pessoa_Qualificada> Pessoa_Qualificada { get; set; }
        public virtual DbSet<Pessoa_Qualificada_Qualificacao> Pessoa_Qualificada_Qualificacao { get; set; }
        public virtual DbSet<Pessoa_Qualificada_Qualificacao_Certificado> Pessoa_Qualificada_Qualificacao_Certificado { get; set; }
        public virtual DbSet<Pessoa_Qualificada_Qualificacao_Rel> Pessoa_Qualificada_Qualificacao_Rel { get; set; }
        public virtual DbSet<Procurador> Procurador { get; set; }

        public virtual DbSet<Prospect> Prospect { get; set; }
        public virtual DbSet<Prospect_Arquivo> Prospect_Arquivo { get; set; }
        public virtual DbSet<Prospect_Status> Prospect_Status { get; set; }
        public virtual DbSet<Relatorio_Denuncias> Relatorio_Denuncias { get; set; }

        public virtual DbSet<RefreshToken> RefreshToken { get; set; }

        public virtual DbSet<Treinamento> Treinamento { get; set; }
        public virtual DbSet<Treinamento_Cliente_Rel> Treinamento_Cliente_Rel { get; set; }
        public virtual DbSet<Treinamento_Tipo> Treinamento_Tipo { get; set; }
        public virtual DbSet<Treinamento_Area> Treinamento_Area { get; set; }
        public virtual DbSet<Treinamento_Pagina> Treinamento_Pagina { get; set; }
        public virtual DbSet<Treinamento_Pergunta> Treinamento_Pergunta { get; set; }
        public virtual DbSet<Treinamento_Pergunta_Resposta> Treinamento_Pergunta_Resposta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Account - Comunicado_Account_Rel
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Comunicado_Account_Rel)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - Comunicado_UserEnvio
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Comunicado_UserEnvio)
                .WithOne(e => e.UserEnvio)
                .HasForeignKey(e => e.UserEnvio_Id);

            // Account - Comunicado_UserCriacao
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Comunicado_UserCriacao)
                .WithOne(e => e.UserCriacao)
                .HasForeignKey(e => e.UserCriacao_Id);

            // Account - Cliente_Responsavel
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Cliente_Responsavel)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - Denuncia
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - Denuncia_Relatorio
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Denuncia_Relatorio)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - RefreshToken
            modelBuilder.Entity<Account>()
                .HasMany(e => e.RefreshToken)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - Log
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Log)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - LogEntities
            modelBuilder.Entity<Account>()
                .HasMany(e => e.LogEntities)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - LogError
            modelBuilder.Entity<Account>()
                .HasMany(e => e.LogError)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Account - Organograma_Treinamento_Envio
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Organograma_Treinamento_Envio)
                .WithOne(e => e.Account_Organograma_Treinamento_Envio)
                .HasForeignKey(e => e.Account_Id);

            // Account - Prospect_Arquivo
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Prospect_Arquivo)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // Acionista - SocioDe
            modelBuilder.Entity<Acionista>()
                 .HasMany(e => e.Socios)
                 .WithOne(e => e.SocioDe)
                 .HasForeignKey(e => e.Acionista_Id)
                 .IsRequired(false);

            // Area - Denuncia
            modelBuilder.Entity<Area>()
              .HasMany(e => e.Denuncia)
              .WithOne(e => e.Area)
              .HasForeignKey(e => e.ClienteArea_Id);

            // Area - Estatutario
            modelBuilder.Entity<Area>()
              .HasMany(e => e.Estatutario)
              .WithOne(e => e.Area)
              .HasForeignKey(e => e.Area_Id);

            // Area - Treinamento_Area
            modelBuilder.Entity<Area>()
              .HasMany(e => e.Treinamento_Area)
              .WithOne(e => e.Area)
              .HasForeignKey(e => e.Area_Id);

            // Area - Treinamento_Area
            modelBuilder.Entity<Area>()
              .HasMany(e => e.Treinamento_Area)
              .WithOne(e => e.Area)
              .HasForeignKey(e => e.Area_Id);

            // Area - Pessoa_Qualificada
            modelBuilder.Entity<Area>()
              .HasMany(e => e.Pessoa_Qualificada)
              .WithOne(e => e.Area)
              .HasForeignKey(e => e.Area_Id);

            // Area - Procurador
            modelBuilder.Entity<Area>()
              .HasMany(e => e.Procurador)
              .WithOne(e => e.Area)
              .HasForeignKey(e => e.Area_Id);

            // Area - Organograma
            modelBuilder.Entity<Area>()
              .HasMany(e => e.Organograma)
              .WithOne(e => e.Area)
              .HasForeignKey(e => e.Area_Id);

            // Cidade - Prospect
            modelBuilder.Entity<Cidade>()
                .HasMany(e => e.Prospect)
                .WithOne(e => e.Cidade)
                .HasForeignKey(e => e.Cidade_Id);

            // Cidade - Estado
            modelBuilder.Entity<Estado>()
                .HasMany(e => e.Cidade)
                .WithOne(e => e.Estado)
                .HasForeignKey(e => e.Estado_Id);

            // Cliente - Account
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Account)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Acionista
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Acionista)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Cliente_Cnae_Rel-Cnae
            modelBuilder.Entity<Cliente_Cnae>()
                .HasMany(e => e.Cliente_Cnae_Rel)
                .WithOne(e => e.Cnae)
                .HasForeignKey(e => e.Cnae_Id);

            // Cliente - Cliente_Cnae_Rel-Cliente
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Cliente_Cnae_Rel)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Cliente_Responsavel
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Cliente_Responsavel)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Comunicado
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Comunicado)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Denuncia
            modelBuilder.Entity<Cliente>()
              .HasMany(e => e.Denuncia)
              .WithOne(e => e.Cliente)
              .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Documento
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Documento)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Documento_Modelo
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Documento_Modelo)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Estatutario
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Estatutario)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Organograma
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Organograma)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Pessoa
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Pessoa)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - ParteRelacionada
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.ParteRelacionada)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Pessoa_Qualificada
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Pessoa_Qualificada)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Procurador
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Procurador)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Relatorio_Denuncias
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Relatorio_Denuncias)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - Treinamento
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Treinamento)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Cliente - TreinamentoCliente
            modelBuilder.Entity<Cliente>()
              .HasMany(e => e.Treinamento_Cliente)
              .WithOne(e => e.Cliente)
              .HasForeignKey(e => e.Cliente_Id);

            // Cliente_RiscoCompliance - Cliente
            modelBuilder.Entity<Cliente_RiscoCompliance>()
              .HasMany(e => e.Clientes)
              .WithOne(e => e.Cliente_RiscoCompliance)
              .HasForeignKey(e => e.RiscoCompliance_Id);

            // Cliente_Tipo - Cliente
            modelBuilder.Entity<Cliente_Tipo>()
              .HasMany(e => e.Cliente)
              .WithOne(e => e.Cliente_Tipo)
              .HasForeignKey(e => e.Cliente_Tipo_Id);

            // Comunicado - Comunicado_Account_Rel
            modelBuilder.Entity<Comunicado>()
              .HasMany(e => e.Comunicado_Account_Rel)
              .WithOne(e => e.Comunicado)
              .HasForeignKey(e => e.Comunicado_Id);

            // Denuncia - Denuncia_Arquivo
            modelBuilder.Entity<Denuncia>()
                .HasMany(e => e.Denuncia_Arquivo)
                .WithOne(e => e.Denuncia)
                .HasForeignKey(e => e.Denuncia_Id);

            // Denuncia - Denuncia_Denunciante
            modelBuilder.Entity<Denuncia>()
                .HasMany(e => e.Denuncia_Denunciante)
                .WithOne(e => e.Denuncia)
                .HasForeignKey(e => e.Denuncia_Id);

            // Denuncia - Denuncia_Envolvido
            modelBuilder.Entity<Denuncia>()
                .HasMany(e => e.Denuncia_Envolvido)
                .WithOne(e => e.Denuncia)
                .HasForeignKey(e => e.Denuncia_Id);

            // Denuncia - Denuncia_Historico_Status
            modelBuilder.Entity<Denuncia>()
                .HasMany(e => e.Denuncia_Historico_Status)
                .WithOne(e => e.Denuncia)
                .HasForeignKey(e => e.Denuncia_Id);

            // Denuncia - Denuncia_Relatorio
            modelBuilder.Entity<Denuncia>()
                .HasMany(e => e.Denuncia_Relatorio)
                .WithOne(e => e.Denuncia)
                .HasForeignKey(e => e.Denuncia_Id);

            // Denuncia_Acao - Denuncia
            modelBuilder.Entity<Denuncia_Acao>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Denuncia_Acao)
                .HasForeignKey(e => e.DenunciaAcao_Id)
                .IsRequired(false);

            // Denuncia_Canal - Denuncia
            modelBuilder.Entity<Denuncia_Canal>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Denuncia_Canal)
                .HasForeignKey(e => e.DenunciaCanal_Id);

            // Denuncia_Categoria - Denuncia
            modelBuilder.Entity<Denuncia_Categoria>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Denuncia_Categoria)
                .HasForeignKey(e => e.DenunciaCategoria_Id);

            // Denuncia_Gravidade - Denuncia
            modelBuilder.Entity<Denuncia_Gravidade>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Denuncia_Gravidade)
                .HasForeignKey(e => e.DenunciaGravidade_Id);

            // Denuncia_Envolvido_Acao - Denuncia_Envolvido
            modelBuilder.Entity<Denuncia_Envolvido_Acao>()
                .HasMany(e => e.Denuncia_Envolvido)
                .WithOne(e => e.Denuncia_Envolvido_Acao)
                .HasForeignKey(e => e.Denuncia_Envolvido_Acao_Id);

            // Denuncia_Status - Denuncia
            modelBuilder.Entity<Denuncia_Status>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Denuncia_Status)
                .HasForeignKey(e => e.DenunciaStatus_Id);

            // Denuncia_Status - Denuncia_Historico_Status
            modelBuilder.Entity<Denuncia_Status>()
                .HasMany(e => e.Denuncia_Historico_Status)
                .WithOne(e => e.Denuncia_Status)
                .HasForeignKey(e => e.Status_Id);

            // Denuncia_Urgencia - Denuncia
            modelBuilder.Entity<Denuncia_Urgencia>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Denuncia_Urgencia)
                .HasForeignKey(e => e.DenunciaUrgencia_Id);

            // Denuncia_Validacao - Denuncia
            modelBuilder.Entity<Denuncia_Validacao>()
                .HasMany(e => e.Denuncia)
                .WithOne(e => e.Denuncia_Validacao)
                .HasForeignKey(e => e.DenunciaValidacao_Id);

            // Documento_Tipo - Documento
            modelBuilder.Entity<Documento_Tipo>()
               .HasMany(e => e.Documento)
               .WithOne(e => e.Documento_Tipo)
               .HasForeignKey(e => e.Documento_Tipo_Id);

            // Documento_Tipo - Documento_Modelo
            modelBuilder.Entity<Documento_Tipo>()
               .HasMany(e => e.Documento_Modelo)
               .WithOne(e => e.Documento_Tipo)
               .HasForeignKey(e => e.Documento_Tipo_Id);

            // Documento_Modelo - Documento_Modelo_Anexo
            modelBuilder.Entity<Documento_Modelo>()
               .HasMany(e => e.Documento_Modelo_Anexo)
               .WithOne(e => e.Documento_Modelo)
               .HasForeignKey(e => e.Documento_Modelo_Id);

            // Documento_Tipo_Categoria - Documento_Tipo
            modelBuilder.Entity<Documento_Tipo_Categoria>()
                .HasMany(e => e.Documento_Tipo)
                .WithOne(e => e.Documento_Tipo_Categoria)
                .HasForeignKey(e => e.Documento_Tipo_Categoria_Id);

            // Documento - Documento_Aprovacao
            modelBuilder.Entity<Documento>()
                .HasMany(e => e.Documento_Aprovacao)
                .WithOne(e => e.Documento)
                .HasForeignKey(e => e.Documento_Id);

            // Documento - Documento_Anexo
            modelBuilder.Entity<Documento>()
                .HasMany(e => e.Documento_Anexo)
                .WithOne(e => e.Documento)
                .HasForeignKey(e => e.Documento_Id);

            // DueDiligence_Consulta - AspNetUsers
            modelBuilder.Entity<Account>()
                .HasMany(e => e.DueDiligence_Consulta)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.Account_Id);

            // DueDiligence_Consulta - DueDiligence_Status
            modelBuilder.Entity<DueDiligence_Status>()
                .HasMany(e => e.DueDiligence_Consulta)
                .WithOne(e => e.DueDiligence_Status)
                .HasForeignKey(e => e.Status_Id);

            // DueDiligence_Consulta - DueDiligence_Parecer
            modelBuilder.Entity<DueDiligence_Parecer>()
                .HasMany(e => e.DueDiligence_Consulta)
                .WithOne(e => e.DueDiligence_Parecer)
                .HasForeignKey(e => e.Parecer_Id);

            // DueDiligence_Consulta - DueDiligence_Pessoa
            modelBuilder.Entity<DueDiligence_Pessoa>()
                .HasMany(e => e.DueDiligence_Consulta)
                .WithOne(e => e.DueDiligence_Pessoa)
                .HasForeignKey(e => e.DueDiligence_Pessoa_Id);

            // DueDiligence_Consulta_Resultado - DueDiligence_Consulta
            modelBuilder.Entity<DueDiligence_Consulta>()
                .HasMany(e => e.DueDiligence_Consulta_Resultado)
                .WithOne(e => e.DueDiligence_Consulta)
                .HasForeignKey(e => e.DueDiligence_Consulta_Id);

            // DueDiligence_Consulta_Resultado - DueDiligence_ListaRestrita
            modelBuilder.Entity<DueDiligence_ListaRestrita>()
                .HasMany(e => e.DueDiligence_Consulta_Resultado)
                .WithOne(e => e.DueDiligence_ListaRestrita)
                .HasForeignKey(e => e.DueDiligence_ListaRestrita_Id);

            // DueDiligence_ListaRestrita_Origem - DueDiligence_Consulta_Resultado
            modelBuilder.Entity<DueDiligence_ListaRestrita_Origem>()
                .HasMany(e => e.DueDiligence_Consulta_Resultado)
                .WithOne(e => e.DueDiligence_ListaRestrita_Origem)
                .HasForeignKey(e => e.DueDiligence_ListaRestrita_Origem_Id);

            // DueDiligence_ListaRestrita_Origem - DueDiligence_ListaRestrita
            modelBuilder.Entity<DueDiligence_ListaRestrita_Origem>()
                .HasMany(e => e.DueDiligence_ListaRestrita)
                .WithOne(e => e.DueDiligence_ListaRestrita_Origem)
                .HasForeignKey(e => e.DueDiligence_ListaRestrita_Origem_Id);

            // DueDiligence_ListaRestrita - DueDiligence_ListaRestrita_Dados
            modelBuilder.Entity<DueDiligence_ListaRestrita>()
                .HasMany(e => e.DueDiligence_ListaRestrita_Dados)
                .WithOne(e => e.DueDiligence_ListaRestrita)
                .HasForeignKey(e => e.DueDiligence_ListaRestrita_Id);

            // DueDiligence_ListaRestrita_Dados - DueDiligence_ListaRestrita_Dados
            modelBuilder.Entity<DueDiligence_ListaRestrita_Dados>()
                .HasMany(e => e.CamposFilhos)
                .WithOne(e => e.CampoPai)
                .HasForeignKey(e => e.CampoPai_Id);

            // DueDiligence_ListaRestrita_Dados_Alias - DueDiligence_ListaRestrita_Dados
            modelBuilder.Entity<DueDiligence_ListaRestrita_Dados_Alias>()
                .HasMany(e => e.DueDiligence_ListaRestrita_Dados)
                .WithOne(e => e.DueDiligence_ListaRestrita_Dados_Alias)
                .HasForeignKey(e => e.DueDiligence_ListaRestrita_Dados_Alias_Id);

            // DueDiligence_Pessoa - Cliente
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.DueDiligence_Pessoa)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);

            // Organograma - OrgSubordinado
            modelBuilder.Entity<Organograma>()
                .HasMany(e => e.OrgSubordinado)
                .WithOne(e => e.OrgSuperior)
                .HasForeignKey(e => e.Cliente_Organograma_Id);

            // Organograma - Organograma_Treinamento
            modelBuilder.Entity<Organograma>()
              .HasMany(e => e.Organograma_Treinamento)
              .WithOne(e => e.Organograma)
              .HasForeignKey(e => e.Organograma_Id);

            // Organograma_Treinamento - Organograma_Treinamento_Envio
            modelBuilder.Entity<Organograma_Treinamento>()
              .HasMany(e => e.Organograma_Treinamento_Envio)
              .WithOne(e => e.Organograma_Treinamento)
              .HasForeignKey(e => e.Organograma_Treinamento_Id);

            // Organograma_Treinamento - Organograma_Treinamento_Acesso
            modelBuilder.Entity<Organograma_Treinamento>()
                .HasMany(e => e.Organograma_Treinamento_Acesso)
                .WithOne(e => e.Organograma_Treinamento)
                .HasForeignKey(e => e.Organograma_Treinamento_Id);

            // Pessoa_Qualificada - Pessoa_Qualificada_Qualificacao_Rel
            modelBuilder.Entity<Pessoa_Qualificada>()
                .HasMany(e => e.Pessoa_Qualificada_Qualificacao_Rel)
                .WithOne(e => e.Pessoa_Qualificada)
                .HasForeignKey(e => e.Pessoa_Qualificada_Id);

            // Pessoa - Acionista
            modelBuilder.Entity<Pessoa>()
               .HasMany(e => e.Acionista)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.Pessoa_Id);

            // Pessoa - Account
            modelBuilder.Entity<Pessoa>()
               .HasMany(e => e.Account)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.Pessoa_Id);

            // Pessoa - Estatutario
            modelBuilder.Entity<Pessoa>()
               .HasMany(e => e.Estatutario)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.Pessoa_Id);

            // Pessoa - ParteRelacionada
            modelBuilder.Entity<Pessoa>()
               .HasMany(e => e.ParteRelacionada)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.Pessoa_Id);

            // Pessoa - Pessoa_Qualificada
            modelBuilder.Entity<Pessoa>()
               .HasMany(e => e.Pessoa_Qualificada)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.Pessoa_Id);

            // Pessoa - Procurador
            modelBuilder.Entity<Pessoa>()
               .HasMany(e => e.Procurador)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.Pessoa_Id);

            // Pessoa - Organograma
            modelBuilder.Entity<Pessoa>()
               .HasMany(e => e.Organograma)
               .WithOne(e => e.Pessoa)
               .HasForeignKey(e => e.Pessoa_Id);

            // Pessoa_Qualificada_Qualificacao - Pessoa_Qualificada_Qualificacao_Rel
            modelBuilder.Entity<Pessoa_Qualificada_Qualificacao>()
               .HasMany(e => e.Pessoa_Qualificada_Qualificacao_Rel)
               .WithOne(e => e.Pessoa_Qualificada_Qualificacao)
               .HasForeignKey(e => e.Pessoa_Qualificada_Qualificacao_Id);

            // Pessoa_Qualificada_Qualificacao_Rel - Pessoa_Qualificada_Qualificacao_Certificado
            modelBuilder.Entity<Pessoa_Qualificada_Qualificacao_Rel>()
              .HasMany(e => e.Pessoa_Qualificada_Qualificacao_Certificado)
              .WithOne(e => e.Pessoa_Qualificada_Qualificacao_Rel)
              .HasForeignKey(e => e.Pessoa_Qualificada_Qualificacao_Rel_Id);

            // ParteRelacionada_Tipo - ParteRelacionada
            modelBuilder.Entity<ParteRelacionada_Tipo>()
                .HasMany(e => e.ParteRelacionada)
                .WithOne(e => e.ParteRelacionada_Tipo)
                .HasForeignKey(e => e.ParteRelacionada_Tipo_Id);

            // Prospect - Prospect_Arquivo
            modelBuilder.Entity<Prospect>()
                .HasMany(e => e.Prospect_Arquivo)
                .WithOne(e => e.Prospect)
                .HasForeignKey(e => e.Prospect_Id);

            // Prospect_Status - Prospect
            modelBuilder.Entity<Prospect_Status>()
                .HasMany(e => e.Prospect)
                .WithOne(e => e.Prospect_Status)
                .HasForeignKey(e => e.Prospect_Status_Id);

            // Treinamento - Treinamento_Area
            modelBuilder.Entity<Treinamento>()
              .HasMany(e => e.Treinamento_Area)
              .WithOne(e => e.Treinamento)
              .HasForeignKey(e => e.Treinamento_Id);

            // Treinamento - TreinamentoCliente
            modelBuilder.Entity<Treinamento>()
              .HasMany(e => e.Treinamento_Cliente)
              .WithOne(e => e.Treinamento)
              .HasForeignKey(e => e.Treinamento_Id);

            // Treinamento - Organograma_Treinamento
            modelBuilder.Entity<Treinamento>()
              .HasMany(e => e.Organograma_Treinamento)
              .WithOne(e => e.Treinamento)
              .HasForeignKey(e => e.Treinamento_Id);

            // Treinamento - Treinamento_Pergunta
            modelBuilder.Entity<Treinamento>()
                .HasMany(e => e.Treinamento_Pergunta)
                .WithOne(e => e.Treinamento)
                .HasForeignKey(e => e.Treinamento_Id);

            // Treinamento_Pergunta - Treinamento_Pergunta_Resposta
            modelBuilder.Entity<Treinamento_Pergunta>()
                .HasMany(e => e.Treinamento_Pergunta_Resposta)
                .WithOne(e => e.Treinamento_Pergunta)
                .HasForeignKey(e => e.Treinamento_Pergunta_Id);

            // Treinamento - Treinamento_Pagina
            modelBuilder.Entity<Treinamento>()
                .HasMany(e => e.Treinamento_Pagina)
                .WithOne(e => e.Treinamento)
                .HasForeignKey(e => e.Treinamento_Id);

            // Treinamento_Tipo - Treinamento
            modelBuilder.Entity<Treinamento_Tipo>()
                .HasMany(e => e.Treinamento)
                .WithOne(e => e.Treinamento_Tipo)
                .HasForeignKey(e => e.TreinamentoTipo_Id);
        }
    }
}
