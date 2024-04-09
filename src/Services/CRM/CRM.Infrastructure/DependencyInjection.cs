

using CRM.Application.Interfaces;
using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICRMDbContext>(provider => provider.GetService<CRMDbContext>());
            services.AddScoped<ICompanyIndustryRepository, CompanyIndustryRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IActivityFeedRepository, ActivityFeedRepository>();
      
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
