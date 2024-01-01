using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.Customers;

public class CompanyDto : CustomerDto<Company>, ICompanyDto
{
    #region ICompanyDto

    public string Kbis { get; set; }
    public CompanySizeEnum CompanySize { get; set; }

    #endregion
    
    public CompanyDto(){}

    public CompanyDto(Company customer) : base(customer)
    {
        Kbis = customer.Kbis;
        CompanySize = customer.CompanySize;
    }

    public override void WriteTo(Company customer)
    {
        base.WriteTo(customer);
        customer.Kbis = Kbis;
        customer.CompanySize = CompanySize;
    }
}