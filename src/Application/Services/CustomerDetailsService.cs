using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.CustumersDetails;
using MyApp.Application.Models.Requests.CustomersDetails;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class CustomerDetailsService : ServiceBase, ICustomerDetailsService
{
    public CustomerDetailsService(IUnitOfWork unitOfWork, ILoggerService loggerService) 
        : base(unitOfWork, loggerService)
    {
    }

    public async Task UpdateCustomerDetails(CustomerDetailsEditReq editReq, CancellationToken ctk = default)
    {
        var details = await UnitOfWork.Repository<CustomerDetails>().GetByIdAsync(editReq.Id, ctk);
        
        if (details == null)
        {
            LoggerService.LogError($"Couldn't find CustomerDetails with ID {editReq.Id}");
            throw new NullReferenceException();
        }
        
        editReq.WriteTo(details);
        UnitOfWork.Repository<CustomerDetails>().Update(details);
        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo($"individual {editReq.Id} updated");
    }

    public async Task<CustomerDetailsDto> GetCustomerDetailsDtoById(Guid id, CancellationToken ctk = default)
    {
        var customerSpec = CustomerSpecifications<Customer>.GetCustomerWithBillingOrShippingIdSpec(id);
        var customer = await UnitOfWork.Repository<Customer>().FirstOrDefaultAsync(customerSpec, ctk);
        
        var details = await UnitOfWork.Repository<CustomerDetails>().GetByIdAsync(id, ctk);

        // Return if not null
        if (details != null) return new CustomerDetailsDto(details)
        {
            CustomerType = customer.CustomerType
        };
        
        // Log and throw
        LoggerService.LogError($"Couldn't find CustomerDetails with ID {id}");
        throw new NullReferenceException();
    }
}