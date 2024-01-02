using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Domain.Entities.Billings;

public class Billing : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity
{
    #region IIdentifiableByIdEntity

    [Key] public Guid Id { get; set; }

    #endregion

    #region Fks

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    #endregion

    #region Navigation

    public ICollection<BillingLine> BillingLines { get; set; } = new List<BillingLine>();

    #endregion

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}