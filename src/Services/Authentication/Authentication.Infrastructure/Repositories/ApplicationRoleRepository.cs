
using Authentication.Application.Interfaces;
using Authentication.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Authentication.Infrastructure.Repositories
{
    public class ApplicationRoleRepository : GenericRepository<ApplicationRole>, IApplicationRoleRepository
    {
        public ApplicationRoleRepository(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
