using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.DTOs.CustumersDetails;
using MyApp.Application.Models.Requests.Customers;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class CustomerDetailsService : ICustomerDetailsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public CustomerDetailsService(IUnitOfWork unitOfWork, ILoggerService loggerService)
    {
        _unitOfWork = unitOfWork;
        _loggerService = loggerService;
    }

    public async Task UpdateCustomerDetails(CustomerDetailsEditReq editReq, CancellationToken ctk = default)
    {
        var details = await _unitOfWork.Repository<CustomerDetails>().GetByIdAsync(editReq.Id, ctk);
        
        if (details == null)
        {
            _loggerService.LogInfo($"Couldn't find CustomerDetails with ID {editReq.Id}");
            throw new NullReferenceException();
        }
        
        editReq.WriteTo(details);
        _unitOfWork.Repository<CustomerDetails>().Update(details);
        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo($"individual {editReq.Id} updated");
    }

    public async Task<CustomerDetailsDto> GetCustomerDetailsDtoById(Guid id, CancellationToken ctk = default)
    {
        var customerSpec = CustomerSpecifications<Customer>.GetCustomerWithDetailsMatchingId(id);
        var customer = await _unitOfWork.Repository<Customer>().FirstOrDefaultAsync(customerSpec, ctk);
        
        var details = await _unitOfWork.Repository<CustomerDetails>().GetByIdAsync(id, ctk);

        // Return if not null
        if (details != null) return new CustomerDetailsDto(details)
        {
            CustomerType = customer.CustomerType
        };
        
        // Log and throw
        _loggerService.LogInfo($"Couldn't find CustomerDetails with ID {id}");
        throw new NullReferenceException();
    }
}