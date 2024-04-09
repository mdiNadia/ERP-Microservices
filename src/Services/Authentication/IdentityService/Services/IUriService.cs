
using IdentityService.Filter;

namespace IdentityService.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
