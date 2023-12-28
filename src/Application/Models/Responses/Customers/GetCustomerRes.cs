using MyApp.Application.Models.DTOs.Customers;

namespace MyApp.Application.Models.Responses.Customers;

public class GetCustomerRes<T> where T : CustomerDto
{
    public T Data { get; set; }
}