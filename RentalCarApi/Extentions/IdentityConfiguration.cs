using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalCarCore.Dtos.Mapping;
using RentalCarCore.Implementations;
using RentalCarCore.Interfaces;
using RentalCarCore.Services;
using RentalCarCore.Utilities;
using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.ModelImage;
using RentalCarInfrastructure.ModelMail;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Implementations;
using RentalCarInfrastructure.Repositories.Interfaces;

namespace RentalCarApi.Extentions
{
    public static class IdentityConfiguration
    {
        public static void RegisterIdentityUser(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.SignIn.RequireConfirmedEmail = true;
                x.Password.RequireUppercase = true;
                x.Password.RequireDigit = true;
                x.Password.RequiredUniqueChars = 1;
                x.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IImageService, ImageService>();
            services.Configure<ImageUploadSettings>(config.GetSection("ImageUploadSettings"));
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<ITokenGen, TokenGen>();
            services.AddAutoMapper(typeof(UserMappings));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }
    }
}