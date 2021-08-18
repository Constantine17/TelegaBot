using System;
using Microsoft.EntityFrameworkCore.Sqlite;
using DataLayer.SQLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace SQLiteApp
{
    public class ApplicationContext : DbContext
    {
        public string DbPath = string.Empty;
        public ApplicationContext() : base()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}MBA_Bot.db";
        }
        public DbSet<ClientEntity> ClientEntities { get; set; }
        public DbSet<EventEntity> EventEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source={DbPath}");
    }
}