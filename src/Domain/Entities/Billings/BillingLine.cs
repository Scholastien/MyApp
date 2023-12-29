using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Billings;

public class BillingLine: BaseEntity, IAuditableEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public Guid Id { get; set; }
    
    public Guid BillingId { get; set; }
    public Billing Billing { get; set; }
    
    public required Product Product { get; set; }
    public int Quantity { get; set; }
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
}