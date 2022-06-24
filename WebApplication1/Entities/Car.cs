using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Officies Officies { get; set; }
        public CarModal CarModal { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public Classification Classification { get; set; }
   
    }
}
