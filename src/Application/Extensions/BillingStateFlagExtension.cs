using MyApp.Domain.Enums;

namespace MyApp.Application.Extensions;

public static class BillingStateFlagExtension
{
    public static BillingStateFlag GetFlagForAction(this BillingStateFlag stateFlag, UserActionEnum action)
    {
        switch (action)
        {
            case UserActionEnum.AddBillingLine:
                stateFlag |= BillingStateFlag.CanAddBulkDiscounts;
                stateFlag |= BillingStateFlag.CanDeleteBulkDiscounts;
                stateFlag |= BillingStateFlag.CanDeleteBillingLines;
                break;
            case UserActionEnum.DeleteBillingLine:
                stateFlag ^= BillingStateFlag.CanAddBulkDiscounts;
                stateFlag ^= BillingStateFlag.CanDeleteBulkDiscounts;
                break;
            case UserActionEnum.AddBulkDiscount:
                stateFlag ^= BillingStateFlag.CanAddBillingLines;
                stateFlag ^= BillingStateFlag.CanDeleteBillingLines;
                break;
            case UserActionEnum.DeleteBulkDiscount:
                stateFlag |= BillingStateFlag.CanAddBillingLines;
                stateFlag |= BillingStateFlag.CanDeleteBillingLines;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }

        return stateFlag;
    }
}