using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MRI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRI.PostgresRepository
{
    public class MriDbContext : DbContext
    {
        public DbSet<Tariff> Tariffs { get; set; }
        public MriDbContext(DbContextOptions<MriDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tariff>()
                .HasMany(t => t.ClinicTariffs)
                .WithOne(cT => cT.Tariff)
                .HasForeignKey(cT => cT.TariffId);

            modelBuilder.Entity<Tariff>()
                .HasMany(t => t.TariffsForService)
                .WithOne(tFS => tFS.Tariff)
                .HasForeignKey(tFS => tFS.TariffId);

            modelBuilder.Entity<ClinicTariff>()
                .HasOne(c => c.Clinic)
                .WithOne(cT => cT.ClinicTariff)
                .HasForeignKey<ClinicTariff>(cT => cT.Id);

            modelBuilder.Entity<TariffForService>()
                .HasOne(tFS => tFS.Service)
                .WithMany(s => s.TariffForServices)
                .HasForeignKey(tFS => tFS.ServiceId);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.TransactionsLeftovers)
                .WithOne(tL => tL.Service)
                .HasForeignKey(tL => tL.ServiceId);

            modelBuilder.Entity<TransactionsLeftovers>()
                .HasOne(tL => tL.Clinic)
                .WithMany(c => c.TransactionsLeftovers)
                .HasForeignKey(tL => tL.ClinicId);

            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Doctors)
                .WithOne(d => d.Clinic)
                .HasForeignKey(d => d.ClinicId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Patients)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Payments)
                .WithOne(p => p.Clinic)
                .HasForeignKey(p => p.ClinicId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Bill)
                .WithOne(b => b.Payment)
                .HasForeignKey<Bill>(b => b.Id);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Inspections)
                .WithOne(i => i.Patient)
                .HasForeignKey(i => i.PatientId);

            modelBuilder.Entity<Inspection>()
                .HasOne(i => i.Mri)
                .WithOne(m => m.Inspection)
                .HasForeignKey<Mri>(m => m.Id);

            // TODO: разделить User Identity на другой микросервис.
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId);

            /*
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithOne(b => b.Post)
                .HasForeignKey<Post>(p => p.Id);*/
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
