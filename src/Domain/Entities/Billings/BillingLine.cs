using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Billings;

public class BillingLine : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity
{
    [Key] public Guid Id { get; set; }

    public Guid BillingId { get; set; }
    public Billing Billing { get; set; }

    public Product Product { get; set; }
    public int Quantity { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
}