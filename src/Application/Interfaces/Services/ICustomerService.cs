using MyApp.Application.Interfaces.Models;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Services;

public interface ICustomerService<TDto, TCustomer> where TDto : CustomerDto<TCustomer> where TCustomer : Customer
{
    Task<IBaseResponse<IList<TDto>>> GetAllActiveCustomers(CancellationToken ctk = default);
    Task<CustomerTypeEnum> GetCustomerTypeWithId(Guid id, CancellationToken ctk = default);
}