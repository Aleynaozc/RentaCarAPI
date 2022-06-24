using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.DTOs
{
    public class SaveCarModalDTO
    {
        public string Name { get; set; }
        public string ImgURL { get; set; }
        public string ImgURL2 { get; set; }
        public int BrandId { get; set; }
    }
}
