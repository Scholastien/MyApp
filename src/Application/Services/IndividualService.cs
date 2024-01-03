using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Customers;
using MyApp.Application.Models.Dtos.Customers.Individuals;
using MyApp.Application.Models.Requests.Customers.Individuals;
using MyApp.Application.Models.Responses.Customers.Individuals;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class IndividualService : CustomerService, IIndividualService
{
    public IndividualService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        : base(unitOfWork, loggerService)
    {
    }

    public async Task<IBaseResponse<IndividualWithDetailsDto>> CreateIndividual(IndividualCreateReq createReq,
        CancellationToken ctk = default)
    {
        var customer = await UnitOfWork.Repository<Individual>().AddAsync(new Individual
        {
            FirstName = createReq.FirstName,
            LastName = createReq.LastName,
            Email = createReq.Email,
            PhoneNumber = createReq.PhoneNumber,
            StatusEnum = CustomerStatusEnum.Active,
            CreatedBy = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            IsDeleted = false,
        }, ctk);


        await AddDetailsToCustomer(createReq, customer, ctk);
        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo("New individual created");

        return new IndividualRes { Data = new IndividualWithDetailsDto(customer)
            {
                CustomerType = CustomerTypeEnum.Individual
            }
        };
    }

    public async Task UpdateIndividual(IndividualEditReq editReq, CancellationToken ctk = default)
    {
        var individual = await UnitOfWork.Repository<Individual>().GetByIdAsync(editReq.Id, ctk);

        if (individual == null)
        {
            LoggerService.LogError($"Couldn't find individual with ID {editReq.Id}");
            throw new NullReferenceException();
        }

        editReq.WriteTo(individual);
        UnitOfWork.Repository<Individual>().Update(individual);
        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo($"individual {editReq.Id} updated");
    }

    public async Task<MultipleIndividualsRes> GetAllActiveIndividuals(CancellationToken ctk = default)
    {
        var activeIndividualsSpec = CustomerSpecifications<Individual>.GetAllActiveCustomersSpec();

        var individuals = await UnitOfWork.Repository<Individual>().ListAsync(activeIndividualsSpec, ctk);

        return new MultipleIndividualsRes
        {
            Data = individuals.Select(x => new IndividualDto(x)).ToList()
        };
    }

    public async Task<IndividualWithDetailsDto> GetIndividualDtoById(Guid id, CancellationToken ctk = default)
    {
        var individualSpec = CustomerSpecifications<Individual>.AllIncludesForEditToCustomerWithIdSpec(id);
        
        var individual = await UnitOfWork.Repository<Individual>().FirstOrDefaultAsync(individualSpec, ctk);

        // Return if not null
        if (individual != null) return new IndividualWithDetailsDto(individual);
        
        // Log and throw
        LoggerService.LogError($"Couldn't find individual with ID {id}");
        throw new NullReferenceException();
    }

    public async Task DeleteIndividualWithId(Guid id, CancellationToken ctk = default)
    {
        var individual = await UnitOfWork.Repository<Individual>().GetByIdAsync(id, ctk);

        if (individual == null)
        {
            LoggerService.LogError($"Couldn't find individual with ID {id}");
            throw new NullReferenceException();
        }

        UnitOfWork.Repository<Individual>().Delete(individual);
        await UnitOfWork.SaveChangesAsync(ctk);
    }

    public async Task<IndividualWithDetailsDto> GetIndividualWithDetailsDtoById(Guid id, CancellationToken ctk = default)
    {
        var customerSpec = CustomerSpecifications<Individual>.GetCustomerWithBillingOrShippingIdSpec(id);
        var customer = await UnitOfWork.Repository<Individual>().FirstOrDefaultAsync(customerSpec, ctk);
        
        var details = await UnitOfWork.Repository<CustomerDetails>().GetByIdAsync(id, ctk);

        // Return if not null
        if (customer != null) return new IndividualWithDetailsDto(customer)
        {
            CustomerType = CustomerTypeEnum.Company
        };
        
        // Log and throw
        LoggerService.LogInfo($"Couldn't find CustomerDetails with ID {id}");
        throw new NullReferenceException();
    }
}