﻿// <auto-generated />
using System;
using Bienestar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bienestar.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230713035418_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bienestar.Entities.Entities.Hijo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescripcionFisica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("EstaturaCms")
                        .HasColumnType("smallint");

                    b.Property<string>("Estudia")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("TL_Hijos");
                });

            modelBuilder.Entity("Bienestar.Entities.Entities.Padre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short?>("ExperienciaLaboral")
                        .HasColumnType("smallint");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoEmpleo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("TL_Padres");
                });

            modelBuilder.Entity("Bienestar.Entities.Entities.RelacionPadreHijo", b =>
                {
                    b.Property<int>("PadreId")
                        .HasColumnType("int");

                    b.Property<int>("HijoId")
                        .HasColumnType("int");

                    b.HasKey("PadreId", "HijoId");

                    b.HasIndex("HijoId");

                    b.ToTable("TL_RelacionPadresHijos");
                });

            modelBuilder.Entity("Bienestar.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("NumeroIdentificacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NumeroIdentificacion");

                    b.ToTable("TL_Usuarios");
                });

            modelBuilder.Entity("Bienestar.Entities.Entities.Hijo", b =>
                {
                    b.HasOne("Bienestar.Entities.Usuario", null)
                        .WithOne("Hijo")
                        .HasForeignKey("Bienestar.Entities.Entities.Hijo", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bienestar.Entities.Entities.Padre", b =>
                {
                    b.HasOne("Bienestar.Entities.Usuario", null)
                        .WithOne("Padre")
                        .HasForeignKey("Bienestar.Entities.Entities.Padre", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bienestar.Entities.Entities.RelacionPadreHijo", b =>
                {
                    b.HasOne("Bienestar.Entities.Entities.Hijo", "Hijo")
                        .WithMany("RelacionPadreHijo")
                        .HasForeignKey("HijoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bienestar.Entities.Entities.Padre", "Padre")
                        .WithMany("RelacionPadreHijo")
                        .HasForeignKey("PadreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hijo");

                    b.Navigation("Padre");
                });

            modelBuilder.Entity("Bienestar.Entities.Entities.Hijo", b =>
                {
                    b.Navigation("RelacionPadreHijo");
                });

            modelBuilder.Entity("Bienestar.Entities.Entities.Padre", b =>
                {
                    b.Navigation("RelacionPadreHijo");
                });

            modelBuilder.Entity("Bienestar.Entities.Usuario", b =>
                {
                    b.Navigation("Hijo");

                    b.Navigation("Padre");
                });
#pragma warning restore 612, 618
        }
    }
}
