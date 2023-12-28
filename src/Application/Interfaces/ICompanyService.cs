using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers.Companies;
using MyApp.Application.Models.Responses.Customers;

namespace MyApp.Application.Interfaces;

public interface ICompanyService<T> where T : CustomerDto
{
    Task<CreateCustomerRes<T>> CreateCompany(CompanyCreateReq createReq, CancellationToken ctk = default);
    Task UpdateCompany(CompanyEditReq editReq, CancellationToken ctk = default);
    Task<GetAllActiveCustomersRes<T>> GetAllActiveCompanies(CancellationToken ctk = default);
    Task<T> GetCompanyDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteCompanyWithId(Guid id, CancellationToken ctk = default);
}