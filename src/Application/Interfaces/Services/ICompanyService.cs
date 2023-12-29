using MyApp.Application.Interfaces.Models;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers.Companies;

namespace MyApp.Application.Interfaces.Services;

public interface ICompanyService
{
    Task<IBaseResponse<CompanyDto>> CreateCompany(CompanyCreateReq createReq, CancellationToken ctk = default);
    Task UpdateCompany(CompanyEditReq editReq, CancellationToken ctk = default);
    Task<IBaseResponse<IList<CompanyDto>>> GetAllActiveCompanies(CancellationToken ctk = default);
    Task<CompanyDto> GetCompanyDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteCompanyWithId(Guid id, CancellationToken ctk = default);
}