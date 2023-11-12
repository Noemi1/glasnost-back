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
        public virtual DbSet<Empresa_Cnae> Empresa_Cnae { get; set; }
        public virtual DbSet<Empresa_Cnae_Rel> Empresa_Cnae_Rel { get; set; }
        public virtual DbSet<RiscoCompliance> RiscoCompliance { get; set; }
        public virtual DbSet<Empresa_Tipo> Empresa_Tipo { get; set; } 
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
