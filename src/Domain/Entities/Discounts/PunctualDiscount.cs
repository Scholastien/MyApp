using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Discounts;

public class PunctualDiscount : DiscountPolicy
{
    public DiscountTypeEnum DiscountType { get; set; }
}