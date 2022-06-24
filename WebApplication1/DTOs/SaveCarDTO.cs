using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class SaveCarDTO
    {
        public double Price { get; set; }
        public int CarModalID { get; set; }
        public int OfficiesID { get; set; }
        public int TransmissionID { get; set; }
        public int FuelTypeID { get; set; }
        public int ClassificationID { get; set; }
    }
}
