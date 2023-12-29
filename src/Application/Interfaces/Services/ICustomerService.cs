using MyApp.Application.Interfaces.Models;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Interfaces.Services;

public interface ICustomerService<TDto, TCustomer> where TDto : CustomerDto<TCustomer> where TCustomer : Customer
{
    Task<IBaseResponse<TDto>> CreateCustomer(CustomerCreateReq createReq, CancellationToken ctk = default);
    Task UpdateCustomer(CustomerEditReq<TDto, TCustomer> editReq, CancellationToken ctk = default);
    Task<IBaseResponse<IList<TDto>>> GetAllActiveCustomers(CancellationToken ctk = default);
    Task<TDto> GetCustomerDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteCustomerWithId(Guid id, CancellationToken ctk = default);
}