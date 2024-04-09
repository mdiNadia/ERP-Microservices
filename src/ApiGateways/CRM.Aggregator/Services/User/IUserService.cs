using CRM.Aggregator.Models;
using CRM.Aggregator.Models.Marketing;

namespace CRM.Aggregator.Services.User
{
    public interface IUserService
    {
        Task<object> GetAll();
        Task<List<GetLookup<string>>> GetLookupByParentId(string id);

    }
}
