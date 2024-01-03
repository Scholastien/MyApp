using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Payments;

public class Payment : BaseEntity, IAuditableEntity, IIdentifiableByIdEntity
{
    #region IIdentifiableByIdEntity
    
    [Key] public Guid Id { get; set; }
    
    #endregion

    #region Fks
    
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    #endregion
    
    public required PaymentTypeEnum PaymentType { get; set; }
    
    #region IAuditableEntity
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}