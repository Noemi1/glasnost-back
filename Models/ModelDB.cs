using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace glasnost_back.Models
{
    public class ModelDB : DbContext
    {
        public ModelDB(DbContextOptions<ModelDB> options) : base(options)
        {
        }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Cliente_Cnae> Cliente_Cnae { get; set; }
        public virtual DbSet<Cliente_Cnae_Rel> Cliente_Cnae_Rel { get; set; }
        public virtual DbSet<Cliente_Tipo> Cliente_Tipo { get; set; }
        public virtual DbSet<Cliente_RiscoCompliance> Cliente_RiscoCompliance { get; set; }
        public virtual DbSet<Cliente_Responsavel> Cliente_Responsavel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>().ToTable("AspNetUsers");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente_Tipo>().ToTable("Cliente_Tipo");
            modelBuilder.Entity<Cliente_RiscoCompliance>().ToTable("Cliente_RiscoCompliance");
            modelBuilder.Entity<Cliente_Responsavel>().ToTable("Cliente_Responsavel");


            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Cliente_Responsavel)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<Cliente_Tipo>()
                .HasMany(e => e.Cliente)
                .WithOne(e => e.Cliente_Tipo)
                .HasForeignKey(e => e.Cliente_Tipo_Id);

            modelBuilder.Entity<Cliente_RiscoCompliance>()
                .HasMany(e => e.Cliente)
                .WithOne(e => e.Cliente_RiscoCompliance)
                .HasForeignKey(e => e.Cliente_Tipo_Id);


            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Cliente_Responsavel)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);


            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.AspNetUsers)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_Id);
        }
    }
}
