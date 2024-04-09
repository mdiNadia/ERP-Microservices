
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace CRM.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICRMDbContext _context;
        public ICompanyRepository Company { get; private set; }
        public ICompanyIndustryRepository CompanyIndustry { get; private set; }
        public IActivityFeedRepository ActivityFeed { get; private set; }
        public ICampaignRepository Campaign { get; private set; }

        public IContactRepository Contact { get; private set; }
        public UnitOfWork(ICRMDbContext context)
        {

            this._context = context;
            Company = new CompanyRepository(this._context);
            CompanyIndustry = new CompanyIndustryRepository(this._context);
            ActivityFeed = new ActivityFeedRepository(this._context);
            Campaign = new CampaignRepository(this._context);
            Contact = new ContactRepository(this._context);
        }
        public async Task CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.DatabaseBeginTransaction();
        }


    }
}

