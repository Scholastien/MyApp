using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.Discounts;

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

    public ICollection<BillingLine> BillingLines { get; init; } = new List<BillingLine>();
    public ICollection<Discount> Discounts { get; init; } = new List<Discount>();
    public ICollection<BillingDiscount> BillingsDiscounts { get; init; } = new List<BillingDiscount>(); // N'est utilisé que par le AppDbContext pour générer les props de navigation 

    #endregion

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion
}