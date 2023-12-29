using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.DTOs.Customers;

public class CompanyDto : CustomerDto<Company>
{
    public string Kbis { get; set; }
    
    public CompanyDto(){}

    public CompanyDto(Company customer) : base(customer)
    {
        Kbis = customer.Kbis;
    }

    public override void WriteTo(Company customer)
    {
        base.WriteTo(customer);
        customer.Kbis = Kbis;
    }
}