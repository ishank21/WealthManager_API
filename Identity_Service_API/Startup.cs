using ApplicationCore;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using ApplicationInfrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Identity_Service_API
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        private IConfiguration _config;
        /// <summary>
        /// Startup Constructor
        /// </summary>
        /// <param name="config"></param>
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<DBcontext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
            services.AddApplicationCore();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            //services.AddScoped<ILog, Log>();
            services.AddControllers();
            services.AddHttpClient();
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(x=> {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Wealth Manager API",
                    Description = "API'S"
                });
                //x.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "IdentityServiceAPI.xml"));
            });
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.Authority = "https://dev-56518799.okta.com/oauth2/default";
            //    options.Audience = "api://default";
            //    options.RequireHttpsMetadata = false;
            //});
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            //app.UseEndpoints(endpoints => {
            //    endpoints.MapControllers();
            //});
            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseMvc();
        }
    }
}
