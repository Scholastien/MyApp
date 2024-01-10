using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Entities.PaymentHistories;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Billings;

[PrimaryKey(nameof(Id), nameof(CustomerId))]
public class Billing : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    #endregion

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion

    #region Fks

    public required Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    #endregion

    #region Navigation

    public ICollection<BillingLine> BillingLines { get; init; } = new List<BillingLine>();
    public ICollection<Discount> Discounts { get; init; } = new List<Discount>();

    public ICollection<BillingDiscount> BillingsDiscounts { get; init; } =
        new List<BillingDiscount>(); // Used by AppDbContext to generate navigation props

    public ICollection<PaymentHistory> PaymentHistories { get; init; } = new List<PaymentHistory>();

    #endregion

    #region ISoftDeleteEntity
    
    public bool IsDeleted { get; set; }

    #endregion

    public BillingStateFlag StateFlag { get; set; } = BillingStateFlag.CanAddPayment 
                                                      | BillingStateFlag.CanAddBillingLines 
                                                      | BillingStateFlag.CanDeleteBillingLines 
                                                      | BillingStateFlag.CanDelete;
}