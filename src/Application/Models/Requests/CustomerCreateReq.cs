using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.Models.Requests;

public class CustomerCreateReq
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(50)]
    public string EmailId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; }
}