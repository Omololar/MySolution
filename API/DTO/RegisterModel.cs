using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User name is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }
}
