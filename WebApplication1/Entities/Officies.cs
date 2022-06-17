using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Officies
    {
        public Officies()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; }
        public string? Slug { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public List<Car> Cars { get; set; }
    }
}
