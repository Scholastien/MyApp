using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Requests.Customers;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Requests.Customers.Companies;

public class CompanyEditReq : CustomerEditReq<CompanyWithDetailsDto, Company>, ICompanyReq
{
    [Required] [MaxLength(50)] public string Kbis { get; set; }

    public CompanyEditReq()
    {
    }

    public CompanyEditReq(CompanyWithDetailsDto data) : base(data)
    {
        Kbis = data.Kbis;
    }

    public override void WriteTo(Company customer)
    {
        base.WriteTo(customer);
        customer.Kbis = Kbis;
    }
}