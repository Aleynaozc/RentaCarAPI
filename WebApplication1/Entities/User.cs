using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication1.Helpers;

namespace WebApplication1.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

    }
}
