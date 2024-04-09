


using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Authentication.Application.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        DbSet<ApplicationRole> ApplicationRoles { get; set; }

        IDbContextTransaction DatabaseBeginTransaction();
        Task SaveChangesAsync();
        DbSet<TEntity> set<TEntity>() where TEntity : class;

    }
}
