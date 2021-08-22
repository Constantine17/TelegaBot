using DataLayer.SQLite.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SQLiteApp
{
    public class ApplicationContext : DbContext
    {
        private static IMigrator migrator;

        private static ApplicationContext instance;
        public static ApplicationContext Instance
        {
            get
            {
                if (instance is null)
                    instance = new ApplicationContext();

                return instance;
            }
        }

        public string DbPath = string.Empty;
        public ApplicationContext() : base()
        {
            DbPath = $"./MBA_Bot.db";

            if (migrator is null)
            {
                var migrator = this.GetInfrastructure().GetService<IMigrator>();
                migrator.Migrate("Initial");
            }
        }

        public DbSet<ClientEntity> ClientEntities { get; set; }
        public DbSet<EventEntity> EventEntities { get; set; }
        public DbSet<ClientWithEventsEntity> ClientWithEventsEntities { get; set; }
        public DbSet<AdminEntity> AdminEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientWithEventsEntity>().HasKey(u => u.EventId);
        }
    }
}