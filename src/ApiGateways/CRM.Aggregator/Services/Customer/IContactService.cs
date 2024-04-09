using CRM.Aggregator.Models.Customer;
using CRM.Aggregator.Models.Marketing;

namespace CRM.Aggregator.Services.Account
{
    public interface IContactService
    {
        Task<object> GetAll();
        Task<object> GetById(int id);
        Task<bool> Create(CreateContact command);
    }
}
