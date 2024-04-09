

using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
