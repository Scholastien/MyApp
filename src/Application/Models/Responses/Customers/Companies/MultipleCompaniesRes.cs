using MyApp.Application.Interfaces.Models;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.DTOs.Customers;

namespace MyApp.Application.Models.Responses.Customers.Companies;

public class MultipleCompaniesRes : IBaseResponse<IList<CompanyDto>>
{
    public IList<CompanyDto> Data { get; set; }
}