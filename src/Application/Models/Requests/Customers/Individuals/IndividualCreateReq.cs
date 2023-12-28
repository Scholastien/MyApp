using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.Models.Requests.Customers.Individuals;

public class IndividualCreateReq : CustomerCreateReq
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
}