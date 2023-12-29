using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers;

public abstract class MultipleCustomersRes<TCustomerDto, TCustomer> : MultipleBaseResponse<TCustomerDto, TCustomer>
    where TCustomerDto : CustomerDto<TCustomer>
    where TCustomer : Customer
{
}