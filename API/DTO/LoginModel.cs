using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
    }
}
