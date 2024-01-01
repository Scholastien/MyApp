using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Models.Requests.Customers;

public interface ICompanyReq
{
    public string Kbis { get; set; }
    public CompanySizeEnum CompanySize { get; set; }
}