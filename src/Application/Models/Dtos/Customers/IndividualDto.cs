using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.DTOs.Customers;

public class IndividualDto : CustomerDto<Individual>, IIndividualDto
{
    #region IIndividualDto

    public string FirstName { get; set; }
    public string LastName { get; set; }

    #endregion
    
    public IndividualDto(){}

    public IndividualDto(Individual customer) : base(customer)
    {
        FirstName = customer.FirstName;
        LastName = customer.LastName;
    }

    public override void WriteTo(Individual customer)
    {
        base.WriteTo(customer);
        customer.FirstName = FirstName;
        customer.LastName = LastName;
    }
}