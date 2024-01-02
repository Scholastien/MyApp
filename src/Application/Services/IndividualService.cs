using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers.Individuals;
using MyApp.Application.Models.Responses.Customers.Individuals;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class IndividualService : CustomerService, IIndividualService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public IndividualService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _loggerService = loggerService;
    }

    public async Task<IBaseResponse<IndividualWithDetailsDto>> CreateIndividual(IndividualCreateReq createReq,
        CancellationToken ctk = default)
    {
        var customer = await _unitOfWork.Repository<Individual>().AddAsync(new Individual
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
        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo("New individual created");

        return new IndividualRes { Data = new IndividualWithDetailsDto(customer)
            {
                CustomerType = CustomerTypeEnum.Individual
            }
        };
    }

    public async Task UpdateIndividual(IndividualEditReq editReq, CancellationToken ctk = default)
    {
        var individual = await _unitOfWork.Repository<Individual>().GetByIdAsync(editReq.Id, ctk);

        if (individual == null)
        {
            _loggerService.LogError($"Couldn't find individual with ID {editReq.Id}");
            throw new NullReferenceException();
        }

        editReq.WriteTo(individual);
        _unitOfWork.Repository<Individual>().Update(individual);
        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo($"individual {editReq.Id} updated");
    }

    public async Task<MultipleIndividualsRes> GetAllActiveIndividuals(CancellationToken ctk = default)
    {
        var activeIndividualsSpec = CustomerSpecifications<Individual>.GetAllActiveCustomersSpec();

        var individuals = await _unitOfWork.Repository<Individual>().ListAsync(activeIndividualsSpec, ctk);

        return new MultipleIndividualsRes
        {
            Data = individuals.Select(x => new IndividualDto(x)).ToList()
        };
    }

    public async Task<IndividualWithDetailsDto> GetIndividualDtoById(Guid id, CancellationToken ctk = default)
    {
        var individualSpec = CustomerSpecifications<Individual>.AllIncludesToCustomerWithId(id);
        
        var individual = await _unitOfWork.Repository<Individual>().FirstOrDefaultAsync(individualSpec, ctk);

        // Return if not null
        if (individual != null) return new IndividualWithDetailsDto(individual);
        
        // Log and throw
        _loggerService.LogError($"Couldn't find individual with ID {id}");
        throw new NullReferenceException();
    }

    public async Task DeleteIndividualWithId(Guid id, CancellationToken ctk = default)
    {
        var individual = await _unitOfWork.Repository<Individual>().GetByIdAsync(id, ctk);

        if (individual == null)
        {
            _loggerService.LogError($"Couldn't find individual with ID {id}");
            throw new NullReferenceException();
        }

        _unitOfWork.Repository<Individual>().Delete(individual);
        await _unitOfWork.SaveChangesAsync(ctk);
    }

    public async Task<IndividualWithDetailsDto> GetIndividualWithDetailsDtoById(Guid id, CancellationToken ctk = default)
    {
        var customerSpec = CustomerSpecifications<Individual>.GetCustomerWithBillingOrShippingId(id);
        var customer = await _unitOfWork.Repository<Individual>().FirstOrDefaultAsync(customerSpec, ctk);
        
        var details = await _unitOfWork.Repository<CustomerDetails>().GetByIdAsync(id, ctk);

        // Return if not null
        if (customer != null) return new IndividualWithDetailsDto(customer)
        {
            CustomerType = CustomerTypeEnum.Company
        };
        
        // Log and throw
        _loggerService.LogInfo($"Couldn't find CustomerDetails with ID {id}");
        throw new NullReferenceException();
    }
}