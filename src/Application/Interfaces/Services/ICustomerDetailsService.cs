using MyApp.Application.Models.Dtos.CustumersDetails;
using MyApp.Application.Models.Requests.Customers;
using MyApp.Application.Models.Requests.CustomersDetails;

namespace MyApp.Application.Interfaces.Services;

public interface ICustomerDetailsService
{
    Task UpdateCustomerDetails(CustomerDetailsEditReq editReq, CancellationToken ctk = default);
    Task<CustomerDetailsDto> GetCustomerDetailsDtoById(Guid id, CancellationToken ctk = default);

}