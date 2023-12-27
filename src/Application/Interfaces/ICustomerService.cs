using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;

namespace MyApp.Application.Interfaces;

public interface ICustomerService
{
    Task<CreateCustomerRes> CreateCustomer(CustomerCreateReq req, CancellationToken ctk = default);
    Task UpdateCustomer(CustomerEditReq req, CancellationToken ctk = default);
    Task<GetAllActiveCustomersRes> GetAllActiveCustomers(CancellationToken ctk = default);
    Task<CustomerDTO> GetCustomerDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteCustomerWithId(Guid id, CancellationToken ctk = default);
}