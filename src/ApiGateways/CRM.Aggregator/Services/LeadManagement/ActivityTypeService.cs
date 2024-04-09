using CRM.Aggregator.Extensions;

namespace CRM.Aggregator.Services.LeadManagement
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly HttpClient _client;
        public ActivityTypeService(HttpClient client)
        {
            _client = client;
        }
        public async Task<object> GetAll()
        {
            var response = await _client.GetAsync($"/api/v1/ActivityType");
            return await response.ReadContentAs<object>();
        }
    }
}
