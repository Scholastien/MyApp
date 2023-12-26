using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Discounts;

public class BulkDiscount : DiscountPolicy
{
    public int EntrepriseId { get; set; } // only companies can have Bulk discounts
}