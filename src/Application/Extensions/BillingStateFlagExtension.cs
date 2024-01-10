using MyApp.Domain.Enums;

namespace MyApp.Application.Extensions;

public static class BillingStateFlagExtension
{
    public static BillingStateFlag GetFlagForAction(this BillingStateFlag stateFlag, UserActionEnum action)
    {
        switch (action)
        {
            case UserActionEnum.AddBillingLine:
                stateFlag |= BillingStateFlag.CanReadBulkDiscounts;
                stateFlag |= BillingStateFlag.CanEditBulkDiscounts;
                stateFlag |= BillingStateFlag.CanAddBulkDiscounts;
                stateFlag |= BillingStateFlag.CanDeleteBulkDiscounts;
                stateFlag |= BillingStateFlag.CanReadPayment;
                stateFlag |= BillingStateFlag.CanEditPayment;
                stateFlag |= BillingStateFlag.CanAddPayment;
                stateFlag |= BillingStateFlag.CanDeletePayment;
                break;
            // Happens when last line is deleted
            case UserActionEnum.DeleteBillingLine:
                stateFlag ^= BillingStateFlag.CanReadBulkDiscounts;
                stateFlag ^= BillingStateFlag.CanEditBulkDiscounts;
                stateFlag ^= BillingStateFlag.CanAddBulkDiscounts;
                stateFlag ^= BillingStateFlag.CanDeleteBulkDiscounts;
                stateFlag ^= BillingStateFlag.CanReadPayment;
                stateFlag ^= BillingStateFlag.CanEditPayment;
                stateFlag ^= BillingStateFlag.CanAddPayment;
                stateFlag ^= BillingStateFlag.CanDeletePayment;
                break;
            case UserActionEnum.AddBulkDiscount:
                stateFlag ^= BillingStateFlag.CanEditBillingLines;
                stateFlag ^= BillingStateFlag.CanAddBillingLines;
                stateFlag ^= BillingStateFlag.CanDeleteBillingLines;
                break;
            // Happens when last line is deleted
            case UserActionEnum.DeleteBulkDiscount:
                stateFlag |= BillingStateFlag.CanEditBillingLines;
                stateFlag |= BillingStateFlag.CanAddBillingLines;
                stateFlag |= BillingStateFlag.CanDeleteBillingLines;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(action), action, null);
        }

        return stateFlag;
    }
}