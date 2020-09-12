using Microsoft.EntityFrameworkCore;
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
            /*
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithOne(b => b.Post)
                .HasForeignKey<Post>(p => p.Id);*/
        }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=probdb2;Username=postgres;Password=erik86kam13");
        }*/
    }
}
