using MyApp.Application.Core.Services;
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

            billing.StateFlag.GetFlagForAction(UserActionEnum.AddBillingLine);

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
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during DeleteBulkDiscountFlags occured", e);
            throw;
        }
    }
}

public enum UserActionEnum
{
    AddBillingLine = 1,
    DeleteBillingLine = 2,
    AddBulkDiscount = 3,
    DeleteBulkDiscount = 4
}

public static class BillingStateFlagExtension
{
    public static BillingStateFlag GetFlagForAction(this BillingStateFlag stateFlag, UserActionEnum action)
    {
        switch (action)
        {
            case UserActionEnum.AddBillingLine:
                stateFlag |= BillingStateFlag.CanAddBulkDiscounts;
                stateFlag |= BillingStateFlag.CanModifyBillingLines;
                break;
            case UserActionEnum.DeleteBillingLine:
                break;
            case UserActionEnum.AddBulkDiscount:
                break;
            case UserActionEnum.DeleteBulkDiscount:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }

        return stateFlag;
    }
}