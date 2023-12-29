using MyApp.Application.Interfaces.Models;
using MyApp.Application.Models.DTOs.Customers;

namespace MyApp.Application.Models.Responses.Customers.Companies;

public class CompanyRes : IBaseResponse<CompanyDto>
{
    public CompanyDto Data { get; set; }
}