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
    public class OfficiesController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public OfficiesController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }

        [HttpPost("SaveOfficies")]
        public IActionResult SaveOfficies(SaveOfficiesDTO officies)
        {
            var newofficies = new Officies
            {
                Name = officies.Name,
                City = officies.City
            };
            _rentaCarContext.Officies.Add(newofficies);
            _rentaCarContext.SaveChanges();
            return Ok(newofficies);
        }

        [HttpGet("UpdateOfficies")]
        public IActionResult UpdateOfficies(int id)
        {
            var selectedOfficies = _rentaCarContext.Officies.Where(o => o.Id == id).Select(o => new Officies()
            {
                Id = o.Id,
                Name = o.Name,
                City = o.City
            }).FirstOrDefault();

            return Ok(selectedOfficies);
        }

        [HttpPost("UpdatedOfficies")]
        public IActionResult UpdatedOfficies(SaveOfficiesDTO officies, int id)
        {
            var updatedOfficies = _rentaCarContext.Officies.SingleOrDefault(o => o.Id == id);


            updatedOfficies.Name = officies.Name;
            updatedOfficies.City = officies.City;

            _rentaCarContext.Officies.Update(updatedOfficies);
            _rentaCarContext.SaveChanges();
            return Ok(updatedOfficies);
        }

        [HttpDelete("DeleteOfficies")]
        public IActionResult DeleteOfficies(int id)
        {

            var deletedOfficies = _rentaCarContext.Officies
                                   .Where(b => b.Id == id).FirstOrDefault();


            _rentaCarContext.Officies.Remove(deletedOfficies);
            _rentaCarContext.SaveChanges();
            return Ok(deletedOfficies);

        }
    }
}
