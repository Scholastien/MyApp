using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Billings;

public class BillingLine : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity
{
    #region IIdentifiableByIdEntity
    
    [Key] public Guid Id { get; set; }
    
    #endregion

    public Guid BillingId { get; set; }
    public Billing Billing { get; set; }

    public Product Product { get; set; }
    public int Quantity { get; set; }

    #region IAuditableEntity
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}