

using Microsoft.EntityFrameworkCore.Storage;

namespace CRM.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Company { get; }
        ICompanyIndustryRepository CompanyIndustry { get; }
        IActivityFeedRepository ActivityFeed { get; }
    
        ICampaignRepository Campaign { get; }
        IContactRepository Contact {  get; }
        Task CompleteAsync();
        IDbContextTransaction BeginTransaction();
    }
}
