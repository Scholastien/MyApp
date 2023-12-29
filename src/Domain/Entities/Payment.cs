using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities;

public class Payment : BaseEntity, IAuditableEntity, IIdentifiableByIdEntity
{
    [Key] public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public required Customer Customer { get; set; }

    public required ICollection<Billing> Billing { get; set; }

    public PaymentTypeEnum PaymentType { get; set; }


    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
}