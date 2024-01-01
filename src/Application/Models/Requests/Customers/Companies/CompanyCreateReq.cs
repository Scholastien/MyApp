using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Requests.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.Customers.Companies;

public class CompanyCreateReq : CustomerCreateReq, ICompanyReq
{
    [MaxLength(50)]
    [Required(ErrorMessage = "Kbis is required")]
    public string Kbis { get; set; }
    
    [Required(ErrorMessage = "CompanySize is required")]
    public CompanySizeEnum CompanySize { get; set; }
}