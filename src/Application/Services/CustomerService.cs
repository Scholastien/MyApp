using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests.CustomersDetails;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Services;

public class CustomerService : ServiceBase, ICustomerService
{
    public CustomerService(IUnitOfWork unitOfWork, ILoggerService loggerService) 
        : base(unitOfWork, loggerService)
    {
    }

    public async Task<CustomerTypeEnum> GetCustomerTypeWithId(Guid id)
    {
        try
        {
            var customer = await GetEntityByIdAsync<Customer>(id);

            return customer.CustomerType;
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Customer fetching as CustomerType occured", e);
            throw;
        }
    }

    protected async Task AddDetailsToCustomer(IBothCustomerDetailsReq req, Customer customer,
        CancellationToken ctk = default)
    {
        customer.BillingDetails = await UnitOfWork.Repository<CustomerDetails>()
            .AddAsync(BillingCustomerDetails(req, customer), ctk);

        customer.ShippingDetails = await UnitOfWork.Repository<CustomerDetails>()
            .AddAsync(ShippingCustomerDetails(req, customer), ctk);
    }

    private static CustomerDetails BillingCustomerDetails(IBothCustomerDetailsReq req, IIdentifiableByIdEntity customer)
    {
        return new CustomerDetails
        {
            BillingDetailsId = customer.Id,
            City = req.BCity,
            Street = req.BStreet,
            PostalCode = req.BPostalCode,
            State = req.BState,
            Country = req.BCountry
        };
    }

    private static CustomerDetails ShippingCustomerDetails(IBothCustomerDetailsReq req,
        IIdentifiableByIdEntity customer)
    {
        return new CustomerDetails
        {
            ShippingDetailsId = customer.Id,
            City = req.SCity,
            Street = req.SStreet,
            PostalCode = req.SPostalCode,
            State = req.SState,
            Country = req.SCountry
        };
    }
}