namespace MyApp.Domain.Enums;

public enum BillingStateEnum
{
    /// <summary>
    /// Draft while Payment is unassigned
    /// </summary>
    Draft = 1,
    /// <summary>
    /// Ready when Payment is assigned and DueDate isn't filled
    /// </summary>
    Ready = 2,
    /// <summary>
    /// Waiting while waiting for a payment to be paid (PaidDate)
    /// </summary>
    Waiting= 3,
    /// <summary>
    /// Late when DueDate is greater than DateTime.Now regardless of the existence of a Payment method
    /// </summary>
    Late = 4,
    /// <summary>
    /// Paid when PaidDate is filled regardless of the existence of a Payment method
    /// </summary>
    Paid = 5,
}