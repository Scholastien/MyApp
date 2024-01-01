using MyApp.Application.Models.DTOs.CustumersDetails;
using MyApp.Application.Models.Requests.Customers;

namespace MyApp.Application.Interfaces.Services;

public interface ICustomerDetailsService
{
    Task UpdateCustomerDetails(CustomerDetailsEditReq editReq, CancellationToken ctk = default);
    Task<CustomerDetailsDto> GetCustomerDetailsDtoById(Guid id, CancellationToken ctk = default);

}