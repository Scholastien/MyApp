using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Services;

namespace MyApp.Application;

public static class DependencyInjections
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IIndividualService, IndividualService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICustomerDetailsService, CustomerDetailsService>();
    }
}