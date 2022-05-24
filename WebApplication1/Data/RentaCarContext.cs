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
    }
}
