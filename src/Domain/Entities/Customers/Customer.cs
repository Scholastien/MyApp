using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Customers;

public abstract class Customer : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity
    
    [Key] public Guid Id { get; set; }
    
    #endregion
    
    public CustomerTypeEnum CustomerType { get; set; }
    public ICollection<Payment> Payments { get; } = new List<Payment>();
    public CustomerStatusEnum StatusEnum { get; set; }
    [MaxLength(100)] public required string Email { get; set; }
    [MaxLength(15)] public required string PhoneNumber { get; set; }
    public Guid? BillingDetailsId { get; set; }
    public CustomerDetails BillingDetails { get; set; } = null!; // Reference navigation to dependent
    public Guid? ShippingDetailsId { get; set; }
    public CustomerDetails ShippingDetails { get; set; } = null!; // Reference navigation to dependent

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