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
        /*
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountPerfilAcesso> AccountPerfilAcesso { get; set; }
        public virtual DbSet<Acionista> Acionista { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
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
        */
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Empresa_Cnae> Empresa_Cnae { get; set; }
        public virtual DbSet<Empresa_Cnae_Rel> Empresa_Cnae_Rel { get; set; }
        public virtual DbSet<RiscoCompliance> RiscoCompliance { get; set; }
        public virtual DbSet<Empresa_Tipo> Empresa_Tipo { get; set; } 
        /*
        public virtual DbSet<Empresa_Responsavel> Empresa_Responsavel { get; set; }

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

        public virtual DbSet<PDFKey> PDFKey { get; set; }*/
        public virtual DbSet<Pessoa> Pessoa { get; set; }/*
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
        public virtual DbSet<Treinamento_Empresa_Rel> Treinamento_Empresa_Rel { get; set; }
        public virtual DbSet<Treinamento_Tipo> Treinamento_Tipo { get; set; }
        public virtual DbSet<Treinamento_Area> Treinamento_Area { get; set; }
        public virtual DbSet<Treinamento_Pagina> Treinamento_Pagina { get; set; }
        public virtual DbSet<Treinamento_Pergunta> Treinamento_Pergunta { get; set; }
        public virtual DbSet<Treinamento_Pergunta_Resposta> Treinamento_Pergunta_Resposta { get; set; }
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Empresa_Cnae_Rel - Empresa
            modelBuilder.Entity<Empresa_Cnae_Rel>()
                .HasOne(e => e.Empresa)
                .WithMany(e => e.Empresa_Cnae_Rel)
                .HasForeignKey(e => e.Empresa_Id);

            // Empresa_Cnae_Rel - Cnae
            modelBuilder.Entity<Empresa_Cnae_Rel>()
                .HasOne(e => e.Cnae)
                .WithMany(e => e.Empresa_Cnae_Rel)
                .HasForeignKey(e => e.Cnae_Id);

            // Empresa - Pessoa
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Pessoa)
                .WithOne(e => e.Empresa)
                .HasForeignKey(e => e.Empresa_Id);
         
            // Empresa_RiscoCompliance - Empresa
            modelBuilder.Entity<RiscoCompliance>()
              .HasMany(e => e.Empresa)
              .WithOne(e => e.RiscoCompliance)
              .HasForeignKey(e => e.RiscoCompliance_Id);

            // Empresa_Tipo - Empresa
            modelBuilder.Entity<Empresa_Tipo>()
              .HasMany(e => e.Empresa)
              .WithOne(e => e.Tipo)
              .HasForeignKey(e => e.Tipo_Id);
            
        }
    }
}
