using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Requests.Customers.Individuals;

public class IndividualEditReq : CustomerEditReq<IndividualDto, Individual>
{
    [Required] [MaxLength(50)] public string FirstName { get; set; }

    [Required] [MaxLength(50)] public string LastName { get; set; }

    public IndividualEditReq()
    {
    }

    public IndividualEditReq(IndividualDto data) : base(data)
    {
        FirstName = data.FirstName;
        LastName = data.LastName;
    }

    public override void WriteTo(Individual customer)
    {
        base.WriteTo(customer);
        customer.FirstName = FirstName;
        customer.LastName = LastName;
    }
}