using MyApp.Application.Models.DTOs;
using MyApp.Application.Models.Requests;
using MyApp.Application.Models.Responses;

namespace MyApp.Application.Interfaces;

public interface ICustomerService
{
    Task<CreateCustomerRes> CreateCustomer(CustomerCreateReq req);
    Task UpdateCustomer(CustomerEditReq req);
    Task<GetAllActiveCustomersRes> GetAllActiveCustomers();
    Task<CustomerDTO> GetCustomerDtoById(Guid id);
    Task DeleteCustomerWithId(Guid id, CancellationToken ctk = default);
}