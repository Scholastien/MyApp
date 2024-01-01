using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class CustomerService : ICustomerService<CustomerDto<Customer>, Customer>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public CustomerService(IUnitOfWork unitOfWork, ILoggerService loggerService)
    {
        _unitOfWork = unitOfWork;
        _loggerService = loggerService;
    }

    public async Task<IBaseResponse<IList<CustomerDto<Customer>>>> GetAllActiveCustomers(CancellationToken ctk = default)
    {
        throw new NotImplementedException();
    }
    
    public async Task<CustomerTypeEnum> GetCustomerTypeWithId(Guid id, CancellationToken ctk = default)
    {
        var customerSpec = CustomerSpecifications<Customer>.GetCustomerById(id);
        var customer = await _unitOfWork.Repository<Customer>().FirstOrDefaultAsync(customerSpec, ctk);
        
        // Return if not null
        if (customer != null) return customer.CustomerType;
        
        // Log and throw
        _loggerService.LogError($"Couldn't find customer with ID {id}");
        throw new NullReferenceException();
    }
}