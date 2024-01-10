using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.Payments;

namespace MyApp.Domain.Entities.PaymentHistories;

[PrimaryKey(nameof(Id), nameof(BillingId), nameof(PaymentId))]
public class PaymentHistory : BaseEntity, IIdentifiableByIdEntity, IAuditableEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion

    #region Fks
    public required Guid BillingId { get; set; }
    public Billing Billing { get; set; } = null!;
    public required Guid PaymentId { get; set; }
    public Payment Payment { get; set; } = null!;

    #endregion

    public DateTimeOffset? DueDate { get; set; } // while DueDate is null, Billing is still draft
    public DateTimeOffset? PaidDate { get; set; } // while PaidDate is null, Billing is Draft or Validated
}