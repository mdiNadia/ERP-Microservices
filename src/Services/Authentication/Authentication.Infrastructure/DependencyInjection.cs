


using Authentication.Application.Interfaces;
using Authentication.Infrastructure.Context;
using Authentication.Infrastructure.Repositories;
using Common.Infrastructure.Services.Email;
using Common.Infrastructure.Services.FileStorage;
using Common.Infrastructure.Services.SMS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
           
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ISmsSender, SmsSender>();
            services.AddScoped<IFileUploader, FileUploader>();


            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IApplicationRoleRepository, ApplicationRoleRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
