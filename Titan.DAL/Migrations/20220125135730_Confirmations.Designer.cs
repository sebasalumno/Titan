﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Titan.DAL.Entities;

namespace Titan.DAL.Migrations
{
    [DbContext(typeof(pitufoContext))]
    [Migration("20220125135730_Confirmations")]
    partial class Confirmations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Titan.DAL.Entities.Ciclo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("TipoCicloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FamiliaId");

                    b.HasIndex("TipoCicloId");

                    b.ToTable("Ciclos");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Confirmacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Confirmaciones");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("int");

                    b.Property<string>("localidad")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Familia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Inscripciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoInscripcion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OfertaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("OfertaId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Fin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Horario")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<int>("Remuneracion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Titan.DAL.Entities.OfferEmpresa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCiclo")
                        .HasColumnType("int");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("IdCiclo");

                    b.HasIndex("OfferId");

                    b.ToTable("OfferEmpresas");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("Titan.DAL.Entities.TipoCiclo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TipoCiclos");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CicloId")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Localidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoCicloId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.Property<double>("nota")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CicloId");

                    b.HasIndex("ProvinciaId");

                    b.HasIndex("TipoCicloId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Ciclo", b =>
                {
                    b.HasOne("Titan.DAL.Entities.Familia", "Familia")
                        .WithMany()
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Titan.DAL.Entities.TipoCiclo", "TipoCiclo")
                        .WithMany()
                        .HasForeignKey("TipoCicloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Familia");

                    b.Navigation("TipoCiclo");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Confirmacion", b =>
                {
                    b.HasOne("Titan.DAL.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Empresa", b =>
                {
                    b.HasOne("Titan.DAL.Entities.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Inscripciones", b =>
                {
                    b.HasOne("Titan.DAL.Entities.Usuario", "Alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Titan.DAL.Entities.Offer", "Oferta")
                        .WithMany()
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Oferta");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Offer", b =>
                {
                    b.HasOne("Titan.DAL.Entities.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Titan.DAL.Entities.OfferEmpresa", b =>
                {
                    b.HasOne("Titan.DAL.Entities.Ciclo", "ciclo")
                        .WithMany()
                        .HasForeignKey("IdCiclo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Titan.DAL.Entities.Offer", null)
                        .WithMany("listaCiclos")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ciclo");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Usuario", b =>
                {
                    b.HasOne("Titan.DAL.Entities.Ciclo", "ciclo")
                        .WithMany()
                        .HasForeignKey("CicloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Titan.DAL.Entities.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Titan.DAL.Entities.TipoCiclo", "tipoCiclo")
                        .WithMany()
                        .HasForeignKey("TipoCicloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ciclo");

                    b.Navigation("Provincia");

                    b.Navigation("tipoCiclo");
                });

            modelBuilder.Entity("Titan.DAL.Entities.Offer", b =>
                {
                    b.Navigation("listaCiclos");
                });
#pragma warning restore 612, 618
        }
    }
}
