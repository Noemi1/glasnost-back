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
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<EmpresaCnae> EmpresaCnae { get; set; }
        public virtual DbSet<EmpresaCnae_Rel> EmpresaCnae_Rel { get; set; }
        public virtual DbSet<EmpresaRiscoCompliance> EmpresaRiscoCompliance { get; set; }
        public virtual DbSet<EmpresaTipo> EmpresaTipo { get; set; } 
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // EmpresaCnae_Rel - Empresa
            modelBuilder.Entity<EmpresaCnae_Rel>()
                .HasOne(e => e.Empresa)
                .WithMany(e => e.Empresa_Cnae_Rel)
                .HasForeignKey(e => e.Empresa_Id);

            // EmpresaCnae_Rel - Cnae
            modelBuilder.Entity<EmpresaCnae_Rel>()
                .HasOne(e => e.Cnae)
                .WithMany(e => e.Empresa_Cnae_Rel)
                .HasForeignKey(e => e.Cnae_Id);

            // Empresa - Pessoa
            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.Pessoa)
                .WithOne(e => e.Empresa)
                .HasForeignKey(e => e.Empresa_Id);

            // EmpresaRiscoCompliance - Empresa
            modelBuilder.Entity<EmpresaRiscoCompliance>()
              .HasMany(e => e.Empresa)
              .WithOne(e => e.RiscoCompliance)
              .HasForeignKey(e => e.RiscoCompliance_Id);

            // EmpresaTipo - Empresa
            modelBuilder.Entity<EmpresaTipo>()
              .HasMany(e => e.Empresa)
              .WithOne(e => e.Tipo)
              .HasForeignKey(e => e.Tipo_Id);
            
        }
    }
}
