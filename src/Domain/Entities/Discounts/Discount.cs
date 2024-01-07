using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Entities.DiscountPolicy;

namespace MyApp.Domain.Entities.Discounts;

public class Discount : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion

    #region Fks

    public Guid DiscountPolicyId { get; set; }
    public DiscountPolicyBase DiscountPolicy { get; set; } = null!;

    #endregion

    #region Navigation

    public ICollection<Billing> Billings { get; } = new List<Billing>();
    public ICollection<BillingDiscount> BillingsDiscounts { get; } = new List<BillingDiscount>();

    #endregion

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion

    #region ISoftDeleteEntity

    public bool IsDeleted { get; set; }

    #endregion
}