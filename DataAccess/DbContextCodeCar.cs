using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbContextCodeCar:DbContext
    {
        //public DbContextCodeCar():base() {
        //    this.Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=CarRegions; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCarRegions();
            modelBuilder.SeedCarNumberCodes();
        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<CarNumberCode> CarNumberCodes { get; set; }
    }
}
