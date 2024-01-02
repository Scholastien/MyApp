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

    public IndividualDto(Individual entity) : base(entity)
    {
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