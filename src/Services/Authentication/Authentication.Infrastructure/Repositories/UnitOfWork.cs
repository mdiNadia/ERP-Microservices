
using Authentication.Application.Interfaces;
using Authentication.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
namespace Authentication.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IApplicationRoleRepository ApplicationRoles { get; private set; }
        public IApplicationUserRepository ApplicationUsers { get; private set; }


        public UnitOfWork(IApplicationDbContext context,IHttpContextAccessor httpContextAccessor)
        {

            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
            ApplicationRoles = new ApplicationRoleRepository(this._context, this._httpContextAccessor);
            ApplicationUsers = new ApplicationUserRepository(this._context, this._httpContextAccessor);


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

