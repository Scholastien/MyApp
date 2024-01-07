using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.Payments;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Customers;

public abstract class Customer : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion
    
    /// <summary>
    /// Discriminant which allow distinguish between Company and Individual
    /// </summary>
    public CustomerTypeEnum CustomerType { get; set; }
    public CustomerStatusEnum StatusEnum { get; set; }
    [MaxLength(100)] public required string Email { get; set; }
    [MaxLength(15)] public required string PhoneNumber { get; set; }
    
    #region Navigation

    public Guid? BillingDetailsId { get; set; }
    public CustomerDetails BillingDetails { get; set; } = null!;
    public Guid? ShippingDetailsId { get; set; }
    public CustomerDetails ShippingDetails { get; set; } = null!;

    public ICollection<Payment> Payments { get; } = new List<Payment>();
    public ICollection<Billing> Billings { get; } = new List<Billing>();

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