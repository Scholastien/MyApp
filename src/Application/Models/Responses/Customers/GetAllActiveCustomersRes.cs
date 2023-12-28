using MyApp.Application.Models.DTOs.Customers;

namespace MyApp.Application.Models.Responses.Customers;

public class GetAllActiveCustomersRes<T> where T : CustomerDto
{
    public IList<T> Data { get; set; }
}