using MyApp.Application.Models.DTOs;

namespace MyApp.Application.Models.Responses;

public class GetAllActiveCustomersRes
{
    public IList<CustomerDTO> Data { get; set; }
}