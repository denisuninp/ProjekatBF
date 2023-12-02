﻿// <auto-generated />
using Klinika.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Klinika.Server.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Klinika.Shared.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OdeljenjeId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OdeljenjeId");

                    b.ToTable("Doktori");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrojTelefona = "066654825",
                            Ime = "Bojana",
                            OdeljenjeId = 1,
                            Prezime = "Maksimovic"
                        },
                        new
                        {
                            Id = 2,
                            BrojTelefona = "063224433",
                            Ime = "Nenad",
                            OdeljenjeId = 2,
                            Prezime = "Stojakovic"
                        });
                });

            modelBuilder.Entity("Klinika.Shared.Odeljenje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Odeljenja");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naziv = "Kardiologija",
                            Url = "Kardiologija"
                        },
                        new
                        {
                            Id = 2,
                            Naziv = "Stomatolog",
                            Url = "Stomatolog"
                        });
                });

            modelBuilder.Entity("Klinika.Shared.Pacijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacijenti");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ime = "Denis",
                            Prezime = "Fijuljanin"
                        },
                        new
                        {
                            Id = 2,
                            Ime = "Merisa",
                            Prezime = "Curic"
                        });
                });

            modelBuilder.Entity("Klinika.Shared.Pregled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacijentId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Pregledi");
                });

            modelBuilder.Entity("Klinika.Shared.Doktor", b =>
                {
                    b.HasOne("Klinika.Shared.Odeljenje", "Odeljenje")
                        .WithMany()
                        .HasForeignKey("OdeljenjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odeljenje");
                });

            modelBuilder.Entity("Klinika.Shared.Pregled", b =>
                {
                    b.HasOne("Klinika.Shared.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Klinika.Shared.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Pacijent");
                });
#pragma warning restore 612, 618
        }
    }
}