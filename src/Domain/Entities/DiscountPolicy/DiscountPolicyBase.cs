using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.DiscountPolicy;

public abstract class DiscountPolicyBase : IAuditableEntity, IIdentifiableByIdEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion

    public required CustomerTypeEnum CustomerType { get; set; }
    public DiscountTypeEnum DiscountType { get; set; }
    public int Amount { get; set; }

    #region Navigation

    public ICollection<Discount> Discounts { get; } = new List<Discount>();

    #endregion

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}