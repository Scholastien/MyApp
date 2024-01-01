using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Models.Dtos;

public interface ICompanyDto
{
    public string Kbis { get; set; }
    public CompanySizeEnum CompanySize { get; set; }
}