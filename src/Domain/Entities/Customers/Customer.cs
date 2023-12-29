using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Customers;

public abstract class Customer : BaseEntity, IAuditableEntity, ISoftDeleteEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }

    public CustomerTypeEnum CustomerType { get; set; }
    public ICollection<Payment> Payments { get; } = new List<Payment>();
    public CustomerStatusEnum StatusEnum { get; set; }
    [MaxLength(100)] public required string Email { get; set; }
    [MaxLength(15)] public required string PhoneNumber { get; set; }
    
    public int? BillingDetailsId { get; set; }
    public CustomerDetails BillingDetails { get; set; } = null!; // Reference navigation to dependent
    public int? ShippingDetailsId { get; set; }
    public CustomerDetails ShippingDetails { get; set; } = null!; // Reference navigation to dependent

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
}