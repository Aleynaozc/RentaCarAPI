using Microsoft.AspNetCore.Authorization;
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
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
   
    [Route("api/[controller]")]
    [Authorize(Policy = "UserPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RentaCarContext _rentaCarContext;
        private readonly JWTService _jwtService;
        public UserController(RentaCarContext rentaCarContext , JWTService jwtService)
        {
            _rentaCarContext = rentaCarContext;
            _jwtService = jwtService; 
        }
        //[AllowAnonymous]
        //[HttpPost("Register")]
        //public IActionResult Register(User users)
        //{
        //    var user = new User
        //    {
        //        FullName = users.FullName,
        //        Email = users.Email,
        //        Password = BCrypt.Net.BCrypt.HashPassword(users.Password)
        //    };
        //    _rentaCarContext.Users.Add(user);
        //    _rentaCarContext.SaveChanges();
        //    return Ok(user);
        //    //return Created(uri: "success", value: (_rentaCarContext.Users.Add(user)user.Id = _rentaCarContext.SaveChanges()));
        
        //}
        //[HttpPost("Login")]
        //public IActionResult Login([FromBody] LoginDTO values)
        //{
        //    var user = _rentaCarContext.Users.FirstOrDefault(e => e.Email == values.Email);

        //    if (user == null) return BadRequest(error: new { message = "Invalid Credantials" });
        //    if (!BCrypt.Net.BCrypt.Verify(values.Password, user.Password))
        //    {
        //        return BadRequest(error: new { message = "invalid credantials" });

        //    };
        //    var jwt =_jwtService.Generate(user.Id);
        //    //HttpContext.Response.Cookies.Append(key: "jwt", value: jwt, new CookieOptions
        //    //{
        //    //    HttpOnly = true
        //    //});

        //    return Ok(jwt);
        //}
        //[HttpGet("User")]
        //public IActionResult User()
        //{
        //    try
        //    {
        //        var jwt= Request.Cookies["jwt"];
        //        var token = _jwtService.Verify(jwt);
        //        int userId = int.Parse(token.Issuer);
        //        var user = _rentaCarContext.Users.FirstOrDefault(e => e.Id == userId);
        //        return Ok(user);
        //    }
        //  catch (Exception _)
        //    {
        //        return Unauthorized();
        //    }
           
        //}
        //[HttpPost("Logout")]
        //public IActionResult Logout()
        //{
        //    Response.Cookies.Delete(key: "jwt");
        //    return Ok (new
        //    {
        //        message = "success"
        //    });
                
        //}
    }

   
}
