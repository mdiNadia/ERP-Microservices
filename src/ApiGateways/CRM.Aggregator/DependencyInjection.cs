
using CRM.Aggregator.Services.Account;
using CRM.Aggregator.Services.LeadManagement;
using CRM.Aggregator.Services.Marketing;
using CRM.Aggregator.Services.User;
using Microsoft.Extensions.DependencyInjection;



namespace CRM.Aggregator
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            const string AuthUrl = "ApiSettings:Authentication";
            const string CRMUrl = "ApiSettings:CRM";
            services.AddHttpClient<IUserService, UserService>(c =>
           c.BaseAddress = new Uri(configuration[AuthUrl])
                   );
            services.AddHttpClient<IAccountService, AccountService>(c =>
                c.BaseAddress = new Uri(configuration[AuthUrl])
            );
            services.AddHttpClient<ILeadService, LeadService>(c =>
                c.BaseAddress = new Uri(configuration[CRMUrl])
            );
            services.AddHttpClient<ICompanyTypeService, CompanyTypeService>(c =>
                c.BaseAddress = new Uri(configuration[CRMUrl])
            );
            services.AddHttpClient<IActivityTypeService, ActivityTypeService>(c =>
                c.BaseAddress = new Uri(configuration[CRMUrl])
            );
            services.AddHttpClient<ICampaignTypeService, CampaignTypeService>(c =>
                c.BaseAddress = new Uri(configuration[CRMUrl])
            );
            services.AddHttpClient<ICampaignService, CampaignService>(c =>
                c.BaseAddress = new Uri(configuration[CRMUrl])
             );
            services.AddHttpClient<IContactService, ContactService>(c =>
            c.BaseAddress = new Uri(configuration[CRMUrl])
         );

        }
    }
}
