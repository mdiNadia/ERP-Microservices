using CRM.Aggregator.Extensions;

namespace CRM.Aggregator.Services.LeadManagement
{
    public class CompanyTypeService : ICompanyTypeService
    {
        private readonly HttpClient _client;
        public CompanyTypeService(HttpClient client)
        {
            _client = client;
        }
        public async Task<object> GetAll()
        {
            var response = await _client.GetAsync($"/api/v1/CompanyType");
            return await response.ReadContentAs<object>();
        }
    }
}
