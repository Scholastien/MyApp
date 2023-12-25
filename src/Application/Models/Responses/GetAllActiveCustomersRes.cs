using MyApp.Application.Models.DTOs;

namespace MyApp.Application.Models.Responses;

public class GetAllActiveUsersRes
{
    public IList<CustomerDTO> Data { get; set; }
}