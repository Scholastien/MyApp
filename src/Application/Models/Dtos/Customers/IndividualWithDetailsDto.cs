using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Customers;

public class IndividualWithDetailsDto : CustomerWithDetailsDto<Individual>, IIndividualDto
{
    #region IIndividualDto

    public string FirstName { get; set; }
    public string LastName { get; set; }

    #endregion
    
    public IndividualWithDetailsDto(){}

    public IndividualWithDetailsDto(Individual entity) : base(entity)
    {
        CustomerType = CustomerTypeEnum.Individual;
        FirstName = entity.FirstName;
        LastName = entity.LastName;
    }

    public override void WriteTo(Individual entity)
    {
        base.WriteTo(entity);
        entity.FirstName = FirstName;
        entity.LastName = LastName;
    }
}