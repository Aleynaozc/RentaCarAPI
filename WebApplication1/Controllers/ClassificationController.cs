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
    public class ClassificationController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public ClassificationController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }
        [HttpGet("ClassificationList")]
        public async Task<List<Classification>> ClassificationList()
        {
            return await _rentaCarContext.Classifications.Select(u => new Classification()
            {
                Id = u.Id,
                Type = u.Type,
            }).ToListAsync();
        }
        [HttpPost("SaveClassification")]
        public IActionResult SaveClassification(SaveClassificationDTO clas)
        {
            var newClassifification = new Classification
            {
                Type = clas.Type
            };
            _rentaCarContext.Classifications.Add(newClassifification);
            _rentaCarContext.SaveChanges();
            return Ok(newClassifification);
        }



        [HttpGet("UpdateClassification")]
        public IActionResult UpdateClassification(int id)
        {
            var selectedClassification = _rentaCarContext.Classifications.Where(f => f.Id == id).Select(o => new Classification()
            {
                Id = o.Id,
                Type = o.Type
            }).FirstOrDefault();

            return Ok(selectedClassification);
        }

        [HttpPost("UpdatedClassification")]
        public IActionResult UpdatedClassification(SaveFuelTypeDTO fueltype, int id)
        {
            var updatedClassification = _rentaCarContext.Classifications.SingleOrDefault(f => f.Id == id);


            updatedClassification.Type = fueltype.Type;

            _rentaCarContext.Classifications.Update(updatedClassification);
            _rentaCarContext.SaveChanges();
            return Ok(updatedClassification);
        }

        [HttpDelete("DeleteClassification")]
        public IActionResult DeleteClassification(int id)
        {

            var deletedClassification = _rentaCarContext.Classifications
                                   .Where(b => b.Id == id).FirstOrDefault();


            _rentaCarContext.Classifications.Remove(deletedClassification);
            _rentaCarContext.SaveChanges();
            return Ok(deletedClassification);

        }
    }
}
