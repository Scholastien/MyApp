using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Customers;

namespace MyApp.Application.Models.Requests.Customers.Individuals;

public class IndividualCreateReq : CustomerCreateReq, IIndividualReq
{
    [Required(ErrorMessage = "FirstName is required")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    [MaxLength(50)]
    public string LastName { get; set; }
}