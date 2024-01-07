namespace MyApp.Domain.Enums;

public enum DiscountUnitEnum
{
    /// <summary>
    /// Flat based discount on price (voucher, gift card)
    /// </summary>
    Flat = 1,
    /// <summary>
    /// Percentage based discount on price (X %)
    /// </summary>
    Percentage = 2
}