using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Brand
    {
        public Brand()
        {
            Cars = new List<Car>();
           CarModals = new List<CarModal>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Car> Cars { get; set; }
        public List<CarModal> CarModals { get; set; }
    }
}
