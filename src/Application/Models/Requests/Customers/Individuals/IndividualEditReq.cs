using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Requests.Customers;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Requests.Customers.Individuals;

public class IndividualEditReq : CustomerEditReq<IndividualWithDetailsDto, Individual>, IIndividualReq
{
    [Required] [MaxLength(50)] public string FirstName { get; set; }

    [Required] [MaxLength(50)] public string LastName { get; set; }

    public IndividualEditReq()
    {
    }

    public IndividualEditReq(IndividualWithDetailsDto data) : base(data)
    {
        FirstName = data.FirstName;
        LastName = data.LastName;
    }

    public override void WriteTo(Individual entity)
    {
        base.WriteTo(entity);
        entity.FirstName = FirstName;
        entity.LastName = LastName;
    }
}