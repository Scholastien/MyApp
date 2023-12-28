using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.DTOs.Customers;

public class IndividualDto : CustomerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public IndividualDto(){}

    public IndividualDto(Individual customer) : base(customer)
    {
        FirstName = customer.FirstName;
        LastName = customer.LastName;
    }

    public void WriteTo(Individual customer)
    {
        base.WriteTo(customer);
        customer.FirstName = FirstName;
        customer.LastName = LastName;
    }
}