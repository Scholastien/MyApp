using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.Customers;

public class CompanyWithDetailsDto : CustomerWithDetailsDto<Company>, ICompanyDto
{
    #region ICompanyDto

    public string Kbis { get; set; }

    #endregion
    
    public CompanyWithDetailsDto(){}

    public CompanyWithDetailsDto(Company customer) : base(customer)
    {
        CustomerType = CustomerTypeEnum.Company;
        Kbis = customer.Kbis;
    }

    public override void WriteTo(Company customer)
    {
        base.WriteTo(customer);
        customer.Kbis = Kbis;
    }
}