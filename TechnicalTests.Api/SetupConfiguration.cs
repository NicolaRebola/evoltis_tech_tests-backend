using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using TechnicalTests.Api.Data;
using TechnicalTests.Api.Services.Interfaces;
using TechnicalTests.Api.Services;
using Microsoft.AspNetCore.Identity;
using TechnicalTests.Api.Repositories;
namespace TechnicalTests
{
    public static class SetupConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            ConfigureDbContext(services);

            ConfigureIdentityEndpoints(services);

            ConfigureIoC(services);

            ConfigureAutoMapper(services);
        }

        private static void ConfigureDbContext(this IServiceCollection services)
        {
            Env.Load();
            string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST") ?? 
                throw new InvalidOperationException($"Missing required environment variable: DB_HOST"); ;
            string DB_PORT= Environment.GetEnvironmentVariable("DB_PORT") ?? 
                throw new InvalidOperationException($"Missing required environment variable: DB_PORT"); ;
            string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME") ??
                throw new InvalidOperationException($"Missing required environment variable: DB_NAME"); ;
            string DB_SA_PASSWORD = Environment.GetEnvironmentVariable("DB_SA_PASSWORD") ??
                throw new InvalidOperationException($"Missing required environment variable: DB_SA_PASSWORD"); ;
            string DB_User= Environment.GetEnvironmentVariable("DB_SA_USER") ??
                throw new InvalidOperationException($"Missing required environment variable: DB_SA_USER"); ;

            string connectionString = $"Server={DB_HOST};Port={DB_PORT};Database={DB_NAME};User={DB_User};Password={DB_SA_PASSWORD};";
            services.AddDbContext<AppDbContext>(optionsAction => optionsAction.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }

        private static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddCors();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        private static void ConfigureIdentityEndpoints(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }

        private static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static async Task ApplyMigrationsAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.MigrateAsync();
        }
    }
}