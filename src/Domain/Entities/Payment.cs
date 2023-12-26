using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities;

[PrimaryKey(nameof(CustomerId), nameof(SubscriptionId))]
public class Payment : BaseEntity, IAuditableEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Guid SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }

    public PaymentTypeEnum PaymentType { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
}