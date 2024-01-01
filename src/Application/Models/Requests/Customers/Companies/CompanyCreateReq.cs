using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Requests.Customers;

namespace MyApp.Application.Models.Requests.Customers.Companies;

public class CompanyCreateReq : CustomerCreateReq, ICompanyReq
{
    [MaxLength(50)]
    [Required(ErrorMessage = "Kbis is required")]
    public string Kbis { get; set; }
}