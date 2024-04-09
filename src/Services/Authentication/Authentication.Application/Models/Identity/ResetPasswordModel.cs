using System.ComponentModel.DataAnnotations;

namespace Authentication.Application.Models.Authenticate
{
    public class ResetPasswordModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string token { get; set; }
    }
}
