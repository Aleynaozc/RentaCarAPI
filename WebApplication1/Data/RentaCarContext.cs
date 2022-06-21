using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
namespace WebApplication1.Data
{
    public class RentaCarContext:DbContext 
    {
        public RentaCarContext(DbContextOptions<RentaCarContext> opt): base(opt)
        {
                
        }
        public DbSet<Officies> Officies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModal> CarModals { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<RentedCar> RentedCars { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Admin> Admins{ get; set; }

    }
}
