using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities;

[PrimaryKey(nameof(CustomerId), nameof(BillingId))]
public class Payment : BaseEntity, IAuditableEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid BillingId { get; set; }
    public Billing Billing { get; set; }

    public PaymentTypeEnum PaymentType { get; set; }
    
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
}