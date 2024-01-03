using MyApp.Application.Interfaces.Models;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Customers;
using MyApp.Application.Models.Dtos.Customers.Companies;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Responses.Customers.Companies;

public class MultipleCompaniesRes : MultipleCustomersRes<CompanyDto, Company>
{
}