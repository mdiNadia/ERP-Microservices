

using Authentication.Application.Interfaces;
using Authentication.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Authentication.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public IDbContextTransaction DatabaseBeginTransaction() { return Database.BeginTransaction(); }
        public DbSet<TEntity> set<TEntity>() where TEntity : class { return Set<TEntity>(); }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration<ApplicationUser>(new UserBuilder());
            
            base.OnModelCreating(builder);
        }
        Task IApplicationDbContext.SaveChangesAsync()
        {
            return SaveChangesAsync();
        }
    }
}
