using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Discounts;

[Index(nameof(Value))]
public class Discount : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion

    #region Fks

    public Guid DiscountPolicyId { get; set; }
    public DiscountPolicyBase DiscountPolicy { get; set; } = null!;

    #endregion
    
    public uint Value { get; set; }

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

    [NotMapped] public DiscountUnitEnum? DiscountUnit => DiscountPolicy.DiscountUnit;

    [NotMapped] public string DiscountUnitString => DiscountUnit switch
    {
        DiscountUnitEnum.Flat => "$",
        DiscountUnitEnum.Percentage => "%",
        _ => throw new ArgumentOutOfRangeException(nameof(DiscountUnitString),
            $"DiscountUnit not defined on DiscountPolicyBase entity with id {DiscountPolicy}")
    };

    [NotMapped] public string Name => Value + DiscountUnitString;
}