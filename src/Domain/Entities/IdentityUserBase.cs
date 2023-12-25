using Microsoft.AspNetCore.Identity;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities;

public sealed class IdentityUserBase : IdentityUser, ISoftDeleteEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public RoleEnum Role { get; set; }
    public bool IsDeleted { get; set; }
}