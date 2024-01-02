using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.BillingsDiscounts;

[PrimaryKey(nameof(DiscountId), nameof(BillingId))]
public class BillingDiscount : BaseEntity
{
    public Guid DiscountId { get; set; }
    public Guid BillingId { get; set; }
}