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

    public async Task<BillingRes> CreateBilling(BillingCreateReq req, CancellationToken ctk = default)
    {
        try
        {
            var billing = await UnitOfWork.Repository<Billing>().AddAsync(new Billing
            {
                CustomerId = req.CustomerId,
                CreatedOn = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
            }, ctk);

            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo("New billing created");

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

    public async Task<BillingRes> CreateOrUpdateBillingLine(BillingEditReq req, CancellationToken ctk = default)
    {
        var lineSpec = BillingLineSpecifications.WithBillingIdAndProductIdSpec((req.Id, req.CustomerId), req.NewLineProduct);
        var line = await UnitOfWork.Repository<BillingLine>().FirstOrDefaultAsync(lineSpec, ctk);

        if (line == null)
        {
            return await CreateBillingLine(req, ctk);
        }

        return await UpdateBillingLine(req, line, ctk);
    }

    public async Task<BillingRes> CreateBillingLine(BillingEditReq req, CancellationToken ctk = default)
    {
        var billingLine = await UnitOfWork.Repository<BillingLine>().AddAsync(new BillingLine
        {
            BillingId = req.Id,
            BillingCustomerId = req.CustomerId,
            ProductId = req.NewLineProduct,
            Quantity = req.NewLineQuantity,
            CreatedOn = DateTimeOffset.Now,
            CreatedBy = Guid.NewGuid(),
        }, ctk);

        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo("New billing line created");

        var billingSpec = BillingSpecifications.SingleBillingWithAllIncludesSpec(req.Id, req.CustomerId);

        var billing = await UnitOfWork.Repository<Billing>().FirstOrDefaultAsync(billingSpec, ctk);
        return new BillingRes
        {
            Data = new BillingDto(billing)
        };
    }

    public async Task<BillingRes> UpdateBillingLine(BillingEditReq req, BillingLine line,
        CancellationToken ctk = default)
    {
        line.Quantity += req.NewLineQuantity;
        UnitOfWork.Repository<BillingLine>().Update(line);
        await UnitOfWork.SaveChangesAsync(ctk);

        var billingSpec = BillingSpecifications.SingleBillingWithAllIncludesSpec(req.Id, req.CustomerId);

        var billing = await UnitOfWork.Repository<Billing>().FirstOrDefaultAsync(billingSpec, ctk);
        return new BillingRes
        {
            Data = new BillingDto(billing)
        };
    }

    public async Task<(Guid BillingId, Guid BillingCustomerId)> DeleteBillingLine(Guid id,
        CancellationToken ctk = default)
    {
        var line = await UnitOfWork.Repository<BillingLine>().GetByIdAsync(id, ctk);

        if (line == null)
        {
            LoggerService.LogError($"Couldn't find BillingLine with ID {id}");
            throw new NullReferenceException();
        }

        UnitOfWork.Repository<BillingLine>().Delete(line);
        await UnitOfWork.SaveChangesAsync(ctk);

        return (line.BillingId, line.BillingCustomerId);
    }

    public async Task DeleteBillingWithId(Guid id, Guid customerId, CancellationToken ctk = default)
    {
        var billing = await UnitOfWork.Repository<Billing>().GetByIdAsync(new object[] { id, customerId }, ctk);

        if (billing == null)
        {
            LoggerService.LogError($"Couldn't find Billing with ID {id}");
            throw new NullReferenceException();
        }

        UnitOfWork.Repository<Billing>().Delete(billing);
        await UnitOfWork.SaveChangesAsync(ctk);
    }

    public BillingStateEnum GetBillingState(Guid id, Guid customerId, CancellationToken ctk = default)
    {
        throw new NotImplementedException(); // TODO
    }
}