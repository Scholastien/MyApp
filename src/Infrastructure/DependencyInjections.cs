using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Core.Services;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;
using MyApp.Infrastructure.Services;

namespace MyApp.Infrastructure;

public static class DependencyInjections
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql("name=ConnectionStrings:DefaultConnection", _ => 
                _.MigrationsAssembly("Infrastructure")));
        
        services.AddDefaultIdentity<IdentityUserBase>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<AppDbContext>();
            
        services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        services.AddScoped<ILoggerService, LoggerService>();
    }

    public static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();

        using var dbContext = new AppDbContext(dbContextOptions);
            
        dbContext.Database.Migrate();
    }
}