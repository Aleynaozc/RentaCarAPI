using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class FuelTypeController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public FuelTypeController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }
        [HttpGet("FuelTypeList")]
        public async Task<List<FuelType>> FuelTypeList()
        {
            return await _rentaCarContext.FuelTypes.Select(f => new FuelType()
            {
                Id = f.Id,
                Type = f.Type,
            }).ToListAsync();
        }

        [HttpPost("SaveFuelType")]
        public IActionResult SaveFuelType(SaveFuelTypeDTO fuelType)
        {
            var newfuelType = new FuelType
            {
                Type = fuelType.Type
            };
            _rentaCarContext.FuelTypes.Add(newfuelType);
            _rentaCarContext.SaveChanges();
            return Ok(newfuelType);
        }

        [HttpGet("UpdateFuelType")]
        public IActionResult UpdateFuelType(int id)
        {
            var selectedFuelType = _rentaCarContext.FuelTypes.Where(f => f.Id == id).Select(o => new FuelType()
            {
                Id = o.Id,
                Type = o.Type
            }).FirstOrDefault();

            return Ok(selectedFuelType);
        }

        [HttpPost("UpdatedFuelType")]
        public IActionResult UpdatedFuelType(SaveFuelTypeDTO fueltype, int id)
        {
            var updatedFuelType = _rentaCarContext.FuelTypes.SingleOrDefault(f => f.Id == id);


            updatedFuelType.Type = fueltype.Type;

            _rentaCarContext.FuelTypes.Update(updatedFuelType);
            _rentaCarContext.SaveChanges();
            return Ok(updatedFuelType);
        }

        [HttpDelete("DeleteFuelType")]
        public IActionResult DeleteFuelType(int id)
        {

            var deletedFuelType = _rentaCarContext.FuelTypes
                                   .Where(b => b.Id == id).FirstOrDefault();


            _rentaCarContext.FuelTypes.Remove(deletedFuelType);
            _rentaCarContext.SaveChanges();
            return Ok(deletedFuelType);

        }

    }
}
