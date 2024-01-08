using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;

namespace MyApp.Domain.Entities.BillingsDiscounts;

[PrimaryKey(nameof(DiscountId), nameof(BillingId))]
public class BillingDiscount : BaseEntity, IAuditableEntity
{
    public required Guid DiscountId { get; set; }
    public required Guid BillingId { get; set; }
    public required Guid BillingCustomerId { get; set; }

    #region IAuditableEntity

    public required Guid CreatedBy { get; set; }
    public required DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}