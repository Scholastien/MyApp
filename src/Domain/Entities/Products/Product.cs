using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.Billings;

namespace MyApp.Domain.Entities.Products;

public class Product : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion

    [Required] [MaxLength(100)] public required string Name { get; set; }

    [Required] public required float Price { get; set; }

    #region Navigation

    public ICollection<BillingLine> BillingLines { get; } = new List<BillingLine>();

    #endregion

    #region IAuditableEntity
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion

    #region ISoftDeleteEntity

    public bool IsDeleted { get; set; }

    #endregion
}