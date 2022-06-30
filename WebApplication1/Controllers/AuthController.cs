using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly RentaCarContext _rentaCarContext;
        private readonly IConfiguration _config;

        public AuthController(RentaCarContext rentaCarContext, IConfiguration config)
        {
            _rentaCarContext = rentaCarContext;
            _config = config;
        }
       
        [HttpPost("Userlogin")]
        public async Task<IActionResult> UserLogin([FromBody] LoginDTO loginResource )
        {
            var findedUser = _rentaCarContext.Users.FirstOrDefault(e => e.Email == loginResource.Email);
            if (findedUser == null)
                return BadRequest("Kullanıcı bulunamadı!");

            if (!BCrypt.Net.BCrypt.Verify(loginResource.Password, findedUser.Password))
                return BadRequest("Kullanıcı adı veya şifre hatalı!");



            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "rentacar",
                Issuer = "issuer",
                Subject = new ClaimsIdentity(
                    new Claim[]{
                             new Claim(ClaimTypes.Name, findedUser.FullName),
                              new Claim(ClaimTypes.Email, findedUser.Email),
                             new Claim("Role", findedUser.Role.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(ResponseResource.GenerateResponse(new LoginResponseResource() { Token = tokenString, Role = (int)findedUser.Role , UserId = findedUser.Id}));
        }

        [HttpPost("Adminlogin")]
        public async Task<IActionResult> AdminLogin([FromBody] AdminLoginDTO adminLoginResource)
        {
            var findedAdmin = _rentaCarContext.Admins.FirstOrDefault(e => e.FullName == adminLoginResource.FullName);
            if (findedAdmin == null)
                return BadRequest("Kullanıcı bulunamadı!");

            //if (!BCrypt.Net.BCrypt.Verify(adminLoginResource.Password, findedAdmin.Password))
            //    return BadRequest("Kullanıcı adı veya şifre hatalı!");



            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "rentacar",
                Issuer = "issuer",
                Subject = new ClaimsIdentity(
                    new Claim[]{
                             new Claim(ClaimTypes.Name, findedAdmin.FullName),
                             new Claim("Role", findedAdmin.Role.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(ResponseResource.GenerateResponse(new LoginResponseResource() { Token = tokenString, Role = (int)findedAdmin.Role }));
        }
    }
}
