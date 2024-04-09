using CRM.Aggregator.Models.Marketing;

namespace CRM.Aggregator.Services.Marketing
{
    public interface ICampaignTypeService
    {
        Task<object> GetAll();
        Task<List<GetLookup<int>>> GetLookup();
        Task<object> GetById(int id);
        Task<bool> Create(CreateCampaignType command);
    }
}
