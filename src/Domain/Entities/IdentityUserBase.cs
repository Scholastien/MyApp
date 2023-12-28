using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities;

public sealed class IdentityUserBase : IdentityUser, ISoftDeleteEntity
{
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public RoleEnum Role { get; set; }
    public bool IsDeleted { get; set; }
}