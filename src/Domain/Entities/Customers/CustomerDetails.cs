using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Customers;

public class CustomerDetails : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity
{
    #region IIdentifiableByIdEntity
    
    [Key] public Guid Id { get; set; }

    #endregion

    public Guid? BillingDetailsId { get; set; }
    public Guid? ShippingDetailsId { get; set; }

    [MaxLength(100)] public required string Street { get; set; }
    [MaxLength(100)] public required string City { get; set; }
    [MaxLength(100)] public required string PostalCode { get; set; }
    [MaxLength(100)] public required string State { get; set; }
    [MaxLength(100)] public required string Country { get; set; }
    
    #region IAuditableEntity
    
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}