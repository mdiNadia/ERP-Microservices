using CRM.Aggregator.Extensions;
using CRM.Aggregator.Models.Marketing;

namespace CRM.Aggregator.Services.Marketing
{
    public class CampaignTypeService : ICampaignTypeService
    {
        private readonly HttpClient _client;
        public CampaignTypeService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Create(CreateCampaignType command)
        {
            var response = await _client.PostAsJsonAsync("/api/v1/CampaignType", command);
            if (response.StatusCode.Equals(200)) { return true; }
            return false;
        }

        public async Task<object> GetAll()
        {
            var response = await _client.GetAsync($"/api/v1/CampaignType");
            return await response.ReadContentAs<object>();
        }
        public async Task<List<GetLookup<int>>> GetLookup()
        {
            var response = await _client.GetAsync($"/api/v1/CampaignType/GetLookup");
            return await response.ReadContentAs<List<GetLookup<int>>>();
        }
        public async Task<object> GetById(int id)
        {
            var response = await _client.GetAsync($"/api/v1/CampaignType/{id}");
            return await response.ReadContentAs<object>();
        }
    }
}
