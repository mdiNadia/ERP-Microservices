using System.ComponentModel.DataAnnotations;

namespace Authentication.Application.Models.Authenticate
{
    public class ForgotPasswordModel
    {
        [Required]
        public string EmailOrPhoneNumber { get; set; }


    }
}
