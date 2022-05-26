using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentaCarController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public RentaCarController (RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
        }

        [HttpGet]
        public async Task<List<Officies>> Get()
        {
            return await _rentaCarContext.Officies.ToListAsync();

        }

        [HttpGet("reservation")]
        public async Task<List<Car>> Get(int? id)
        {

            return await _rentaCarContext.Cars.Where(o => o.Officies.Id == id)
                                        .Include(o => o.FuelType)
                                        .Include(o => o.TransmissionType )
                                        .Include(o => o.Brand)
                                       
                                        .Include(o => o.Classification)
                                        .Select(o =>
                                          new Car()
                                          {
                                              Id = o.Id,
                                              Price=o.Price,
                                              ImgURL=o.ImgURL,

                                              FuelType=o.FuelType,
                                              TransmissionType=o.TransmissionType,
                                              Brand = o.Brand,
                                              Classification = o.Classification,
                                            


                                          }
                                        )
                .ToListAsync();
        }



    }
}
