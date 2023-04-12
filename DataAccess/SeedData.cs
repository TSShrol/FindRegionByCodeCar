using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class SeedData
    {
        public static void SeedCarRegions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(new Region[]
            {
 new Region() {Id=1, NameRegion="Рівненська"},
 new Region() {Id=2, NameRegion="Волинська"},
 new Region() {Id=3, NameRegion="Житомирська"},
 new Region() {Id=4, NameRegion="Львівська"}
            });
        }
        public static void SeedCarNumberCodes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarNumberCode>().HasData(new CarNumberCode[]
            {
 new CarNumberCode() {Id=1, Code="BK", RegionId=1},
 new CarNumberCode() {Id=2, Code="HK", RegionId=1},
 new CarNumberCode() {Id=3, Code="AC", RegionId=2},
 new CarNumberCode() {Id=4, Code="KC", RegionId=2},
 new CarNumberCode() {Id=5, Code="AM", RegionId=3},
 new CarNumberCode() {Id=6, Code="KM", RegionId=3},
 new CarNumberCode() {Id=7, Code="BC", RegionId=4},
 new CarNumberCode() {Id=8, Code="HC", RegionId=4}
            });
        }
    }
}
