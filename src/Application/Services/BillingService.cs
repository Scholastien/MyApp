using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.BillingLines;
using MyApp.Domain.Specifications.Billings;

namespace MyApp.Application.Services;

public class BillingService : ServiceBase, IBillingService
{
    private readonly ICustomerService _customerService;  
    
    public BillingService(ILoggerService loggerService, IUnitOfWork unitOfWork, ICustomerService customerService) : base(unitOfWork, loggerService)
    {
        _customerService = customerService;
    }

    private async Task<Billing> GetBillingWithIncludesByIds(Guid billingId, Guid customerId, CancellationToken ctk)
    {
        var billingSpec = BillingSpecifications.SingleBillingWithAllIncludesSpec(billingId, customerId);
        var billing = await UnitOfWork.Repository<Billing>().FirstOrDefaultAsync(billingSpec, ctk);
        
        if (billing != null) return billing;

        var errMsg = $"Couldn't find Billing with ID {billingId}";
        throw new NullReferenceException(errMsg);
    }

    public async Task<BillingRes> CreateBilling(BillingCreateReq req, CancellationToken ctk = default)
    {
        try
        {
            var newBilling = await UnitOfWork.Repository<Billing>().AddAsync(new Billing
            {
                CustomerId = req.CustomerId,
                CreatedOn = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
            }, ctk);

            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo("New billing created");

            var billing = await GetBillingWithIncludesByIds(newBilling.Id, newBilling.CustomerId, ctk);

            return new BillingRes
            {
                Data = new BillingDto(billing)
            };
        }
        catch (Exception e)
        {
            LoggerService.LogInfo("A problem during Billing creation occured", e);
            throw;
        }
    }

    public async Task<MultipleBillingsRes> GetAllBillingsForCustomer(Guid customerId,
        CancellationToken ctk = default)
    {
        var type = await _customerService.GetCustomerTypeWithId(customerId);
        
        var billingSpec = BillingSpecifications.MultipleBillingsForCustomerIdSpec(customerId);
        var billings = await UnitOfWork.Repository<Billing>().ListAsync(billingSpec, ctk);
        
        return new MultipleBillingsRes
        {
            CustomerId = customerId,
            Data = billings.Select(b => new BillingDto(b))
                .ToList(),
            CustomerType = type
        };
    }

    public async Task<BillingDto> GetBillingDtoById(Guid id, Guid customerId, CancellationToken ctk = default)
    {
        var billingSpec = BillingSpecifications.SingleBillingWithAllIncludesSpec(id, customerId);
        var billing = await UnitOfWork.Repository<Billing>().FirstOrDefaultAsync(billingSpec, ctk);

        // Return if not null
        if (billing != null)
            return new BillingDto(billing);

        // Log and throw
        LoggerService.LogError($"Couldn't find product with ID {id}");
        throw new NullReferenceException();
    }
    
    public async Task DeleteBillingWithId(Guid id, Guid customerId, CancellationToken ctk = default)
    {
        try
        {
            var billing = await GetEntityByIdAsync<Billing>(new object[] { id, customerId }, ctk);

            UnitOfWork.Repository<Billing>().Delete(billing);
            await UnitOfWork.SaveChangesAsync(ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Billing deletion occured", e);
            throw;
        }
    }

    public BillingStateEnum GetBillingState(Guid id, Guid customerId, CancellationToken ctk = default)
    {
        throw new NotImplementedException(); // TODO
    }
}