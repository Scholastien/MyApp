using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Customers.Companies;

public class CompanyWithDetailsDto : CustomerWithDetailsDto<Company>, ICompanyDto
{
    #region ICompanyDto

    public string Kbis { get; set; }
    public CompanySizeEnum CompanySize { get; set; }

    #endregion
    
    public CompanyWithDetailsDto(){}

    public CompanyWithDetailsDto(Company entity) : base(entity)
    {
        CustomerType = CustomerTypeEnum.Company;
        Kbis = entity.Kbis;
        CompanySize = entity.CompanySize;
    }

    public override void WriteTo(Company entity)
    {
        base.WriteTo(entity);
        entity.Kbis = Kbis;
        entity.CompanySize = CompanySize;
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}