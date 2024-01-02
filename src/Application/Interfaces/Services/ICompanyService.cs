using MyApp.Application.Interfaces.Models;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Customers;
using MyApp.Application.Models.Requests.Customers.Companies;

namespace MyApp.Application.Interfaces.Services;

public interface ICompanyService
{
    Task<IBaseResponse<CompanyWithDetailsDto>> CreateCompany(CompanyCreateReq createReq, CancellationToken ctk = default);
    Task UpdateCompany(CompanyEditReq editReq, CancellationToken ctk = default);
    Task<IBaseResponse<IList<CompanyDto>>> GetAllActiveCompanies(CancellationToken ctk = default);
    Task<CompanyWithDetailsDto> GetCompanyDtoById(Guid id, CancellationToken ctk = default);
    Task DeleteCompanyWithId(Guid id, CancellationToken ctk = default);
    Task<CompanyWithDetailsDto> GetCompanyWithDetailsDtoById(Guid id, CancellationToken ctk = default);

}