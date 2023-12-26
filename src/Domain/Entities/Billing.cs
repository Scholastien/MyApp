using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities;

public class Billing : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public Guid SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }
    public ICollection<DiscountPolicy> DiscountPolicies { get; } = new List<DiscountPolicy>();

}