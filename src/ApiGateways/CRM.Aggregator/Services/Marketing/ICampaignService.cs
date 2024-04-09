using CRM.Aggregator.Models.Marketing;

namespace CRM.Aggregator.Services.Marketing
{
    public interface ICampaignService
    {
        Task<object> GetAll();
        Task<object> GetById(int id);
        Task<bool> Create(CreateCampaign command);
    }
}
