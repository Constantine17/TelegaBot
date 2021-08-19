using DataLayer.SQLite.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace SQLiteApp
{
    public class ApplicationContext : DbContext
    {
        public string DbPath = string.Empty;
        public ApplicationContext() : base()
        {
            DbPath = $"./MBA_Bot.db";
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