using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Services;

namespace MyApp.Application;

public static class DependencyInjections
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IIndividualService<IndividualDto>, IndividualService>();
        services.AddScoped<ICompanyService<CompanyDto>, CompanyService>();
    }
}