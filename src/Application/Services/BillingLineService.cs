using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Specifications.BillingLines;
using MyApp.Domain.Specifications.Billings;

namespace MyApp.Application.Services;

public class BillingLineService : ServiceBase, IBillingLineService
{
    public BillingLineService(IUnitOfWork unitOfWork, ILoggerService loggerService) : base(unitOfWork, loggerService)
    {
    }
    
    private async Task<Billing> GetBillingWithIncludesByIds(Guid billingId, Guid customerId, CancellationToken ctk)
    {
        var billingSpec = BillingSpecifications.SingleBillingWithAllIncludesSpec(billingId, customerId);
        var billing = await UnitOfWork.Repository<Billing>().FirstOrDefaultAsync(billingSpec, ctk);
        
        if (billing != null) return billing;

        var errMsg = $"Couldn't find Billing with ID {billingId}";
        throw new NullReferenceException(errMsg);
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
        try
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

            LoggerService.LogInfo($"New billing line created {billingLine.Id}");
        
            var billing = await GetBillingWithIncludesByIds(req.Id, req.CustomerId, ctk);
        
            return new BillingRes
            {
                Data = new BillingDto(billing)
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingLine creation occured", e);
            throw;
        }
    }

    public async Task<BillingRes> UpdateBillingLine(BillingEditReq req, BillingLine line, CancellationToken ctk = default)
    {
        try
        {
            line.Quantity += req.NewLineQuantity;
            UnitOfWork.Repository<BillingLine>().Update(line);
            await UnitOfWork.SaveChangesAsync(ctk);

            var billing = await GetBillingWithIncludesByIds(req.Id, req.CustomerId, ctk);

            return new BillingRes
            {
                Data = new BillingDto(billing)
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingLine update occured", e);
            throw;
        }
    }

    public async Task<(Guid BillingId, Guid BillingCustomerId)> DeleteBillingLine(Guid id, CancellationToken ctk = default)
    {
        try
        {
            var line = await GetEntityByIdAsync<BillingLine>(id, ctk);

            UnitOfWork.Repository<BillingLine>().Delete(line);
            await UnitOfWork.SaveChangesAsync(ctk);

            return (line.BillingId, line.BillingCustomerId);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingLine deletion occured", e);
            throw;
        }
    }
}