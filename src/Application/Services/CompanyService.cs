using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Customers.Companies;
using MyApp.Application.Models.Requests.Customers.Companies;
using MyApp.Application.Models.Responses.Customers.Companies;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class CompanyService : CustomerService, ICompanyService
{
    public CompanyService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        : base(unitOfWork, loggerService)
    {
    }

    public async Task<IBaseResponse<CompanyWithDetailsDto>> CreateCompany(CompanyCreateReq req,
        CancellationToken ctk = default)
    {
        var company = await UnitOfWork.Repository<Company>().AddAsync(new Company
        {
            Email = req.Email,
            PhoneNumber = req.PhoneNumber,
            StatusEnum = CustomerStatusEnum.Active,
            CreatedBy = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            IsDeleted = false,
            Kbis = req.Kbis,
            CompanySize = req.CompanySize
        }, ctk);

        await AddDetailsToCustomer(req, company, ctk);

        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo("New Company created");

        return new CompanyRes { Data = new CompanyWithDetailsDto(company)
            {
                CustomerType = CustomerTypeEnum.Company
            }
        };
    }

    public async Task UpdateCompany(CompanyEditReq editReq, CancellationToken ctk = default)
    {
        try
        {
            var company = await GetEntityByIdAsync<Company>(editReq.Id, ctk);

            editReq.WriteTo(company);
            UnitOfWork.Repository<Company>().Update(company);
            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo($"company {editReq.Id} updated");
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Company update occured", e);
            throw;
        }
    }

    public async Task<IBaseResponse<IList<CompanyDto>>> GetAllActiveCompanies(CancellationToken ctk = default)
    {
        var activeCompaniesSpec = CustomerSpecifications<Company>.GetAllActiveCustomersSpec();

        var companies = await UnitOfWork.Repository<Company>().ListAsync(activeCompaniesSpec, ctk);

        return new MultipleCompaniesRes
        {
            Data = companies.Select(x => new CompanyDto(x)).ToList()
        };
    }

    public async Task<CompanyWithDetailsDto> GetCompanyDtoById(Guid id, CancellationToken ctk = default)
    {
        var companySpec = CustomerSpecifications<Company>.AllIncludesForEditToCustomerWithIdSpec(id);

        var company = await UnitOfWork.Repository<Company>().FirstOrDefaultAsync(companySpec, ctk);
        
        // Return if not null
        if (company != null) return new CompanyWithDetailsDto(company);
        
        // Log and throw
        LoggerService.LogError($"Couldn't find company with ID {id}");
        throw new NullReferenceException();

    }

    public async Task DeleteCompanyWithId(Guid id, CancellationToken ctk = default)
    {
        try
        {
            var company = await GetEntityByIdAsync<Company>(id, ctk);

            UnitOfWork.Repository<Company>().Delete(company);
            await UnitOfWork.SaveChangesAsync(ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Company deletion occured", e);
            throw;
        }
    }

    public async Task<CompanyWithDetailsDto> GetCompanyWithDetailsDtoById(Guid id, CancellationToken ctk = default)
    {
        var customerSpec = CustomerSpecifications<Company>.GetCustomerWithBillingOrShippingIdSpec(id);
        var customer = await UnitOfWork.Repository<Company>().FirstOrDefaultAsync(customerSpec, ctk);

        // Return if not null
        if (customer != null) return new CompanyWithDetailsDto(customer)
        {
            CustomerType = CustomerTypeEnum.Company
        };
        
        // Log and throw
        LoggerService.LogInfo($"Couldn't find CustomerDetails with ID {id}");
        throw new NullReferenceException();
    }
}