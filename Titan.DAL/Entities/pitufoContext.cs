﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Titan.DAL.Entities
{
    public partial class pitufoContext : DbContext
    {
        public DbSet<Inscripciones> Inscripciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Ciclo> Ciclos { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<TipoCiclo> TipoCiclos { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferEmpresa> OfferEmpresas { get; set; }

        public pitufoContext()
        {
        }

        public pitufoContext(DbContextOptions<pitufoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=123456;database=pitufo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
