using MyApp.Application.Models.Dtos.Customers.Companies;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers.Companies;

public class CompanyRes : CustomerRes<CompanyWithDetailsDto, Company>
{
}