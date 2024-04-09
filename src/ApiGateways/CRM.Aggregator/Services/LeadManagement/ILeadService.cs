using CRM.Aggregator.Models;
using DevExtreme.AspNet.Mvc;

namespace CRM.Aggregator.Services.LeadManagement
{
    public interface ILeadService
    {
        Task<object> GetAll();

    }
}
