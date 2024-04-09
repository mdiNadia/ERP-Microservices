using CRM.Aggregator.Extensions;
using CRM.Aggregator.Models.Marketing;

namespace CRM.Aggregator.Services.Marketing
{
    public class CampaignService : ICampaignService
    {
        private readonly HttpClient _client;
        public CampaignService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Create(CreateCampaign command)
        {
            var response = await _client.PostAsJsonAsync("/api/v1/Campaign", command);
            if (response.StatusCode.Equals(200)) { return true; }
            return false;
        }

        public async Task<object> GetAll()
        {
            var response = await _client.GetAsync($"/api/v1/Campaign");
            return await response.ReadContentAs<object>();
        }
        public async Task<object> GetById(int id)
        {
            var response = await _client.GetAsync($"/api/v1/Campaign/{id}");
            return await response.ReadContentAs<object>();
        }
    }
}
