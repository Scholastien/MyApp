using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.Models.Requests;

public class IdentityUserLoginReq
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Display(Name = "Remember me")] 
    public bool RememberMe { get; set; }
}