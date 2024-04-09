
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CRM.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));



        }
    }
}
