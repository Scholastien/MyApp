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
        try
        {
            var details = await GetEntityByIdAsync<CustomerDetails>(editReq.Id, ctk);
        
            editReq.WriteTo(details);
            UnitOfWork.Repository<CustomerDetails>().Update(details);
            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo($"individual {editReq.Id} updated");
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during CustomerDetails update occured", e);
            throw;
        }
    }

    public async Task<CustomerDetailsDto> GetCustomerDetailsDtoById(Guid id, CancellationToken ctk = default)
    {
        try
        {
            var customerSpec = CustomerSpecifications<Customer>.GetCustomerWithBillingOrShippingIdSpec(id);
            var customer = await UnitOfWork.Repository<Customer>().FirstOrDefaultAsync(customerSpec, ctk);
        
            var details = await GetEntityByIdAsync<CustomerDetails>(id, ctk);

            return new CustomerDetailsDto(details)
            {
                CustomerType = customer.CustomerType
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during CustomerDetails fetching as Dto occured", e);
            throw;
        }
    }
}