using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests;

public class IdentityUserRegistrationReq
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "LastName is required")]
    [StringLength(100)]
    public string LastName { get; set; }
        
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }
        
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "The Password and Confirm Password do not match")]
    public string ConfirmPassword { get; set; }

    public IdentityUserBase ToNewIdentityUser()
    {
        return new IdentityUserBase()
        {
            FirstName = FirstName,
            LastName = LastName,
            UserName = Email,
            NormalizedUserName = Email,
            Email = Email,
            IsDeleted = false,
            EmailConfirmed = true, // TODO: mail verification
            Role = RoleEnum.None, // TODO: assignation de Role
        };
    }
}