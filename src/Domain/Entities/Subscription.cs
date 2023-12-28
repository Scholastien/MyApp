using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities;

public class Subscription : BaseEntity, IAuditableEntity, ISoftDeleteEntity
{
    [Key] 
    public Guid Id { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
}