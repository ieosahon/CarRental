using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.Models;

namespace RentalCarApi.Extentions
{
    public static class IdentityConfiguration
    {
        public static void RegisterIdentityUser(this IServiceCollection services, IConfiguration cofig)
        {
            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.SignIn.RequireConfirmedEmail = true;
                x.Password.RequireUppercase = true;
                x.Password.RequireDigit = true;
                x.Password.RequiredUniqueChars = 1;
                x.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}
