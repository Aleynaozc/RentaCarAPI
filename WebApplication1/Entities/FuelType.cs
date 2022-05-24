﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class FuelType
    {
        public FuelType()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Car> Cars { get; set; }
    }
}
