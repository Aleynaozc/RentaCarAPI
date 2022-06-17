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
    public class AnonymousController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        public AnonymousController(RentaCarContext rentaCarContext)
        {
            _rentaCarContext = rentaCarContext;
            
        }
        [HttpPost("Register")]
        public IActionResult Register(SaveUserDTO users)
        {
            var user = new User
            {
                FullName = users.FullName,
                Email = users.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(users.Password)
            };
            _rentaCarContext.Users.Add(user);
            _rentaCarContext.SaveChanges();
            return Ok(user);
           

        }
    }
}
