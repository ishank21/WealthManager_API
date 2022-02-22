using ApplicationCore;
using ApplicationCore.Interfaces;
using ApplicationInfrastructure.Context;
using ApplicationInfrastructure.JWT;
using ApplicationInfrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddHttpClient();
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Wealth Manager API",
                    Description = "API'S"
                });
                x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
        }
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

            //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtIssuerOptions:Key"]));

            //            var jwtAppSettingsOptions = _config.GetSection(nameof(JwtIssuerOptions));
            //            services.Configure<JwtIssuerOptions>(options =>
            //            {
            //                options.Issuer = jwtAppSettingsOptions[nameof(JwtIssuerOptions.Issuer)];
            //                options.Audience = jwtAppSettingsOptions[nameof(JwtIssuerOptions.Audience)];
            //                options.SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //            });
            //            var tokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidIssuer = jwtAppSettingsOptions[nameof(JwtIssuerOptions.Issuer)],
            //                ValidateAudience = true,
            //                ValidAudience = jwtAppSettingsOptions[nameof(JwtIssuerOptions.Audience)],
            //                ValidateIssuerSigningKey = true,
            //                IssuerSigningKey = key,
            //                RequireExpirationTime = false,
            //                ValidateLifetime = true,
            //                ClockSkew = TimeSpan.Zero
            //            };

            //            services.AddAuthentication(options =>
            //            {
            //                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //            })
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = tokenValidationParameters;
            //    options.Audience = jwtAppSettingsOptions[nameof(JwtIssuerOptions.Audience)];
            //    options.RequireHttpsMetadata = bool.Parse(jwtAppSettingsOptions[nameof(JwtIssuerOptions.RequireHttpsMetadata)]);
            //});



            //#region "JWT Token For Authentication Login"    
            Keys.Configure(_config.GetSection("AppSettings"));
            var key = Encoding.ASCII.GetBytes(Keys.Token);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });


            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(token =>
             {
                 token.RequireHttpsMetadata = false;
                 token.SaveToken = true;
                 token.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = true,
                     ValidIssuer = Keys.WebSiteDomain,
                     ValidateAudience = true,
                     ValidAudience = Keys.WebSiteDomain,
                     RequireExpirationTime = true,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero
                 };
             });

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
