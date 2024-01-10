using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Core.Models.Interface;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.PaymentHistories;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Payments;

[PrimaryKey(nameof(Id), nameof(CustomerId))]
public class Payment : BaseEntity, IAuditableEntity, IIdentifiableByIdEntity, ISoftDeleteEntity
{
    #region IIdentifiableByIdEntity

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    #endregion

    #region Fks

    public required Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }

    #endregion

    #region Navigation

    public ICollection<PaymentHistory> PaymentHistories { get; init; } = new List<PaymentHistory>();

    #endregion

    public required PaymentTypeEnum PaymentType { get; set; }

    #region IAuditableEntity

    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }

    #endregion

    public bool IsDeleted { get; set; }
}