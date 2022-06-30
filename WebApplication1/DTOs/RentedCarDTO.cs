using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class RentedCarDTO
    {
        public int CarID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


    }
}
