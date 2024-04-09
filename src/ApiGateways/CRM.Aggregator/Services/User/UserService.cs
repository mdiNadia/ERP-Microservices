using CRM.Aggregator.Extensions;
using CRM.Aggregator.Models;
using CRM.Aggregator.Models.Marketing;

namespace CRM.Aggregator.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        public UserService(HttpClient client)
        {
            _client = client;
        }
        public async Task<object> GetAll()
        {
            var response = await _client.GetAsync("/api/v1/User");
            return await response.ReadContentAs<object>();
        }

        public async Task<List<GetLookup<string>>> GetLookupByParentId(string id)
        {
            var response = await _client.GetAsync($"/api/v1/User/GetLookup/{id}");
            return await response.ReadContentAs<List<GetLookup<string>>>();
        }
    }
}
