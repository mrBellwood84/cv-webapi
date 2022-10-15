using Application;
using Application.DataService;
using Identity.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers(opts =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); ;
                opts.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDbContext<IdentityContext>(opts => opts.UseSqlite(config.GetConnectionString("default")));
            services.AddDbContext<DataContext>(opts => opts.UseSqlite(config.GetConnectionString("default")));

            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(config["FrontEndApp"]);
                });
            });

            services.AddScoped<IDataService, DataService>();

            return services;

        }
    }
}
