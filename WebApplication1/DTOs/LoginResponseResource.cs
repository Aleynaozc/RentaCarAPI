using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class LoginResponseResource
    {
        public string Token { get; set; }
        public int Role { get; set; }
        public int UserId { get; set; }
    }
}
