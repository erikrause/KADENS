﻿// <auto-generated />
using System;
using MRI.PostgresRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MRI.PostgresRepository.Migrations
{
    [DbContext(typeof(MriDbContext))]
    [Migration("20200912151623_AddAllRelationships")]
    partial class AddAllRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MRI.Domain.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("BillStatus")
                        .HasColumnType("integer");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("StatusDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BIK")
                        .HasColumnType("text");

                    b.Property<string>("ContactAddress")
                        .HasColumnType("text");

                    b.Property<string>("INN")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clinic");
                });

            modelBuilder.Entity("MRI.Domain.Entities.ClinicTariff", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("TariffId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TariffId");

                    b.ToTable("ClinicTariff");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClinicId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Inspection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("InspectionDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MriId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Inspection");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Mri", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("StrogaeKey")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Mri");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CardNumber")
                        .HasColumnType("text");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("BLK")
                        .HasColumnType("text");

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("BillId")
                        .HasColumnType("integer");

                    b.Property<int>("ClinicId")
                        .HasColumnType("integer");

                    b.Property<string>("INN")
                        .HasColumnType("text");

                    b.Property<int>("OperationStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Purpose")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BillId")
                        .IsUnique();

                    b.HasIndex("ClinicId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("PriceForTransaction")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("MRI.Domain.Entities.Tariff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("RequestsCount")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("Id");

                    b.ToTable("Tariffs");
                });

            modelBuilder.Entity("MRI.Domain.Entities.TariffForService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("TariffId")
                        .HasColumnType("integer");

                    b.Property<int>("TransactionsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("TariffId");

                    b.ToTable("TariffForService");
                });

            modelBuilder.Entity("MRI.Domain.Entities.TransactionsLeftovers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ClinicId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<int>("TransactionsLeft")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("ServiceId");

                    b.ToTable("TransactionsLeftovers");
                });

            modelBuilder.Entity("MRI.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsLockedOut")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MRI.Domain.Entities.ClinicTariff", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Clinic", "Clinic")
                        .WithOne("ClinicTariff")
                        .HasForeignKey("MRI.Domain.Entities.ClinicTariff", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRI.Domain.Entities.Tariff", "Tariff")
                        .WithMany("ClinicTariffs")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRI.Domain.Entities.Doctor", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Clinic", "Clinic")
                        .WithMany("Doctors")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRI.Domain.Entities.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("MRI.Domain.Entities.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRI.Domain.Entities.Inspection", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Patient", "Patient")
                        .WithMany("Inspections")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRI.Domain.Entities.Mri", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Inspection", "Inspection")
                        .WithOne("Mri")
                        .HasForeignKey("MRI.Domain.Entities.Mri", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRI.Domain.Entities.Patient", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRI.Domain.Entities.Payment", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Bill", "Bill")
                        .WithOne("Payment")
                        .HasForeignKey("MRI.Domain.Entities.Payment", "BillId");

                    b.HasOne("MRI.Domain.Entities.Clinic", "Clinic")
                        .WithMany("Payments")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRI.Domain.Entities.TariffForService", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Service", "Service")
                        .WithMany("TariffForServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRI.Domain.Entities.Tariff", "Tariff")
                        .WithMany("TariffsForService")
                        .HasForeignKey("TariffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MRI.Domain.Entities.TransactionsLeftovers", b =>
                {
                    b.HasOne("MRI.Domain.Entities.Clinic", "Clinic")
                        .WithMany("TransactionsLeftovers")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MRI.Domain.Entities.Service", "Service")
                        .WithMany("TransactionsLeftovers")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
