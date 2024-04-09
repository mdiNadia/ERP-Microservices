using CRM.Aggregator.Extensions;
using CRM.Aggregator.Models;
using DevExtreme.AspNet.Mvc;

namespace CRM.Aggregator.Services.LeadManagement
{
    public class LeadService : ILeadService
    {
        private readonly HttpClient _client;
        public LeadService(HttpClient client)
        {
            _client = client;
        }
        public async Task<object> GetAll()
        {
            var response = await _client.GetAsync($"/api/v1/Lead");
            return await response.ReadContentAs<object>();
        }
    }
}
