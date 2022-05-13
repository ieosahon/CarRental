using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentalCarInfrastructure.Context;
using System;

namespace RentalCarApi.Extentions
{
    public static class ConnectionConfiguration
    {
        private static string GetHerokuConnectionString()
        {
            // Get the Database URL from the ENV variables in Heroku
            string connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            // parse the connection string
            var databaseUri = new Uri(connectionUrl);
            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};" +
            $"Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }
        public static void AddDbContextAndConfigurations(this IServiceCollection services, IWebHostEnvironment env, IConfiguration config)
        {
            string connStr;
            if (env.IsProduction())
            {
                connStr = GetHerokuConnectionString();
            }
            else
            {
                connStr = config.GetConnectionString("DefaultConnection");
            }
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseNpgsql(connStr, getAssembly => getAssembly.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });
        }
    }
}
