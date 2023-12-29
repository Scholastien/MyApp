using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Billings;

public class Billing : BaseEntity, IAuditableEntity
{
    [Key] public Guid Id { get; set; }

    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; } = null!;

    public ICollection<BillingLine> BillingLines { get; set; } = new List<BillingLine>();

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
}