using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.DiscountPolicy;

[Index(nameof(CustomerType))]
public abstract class DiscountPolicyBase : BaseEntity, IAuditableEntity, IIdentifiableByIdEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion

    [MaxLength(100)] public required string Name { get; set; }
    public required CustomerTypeEnum CustomerType { get; set; }
    public required DiscountTypeEnum DiscountType { get; set; }
    public required DiscountUnitEnum DiscountUnit { get; set; }
    public int MaxValue { get; set; }

    #region Navigation

    public ICollection<Discount> Discounts { get; } = new List<Discount>();

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