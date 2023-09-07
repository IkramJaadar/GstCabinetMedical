﻿// <auto-generated />
using System;
using GstCabinetMedicals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GstCabinetMedical.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GstCabinetMedical.Models.Disponibilite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateRendezvous")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("Horraire")
                        .HasColumnType("time");

                    b.Property<int?>("MedcinID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedcinID");

                    b.ToTable("Disponibilites");
                });

            modelBuilder.Entity("GstCabinetMedical.Models.Medcin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialité")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medcins");
                });

            modelBuilder.Entity("GstCabinetMedical.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("GstCabinetMedical.RendezVous", b =>
                {
                    b.Property<int>("Num")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Num"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan?>("Horraire")
                        .HasColumnType("time");

                    b.Property<int?>("MedcinID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("Num");

                    b.HasIndex("MedcinID");

                    b.HasIndex("PatientID");

                    b.ToTable("RendezVous");
                });

            modelBuilder.Entity("GstCabinetMedical.Models.Disponibilite", b =>
                {
                    b.HasOne("GstCabinetMedical.Models.Medcin", "Medcin")
                        .WithMany("disponibilites")
                        .HasForeignKey("MedcinID");

                    b.Navigation("Medcin");
                });

            modelBuilder.Entity("GstCabinetMedical.RendezVous", b =>
                {
                    b.HasOne("GstCabinetMedical.Models.Medcin", "Medcin")
                        .WithMany("rendezVous")
                        .HasForeignKey("MedcinID");

                    b.HasOne("GstCabinetMedical.Patient", "Patient")
                        .WithMany("rendezVous")
                        .HasForeignKey("PatientID");

                    b.Navigation("Medcin");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("GstCabinetMedical.Models.Medcin", b =>
                {
                    b.Navigation("disponibilites");

                    b.Navigation("rendezVous");
                });

            modelBuilder.Entity("GstCabinetMedical.Patient", b =>
                {
                    b.Navigation("rendezVous");
                });
#pragma warning restore 612, 618
        }
    }
}
