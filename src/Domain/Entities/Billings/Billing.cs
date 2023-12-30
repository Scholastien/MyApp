using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Billings;

public class Billing : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity
{
    #region IIdentifiableByIdEntity
    
    [Key] public Guid Id { get; set; }
    
    #endregion

    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; } = null!;

    public ICollection<BillingLine> BillingLines { get; set; } = new List<BillingLine>();

    #region IAuditableEntity
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}