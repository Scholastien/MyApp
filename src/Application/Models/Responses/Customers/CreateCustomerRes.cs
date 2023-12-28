using MyApp.Application.Models.DTOs.Customers;

namespace MyApp.Application.Models.Responses.Customers;

public class CreateCustomerRes<T> where T : CustomerDto
{
    public T Data { get; set; }
}