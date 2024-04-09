
using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string ParentId { get; set; } = string .Empty;
        public ApplicationUser Parent { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string NumCode { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public List<RefreshToken> RefreshTokens { get; set; }


    }
}
