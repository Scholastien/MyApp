using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Discounts;

public abstract class DiscountPolicy : IAuditableEntity, IIdentifiableByIdEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public DiscountTypeEnum DiscountType { get; set; }
    public int Amount { get; set; }

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}