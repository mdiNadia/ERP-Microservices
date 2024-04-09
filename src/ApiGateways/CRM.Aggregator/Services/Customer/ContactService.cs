using CRM.Aggregator.Extensions;
using CRM.Aggregator.Models.Customer;

namespace CRM.Aggregator.Services.Account
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _client;
        public ContactService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Create(CreateContact command)
        {
            var response = await _client.PostAsJsonAsync("/api/v1/Contact", command);
            if (response.StatusCode.Equals(200)) { return true; }
            return false;
        }

        public async Task<object> GetAll()
        {
            var response = await _client.GetAsync($"/api/v1/Contact");
            return await response.ReadContentAs<object>();
        }
        public async Task<object> GetById(int id)
        {
            var response = await _client.GetAsync($"/api/v1/Contact/{id}");
            return await response.ReadContentAs<object>();
        }
    }
}
