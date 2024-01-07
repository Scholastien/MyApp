using MyApp.Application.Models.Dtos.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers;

public abstract class CustomerRes<TCustomerDto, TCustomer> : BaseResponse<TCustomerDto, TCustomer>
    where TCustomerDto : CustomerWithDetailsDto<TCustomer> 
    where TCustomer : Customer
{
}