using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public BrandController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }

        [HttpPost("SaveBrand")]
        public IActionResult SaveBrand(SaveBrandDTO brand)
        {
            var newbrand = new Brand
            {
                Name = brand.Name
            };
            _rentaCarContext.Brands.Add(newbrand);
            _rentaCarContext.SaveChanges();
            return Ok(newbrand);
        }

        [HttpGet("UpdateBrand")]
        public IActionResult UpdateBrand(int id)
        {
            var selectedBrand = _rentaCarContext.Brands.Where(c => c.Id == id).Select(o => new Brand()
            {
                Id = o.Id,
                Name = o.Name
            }).FirstOrDefault();

            return Ok(selectedBrand);
        }

        [HttpPost("UpdatedBrand")]
        public IActionResult UpdatedBrand(SaveBrandDTO brand, int id)
        {
            var updatedBrand = _rentaCarContext.Brands.SingleOrDefault(b => b.Id == id);


            updatedBrand.Name = brand.Name;

            _rentaCarContext.Brands.Update(updatedBrand);
            _rentaCarContext.SaveChanges();
            return Ok(updatedBrand);
        }

        [HttpDelete("DeleteBrand")]
        public IActionResult DeleteBrand(int id)
        {

            var deletedBrand = _rentaCarContext.Brands
                                   .Where(b => b.Id == id).FirstOrDefault();


            _rentaCarContext.Brands.Remove(deletedBrand);
            _rentaCarContext.SaveChanges();
            return Ok(deletedBrand);

        }
    }
}
