using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers.Companies;
using MyApp.Application.Models.Responses.Customers.Companies;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class CompanyService : CustomerService, ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public CompanyService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _loggerService = loggerService;
    }

    public async Task<IBaseResponse<CompanyDto>> CreateCompany(CompanyCreateReq req,
        CancellationToken ctk = default)
    {
        var company = await _unitOfWork.Repository<Company>().AddAsync(new Company
        {
            Email = req.Email,
            PhoneNumber = req.PhoneNumber,
            StatusEnum = CustomerStatusEnum.Active,
            CreatedBy = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            IsDeleted = false,
            Kbis = req.Kbis
        }, ctk);

        await AddDetailsToCustomer(req, company, ctk);

        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo("New Company created");

        return new CompanyRes { Data = new CompanyDto(company) };
    }

    public async Task UpdateCompany(CompanyEditReq editReq, CancellationToken ctk = default)
    {
        var company = await _unitOfWork.Repository<Company>().GetByIdAsync(editReq.Id, ctk);

        if (company == null)
        {
            _loggerService.LogInfo($"Couldn't find company with ID {editReq.Id}");
            throw new NullReferenceException();
        }

        editReq.WriteTo(company);
        _unitOfWork.Repository<Company>().Update(company);
        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo($"company {editReq.Id} updated");
    }

    public async Task<IBaseResponse<IList<CompanyDto>>> GetAllActiveCompanies(CancellationToken ctk = default)
    {
        var activeCompaniesSpec = CustomerSpecifications<Company>.GetAllActiveCustomersSpec();

        var companies = await _unitOfWork.Repository<Company>().ListAsync(activeCompaniesSpec, ctk);

        return new MultipleCompaniesRes
        {
            Data = companies.Select(x => new CompanyDto(x)).ToList()
        };
    }

    public async Task<CompanyDto> GetCompanyDtoById(Guid id, CancellationToken ctk = default)
    {
        var companySpec = CustomerSpecifications<Company>.GetCustomerWithDetails(id);
        
        var company = await _unitOfWork.Repository<Company>().FirstOrDefaultAsync(companySpec, ctk);
        
        // Return if not null
        if (company != null) return new CompanyDto(company);
        
        // Log and throw
        _loggerService.LogInfo($"Couldn't find company with ID {id}");
        throw new NullReferenceException();

    }

    public async Task DeleteCompanyWithId(Guid id, CancellationToken ctk = default)
    {
        var company = await _unitOfWork.Repository<Company>().GetByIdAsync(id, ctk);

        if (company == null)
        {
            _loggerService.LogInfo($"Couldn't find company with ID {id}");
            throw new NullReferenceException();
        }

        _unitOfWork.Repository<Company>().Delete(company);
        await _unitOfWork.SaveChangesAsync(ctk);
    }
}