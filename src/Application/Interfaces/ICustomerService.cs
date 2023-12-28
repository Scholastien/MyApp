using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers;
using MyApp.Application.Models.Responses.Customers;

namespace MyApp.Application.Interfaces;

public interface ICustomerService<T> where T : CustomerDto
{
    Task<CreateCustomerRes<T>> CreateCustomer(CustomerCreateReq createReq, CancellationToken ctk = default);
    Task UpdateCustomer(CustomerEditReq editReq, CancellationToken ctk = default);
    Task<GetAllActiveCustomersRes<T>> GetAllActiveCustomers(CancellationToken ctk = default);
    Task<T> GetCustomerDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteCustomerWithId(Guid id, CancellationToken ctk = default);
}