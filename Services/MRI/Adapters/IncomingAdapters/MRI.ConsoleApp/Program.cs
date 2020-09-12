using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MRI.Domain.Entities;
using MRI.PostgresRepository;
using System;
using System.IO;

namespace MRI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var contextFactory = new MriDbContextFactory();

            using (var db = contextFactory.CreateDbContext(null))
            {
                //var tariff = new Tariff(1,"probName1", 1, false, "first prob", 1);
                var blog = new Blog { Url = "ProbUrl" };
                db.Add(blog);
                db.SaveChanges();
            }
        }
    }
    public class MriDbContextFactory : IDesignTimeDbContextFactory<MriDbContext>
    {
        public MriDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("Postgres");

            var optionsBuilder = new DbContextOptionsBuilder<MriDbContext>()
                .UseNpgsql(connectionString);

            return new MriDbContext(optionsBuilder.Options);
        }
    }
}
