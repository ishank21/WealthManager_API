using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using ApplicationInfrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DBcontext>(options => 
            options.UseSqlServer(defaultConnectionString));
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            return services;
        }
     }
}