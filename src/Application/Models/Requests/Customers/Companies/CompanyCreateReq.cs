using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.Models.Requests.Customers.Companies;

public class CompanyCreateReq : CustomerCreateReq
{
    [Required]
    [MaxLength(50)]
    public string Kbis { get; set; }
}