using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Classification
    {
        public Classification()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public List<Car> Cars { get; set; }
    }
}
