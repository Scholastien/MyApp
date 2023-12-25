using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enum;

namespace MyApp.Domain.Entities;

public class Customer: BaseEntity, IAuditableEntity, ISoftDeleteEntity
{
    [Key]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailId { get; set; }
    public string Address { get; set; }
    public CustomerStatus Status { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedOn { get; set; }
    public bool IsDeleted { get; set; }
}