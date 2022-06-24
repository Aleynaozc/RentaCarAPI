using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class CarModal
    {
        public CarModal()
        {
            Cars = new List<Car>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public string ImgURL2 { get; set; }
       
        public Brand Brand { get; set; }

        [JsonIgnore]
        public List<Car> Cars { get; set; }
    }
}
