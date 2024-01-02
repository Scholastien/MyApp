using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Customers;

public class CompanyDto : CustomerDto<Company>, ICompanyDto
{
    #region ICompanyDto

    public string Kbis { get; set; }
    public CompanySizeEnum CompanySize { get; set; }

    #endregion
    
    public CompanyDto(){}

    public CompanyDto(Company entity) : base(entity)
    {
        Kbis = entity.Kbis;
        CompanySize = entity.CompanySize;
    }

    public override void WriteTo(Company entity)
    {
        base.WriteTo(entity);
        entity.Kbis = Kbis;
        entity.CompanySize = CompanySize;
    }
}