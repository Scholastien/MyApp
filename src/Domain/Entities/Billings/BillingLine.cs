using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.Products;

namespace MyApp.Domain.Entities.Billings;

public class BillingLine : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity
{
    #region IIdentifiableByIdEntity
    
    [Key] public Guid Id { get; set; }
    
    #endregion

    #region Fks
    
    public Guid BillingId { get; set; }
    public Billing Billing { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    #endregion
    public uint Quantity { get; set; }

    #region IAuditableEntity
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}