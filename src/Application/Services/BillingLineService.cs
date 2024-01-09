using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.BillingLines;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.BillingLines;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.Products;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.BillingLines;

namespace MyApp.Application.Services;

public class BillingLineService : ServiceBase, IBillingLineService
{
    private readonly IBillingService _billingService;
    private readonly IBillingFlagService _billingFlagService;

    public BillingLineService(IUnitOfWork unitOfWork, ILoggerService loggerService, IBillingService billingService, IBillingFlagService billingFlagService) :
        base(unitOfWork, loggerService)
    {
        _billingService = billingService;
        _billingFlagService = billingFlagService;
    }

    public async Task<BillingLineRes> CreateOrUpdateBillingLine(BillingEditReq req, CancellationToken ctk = default)
    {
        var lineSpec =
            BillingLineSpecifications.WithBillingIdAndProductIdSpec((req.Id, req.CustomerId), req.NewLineProduct);
        var line = await UnitOfWork.Repository<BillingLine>().FirstOrDefaultAsync(lineSpec, ctk);

        if (line == null)
        {
            return await CreateBillingLine(req, ctk);
        }

        return await UpdateBillingLine(req, line, ctk);
    }

    private async Task<BillingLineRes> CreateBillingLine(BillingEditReq req, CancellationToken ctk = default)
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

            await _billingFlagService.AddBillingLineFlags(req.Id, req.CustomerId, ctk);

            var product = await GetEntityByIdAsync<Product>(req.NewLineProduct, ctk);

            return new BillingLineRes
            {
                Data = new BillingLineDto(billingLine)
                {
                    Name = product.Name,
                    Price = product.Price
                }
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingLine creation occured", e);
            throw;
        }
    }

    private async Task<BillingLineRes> UpdateBillingLine(BillingEditReq req, BillingLine line,
        CancellationToken ctk = default)
    {
        try
        {
            line.Quantity += req.NewLineQuantity;
            UnitOfWork.Repository<BillingLine>().Update(line);
            await UnitOfWork.SaveChangesAsync(ctk);

            var product = await GetEntityByIdAsync<Product>(line.ProductId, ctk);

            return new BillingLineRes
            {
                Data = new BillingLineDto(line)
                {
                    Name = product.Name,
                    Price = product.Price
                }
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingLine update occured", e);
            throw;
        }
    }

    public async Task<(Guid BillingId, Guid BillingCustomerId)> DeleteBillingLine(Guid id,
        CancellationToken ctk = default)
    {
        try
        {
            var line = await GetEntityByIdAsync<BillingLine>(id, ctk);
            UnitOfWork.Repository<BillingLine>().Delete(line);
            await UnitOfWork.SaveChangesAsync(ctk);
            
            var billing = await _billingService.GetBillingDtoById(line.BillingId, line.BillingCustomerId, ctk);
            
            // if we still have billing lines
            if (billing.Lines.Any()) return (line.BillingId, line.BillingCustomerId);
            
            // update flags if we don't have billing lines anymore
            await _billingFlagService.DeleteBillingLineFlags(line.BillingId, line.BillingCustomerId, ctk);
            return (line.BillingId, line.BillingCustomerId);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingLine deletion occured", e);
            throw;
        }
    }
}