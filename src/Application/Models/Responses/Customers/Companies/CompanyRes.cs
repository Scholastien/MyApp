using MyApp.Application.Interfaces.Models;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers.Companies;

public class CompanyRes : CustomerRes<CompanyWithDetailsDto, Company>
{
}