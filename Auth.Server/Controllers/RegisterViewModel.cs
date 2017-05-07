using System.ComponentModel.DataAnnotations;

namespace Auth.Server.Controllers
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}