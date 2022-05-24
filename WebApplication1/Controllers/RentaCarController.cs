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
    }
}
