using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Requests.Customers;
using MyApp.Application.Models.Dtos.Customers.Companies;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.Customers.Companies;

public class CompanyEditReq : CustomerEditReq<CompanyWithDetailsDto, Company>, ICompanyReq
{
    [Required] [MaxLength(50)] public string Kbis { get; set; }
    public CompanySizeEnum CompanySize { get; set; }

    public CompanyEditReq()
    {
    }

    public CompanyEditReq(CompanyWithDetailsDto data) : base(data)
    {
        Kbis = data.Kbis;
        CompanySize = data.CompanySize;
    }

    public override void WriteTo(Company entity)
    {
        base.WriteTo(entity);
        entity.Kbis = Kbis;
        entity.CompanySize = CompanySize;
    }
}