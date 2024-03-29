﻿using Microsoft.Extensions.DependencyInjection;
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
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IBillingService, BillingService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IDiscountPolicyService, DiscountPolicyService>();
        services.AddScoped<IBillingsDiscountsService, BillingsDiscountsService>();
        services.AddScoped<IDiscountService, DiscountService>();
        services.AddScoped<IBillingLineService, BillingLineService>();
        services.AddScoped<IBillingFlagService, BillingFlagService>();
        services.AddScoped<IPaymentHistoryService, PaymentHistoryService>();
    }
}