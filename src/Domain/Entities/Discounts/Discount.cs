using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Discounts;

public class Discount : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

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