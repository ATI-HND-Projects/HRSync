using AuthLayer.Model;
using DataAccessLayer.Data;
using DataAccessLayer.Interface;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DataAccessServiceConfig
    {
        public static IServiceCollection ConfigureDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IRoleServices, RoleServices>();

            return services;
        }

    }
}
