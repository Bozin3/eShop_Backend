using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop_Backend.Models.Auth
{
    public class RegisterRequest
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
