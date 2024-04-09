
using Authentication.Application.Interfaces;
using Authentication.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Authentication.Infrastructure.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
