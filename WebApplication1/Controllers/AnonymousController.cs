using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;
using WebApplication1.Helpers;

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
                Password = BCrypt.Net.BCrypt.HashPassword(users.Password),
                 Role = UserRole.USER
            };
            _rentaCarContext.Users.Add(user);
            _rentaCarContext.SaveChanges();
            return Ok(user);
           

        }
        [HttpPost("AdminRegister")]
        public IActionResult AdminRegister(SaveUserDTO users)
        {
            var admin = new Admin
            {
                FullName = users.FullName,
              
                Password = BCrypt.Net.BCrypt.HashPassword(users.Password)
            };
            _rentaCarContext.Admins.Add(admin);
            _rentaCarContext.SaveChanges();
            return Ok(admin);
        }
    }
}
