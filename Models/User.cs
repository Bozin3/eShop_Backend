using System;
using System.Collections.Generic;

#nullable disable

namespace eShop_Backend.Models
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? Age { get; set; }
        public int? Role { get; set; }
        public string PhotoUrl { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
