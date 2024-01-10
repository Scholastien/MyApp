namespace MyApp.Domain.Enums;

[Flags]
public enum BillingStateFlag
{
    CanReadPayment = 1 << 0,
    CanEditPayment = 1 << 1,
    CanAddPayment = 1 << 2,
    CanDeletePayment = 1 << 3,

    CanReadDueDate = 1 << 4,
    CanEditDueDate = 1 << 5,
    CanAddDueDate = 1 << 6,
    CanDeleteDueDate = 1 << 7,

    CanReadBillingLines = 1 << 8,
    CanEditBillingLines = 1 << 9,
    CanAddBillingLines = 1 << 10,
    CanDeleteBillingLines = 1 << 11,

    CanReadBulkDiscounts = 1 << 12,
    CanEditBulkDiscounts = 1 << 13,
    CanAddBulkDiscounts = 1 << 14,
    CanDeleteBulkDiscounts = 1 << 15,

    CanReadTargetedDiscounts = 1 << 16,
    CanEditTargetedDiscounts = 1 << 17,
    CanAddTargetedDiscounts = 1 << 18,
    CanDeleteTargetedDiscounts = 1 << 19,

    CanPay = 1 << 20,
    CanDelete = 1 << 21,
    
    // /!\ max value = 32
    // need refactoring soon :
    // => 1 State Column per Table linked to Billing containing values:
    // - CanRead = 1 << 0,
    // - CanEdit = 1 << 2,
    // - CanAdd = 1 << 3,
    // - CanDelete = 1 << 4
    // That State prop should be contained in a interface, that way we can abstract the call and process states regardless of the Object typing
    // A for the values CanPay and CanDelete, it will be a compound of states of the linked entities
}