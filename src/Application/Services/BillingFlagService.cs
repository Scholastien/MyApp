using MyApp.Application.Core.Services;
using MyApp.Application.Extensions;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Billings;

namespace MyApp.Application.Services;

public class BillingFlagService : ServiceBase, IBillingFlagService
{
    public BillingFlagService(IUnitOfWork unitOfWork, ILoggerService loggerService) : base(unitOfWork, loggerService)
    {
    }
    
    public async Task AddBillingLineFlags(Guid billingId, Guid customerId, CancellationToken ctk = default)
    {
        try
        {
            var spec = BillingSpecifications.SingleBillingSpec(billingId, customerId);
            var billing = await FirstOrDefaultAsync(spec, ctk);

            billing.StateFlag = billing.StateFlag.GetFlagForAction(UserActionEnum.AddBillingLine);

            await UpdateAsync(billing, ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during AddBillingLineFlags occured", e);
            throw;
        }
    }

    public async Task DeleteBillingLineFlags(Guid billingId, Guid customerId, CancellationToken ctk = default)
    {
        try
        {
            var spec = BillingSpecifications.SingleBillingSpec(billingId, customerId)
                .IncludeBillingLines();
            var billing = await FirstOrDefaultAsync(spec, ctk);

            billing.StateFlag = billing.StateFlag.GetFlagForAction(UserActionEnum.DeleteBillingLine);

            await UpdateAsync(billing, ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during DeleteBillingLineFlags occured", e);
            throw;
        }
    }

    public async Task AddBulkDiscountFlags(Guid billingId, Guid customerId, CancellationToken ctk = default)
    {
        try
        {
            var spec = BillingSpecifications.SingleBillingSpec(billingId, customerId);
            var billing = await FirstOrDefaultAsync(spec, ctk);

            billing.StateFlag = billing.StateFlag.GetFlagForAction(UserActionEnum.AddBulkDiscount);

            await UpdateAsync(billing, ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during AddBulkDiscountFlags occured", e);
            throw;
        }
    }

    public async Task DeleteBulkDiscountFlags(Guid billingId, Guid customerId, CancellationToken ctk = default)
    {
        try
        {
            var spec = BillingSpecifications.SingleBillingSpec(billingId, customerId)
                .IncludeDiscounts();
            var billing = await FirstOrDefaultAsync(spec, ctk);

            billing.StateFlag = billing.StateFlag.GetFlagForAction(UserActionEnum.DeleteBulkDiscount);

            await UpdateAsync(billing, ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during DeleteBulkDiscountFlags occured", e);
            throw;
        }
    }
}