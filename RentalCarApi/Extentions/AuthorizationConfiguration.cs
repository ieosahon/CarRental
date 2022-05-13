using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RentalCarCore.Utilities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarApi.Extentions
{
    public static class AuthorizationConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["JWTSettings:Audience"],
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };

                // an event to let us know if jwt access token has expired

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = response =>
                    {
                        if (response.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            response.Response.Headers.Add("Is-token-expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };

            });

            services.AddAuthorization(options =>
                    options.AddPolicy("RequireAdminOnly", policy => policy.RequireRole(UserRoles.Admin)))
                .AddAuthorization(options => options.AddPolicy("RequireDealerOnly", policy => policy.RequireRole(UserRoles.Dealer)))
                .AddAuthorization(options => options.AddPolicy("RequireCustomerOnly", policy => policy.RequireRole(UserRoles.Customer)))
                .AddAuthorization(options => options.AddPolicy("RequireDealerAndCustomer", policy => policy.RequireRole(UserRoles.Dealer, UserRoles.Admin)));
        }

    }
}