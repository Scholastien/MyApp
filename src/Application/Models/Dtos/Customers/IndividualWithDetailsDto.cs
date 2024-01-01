using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.Customers;

public class IndividualWithDetailsDto : CustomerWithDetailsDto<Individual>, IIndividualDto
{
    #region IIndividualDto

    public string FirstName { get; set; }
    public string LastName { get; set; }

    #endregion
    
    public IndividualWithDetailsDto(){}

    public IndividualWithDetailsDto(Individual customer) : base(customer)
    {
        CustomerType = CustomerTypeEnum.Individual;
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