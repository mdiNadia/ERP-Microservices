
using Microsoft.EntityFrameworkCore.Storage;

namespace Authentication.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationRoleRepository ApplicationRoles { get; }
        IApplicationUserRepository ApplicationUsers { get; }

        Task CompleteAsync();
        IDbContextTransaction BeginTransaction();
    }
}
