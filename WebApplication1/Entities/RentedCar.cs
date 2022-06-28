using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class RentedCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public User User { get; set; }
        public DateTime StartTimeAndDate { get; set; }
        public DateTime EndTimeAndDate { get; set; }
    }
}
