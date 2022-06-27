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
    public class TransmissionController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public TransmissionController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }
        [HttpGet("TransmissionTypeList")]
        public async Task<List<TransmissionType>> TransmissionTypeList()
        {
            return await _rentaCarContext.TransmissionTypes.Select(t => new TransmissionType()
            {
                Id = t.Id,
                Type = t.Type,
            }).ToListAsync();
        }

        [HttpPost("SaveTrasmissionType")]
        public IActionResult SaveTrasmissionType(SaveTransmissionTypeDTO transmission)
        {
            var newtransmissionType = new TransmissionType
            {
                Type = transmission.Type
            };
            _rentaCarContext.TransmissionTypes.Add(newtransmissionType);
            _rentaCarContext.SaveChanges();
            return Ok(newtransmissionType);
        }

        [HttpGet("UpdateTransmissionType")]
        public IActionResult UpdateTransmissionType(int id)
        {
            var selectedTransmissionType = _rentaCarContext.TransmissionTypes.Where(t => t.Id == id).Select(o => new TransmissionType()
            {
                Id = o.Id,
                Type = o.Type
            }).FirstOrDefault();

            return Ok(selectedTransmissionType);
        }

        [HttpPost("UpdatedTransmissionType")]
        public IActionResult UpdatedTransmissionType(SaveTransmissionTypeDTO transmission, int id)
        {
            var updatedTransmissionType = _rentaCarContext.TransmissionTypes.SingleOrDefault(t => t.Id == id);


            updatedTransmissionType.Type = transmission.Type;

            _rentaCarContext.TransmissionTypes.Update(updatedTransmissionType);
            _rentaCarContext.SaveChanges();
            return Ok(updatedTransmissionType);
        }

        [HttpDelete("DeleteTrasmissionType")]
        public IActionResult DeleteTrasmissionType(int id)
        {

            var deletedTrasmission = _rentaCarContext.TransmissionTypes
                                   .Where(b => b.Id == id).FirstOrDefault();


            _rentaCarContext.TransmissionTypes.Remove(deletedTrasmission);
            _rentaCarContext.SaveChanges();
            return Ok(deletedTrasmission);

        }

    }
}
