using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Brand
    {
        public Brand()
        {
            CarModals = new List<CarModal>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<CarModal> CarModals { get; set; }

    }
}
