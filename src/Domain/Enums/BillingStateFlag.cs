﻿namespace MyApp.Domain.Enums;

[Flags]
public enum BillingStateFlag
{
    CanAddPayment = 1 << 0,
    CanModifyPayment = 1 << 1,
    CanAddDueDate = 1 << 2,
    CanModifyDueDate = 1 << 3,
    CanAddBillingLines = 1 << 4,
    CanModifyBillingLines = 1 << 5,
    CanAddBulkDiscounts = 1 << 6,
    CanDeleteBulkDiscounts = 1 << 7,
    CanAddTargetedDiscount = 1 << 8,
    CanDeleteTargetedDiscount = 1 << 9,
    CanPay = 1 << 10,
    CanDelete = 1 << 11,
}