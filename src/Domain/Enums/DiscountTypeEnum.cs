namespace MyApp.Domain.Enums;

public enum DiscountTypeEnum
{
    /// <summary>
    /// Applied on the Total of a specific bill
    /// </summary>
    Bulk = 1,
    /// <summary>
    /// Applied on a Billing line of a specific bill
    /// </summary>
    Targeted = 2
}