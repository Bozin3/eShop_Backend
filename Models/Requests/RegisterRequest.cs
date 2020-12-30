using System.ComponentModel.DataAnnotations;

namespace eShop_Backend.Models.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        public int? Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
