using JobFinder.DataAccess.Contexts;
using JobFinder.DataAccess.Repositories.Abstracts;
using JobFinder.DataAccess.Repositories.Concretes;
using JobFinder.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobFinderPractic.Registers
{
    public static class ServiceRegistration
    {
        public static void AddDbContextServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("default")).UseLazyLoadingProxies();
            });

        }
        public static void AddRepositoryServices(this IServiceCollection collection)
        {
            collection.AddScoped<IJobRepository, JobRepository>();
            collection.AddScoped<UserRepository>();
        }

        public static void AddIdentityConfigureServices(this IServiceCollection collection)
        {
            collection.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
