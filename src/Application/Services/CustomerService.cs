using MyApp.Application.Models.Requests.Customers;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Services;

public abstract class CustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    protected CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected async Task AddDetailsToCustomer(CustomerCreateReq req, Customer customer, CancellationToken ctk = default)
    {
        customer.BillingDetails = await _unitOfWork.Repository<CustomerDetails>()
            .AddAsync(BillingCustomerDetails(req, customer), ctk);
        
        customer.ShippingDetails = await _unitOfWork.Repository<CustomerDetails>()
            .AddAsync(ShippingCustomerDetails(req, customer), ctk);
    }
    
    private static CustomerDetails BillingCustomerDetails(CustomerCreateReq req, IIdentifiableByIdEntity customer)
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
    
    private static CustomerDetails ShippingCustomerDetails(CustomerCreateReq req, IIdentifiableByIdEntity customer)
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