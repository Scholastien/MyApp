using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Core.Models;

[PrimaryKey(nameof(CustomerId), nameof(BillingId))]
public abstract class DiscountPolicy: IAuditableEntity
{
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid BillingId { get; set; }
    public Billing Billing { get; set; }
    
    public int Amount { get; set; }
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
}