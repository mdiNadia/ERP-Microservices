using System.ComponentModel.DataAnnotations;

namespace Authentication.Application.Models.Identity.JWT
{
    public class TokenRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
