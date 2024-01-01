using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.CustumersDetails;

public class CustomerDetailsDto : BaseDto<CustomerDetails>
{
    public Guid Id { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
    public bool IsBilling { get; set; }
    public Guid? CustomerId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public CustomerDetailsDto()
    {
    }

    public CustomerDetailsDto(CustomerDetails details) : base(details)
    {
        Id = details.Id;
        IsBilling = details.BillingDetailsId != null;
        CustomerId = IsBilling ? details.BillingDetailsId : details.ShippingDetailsId;
        Street = details.Street;
        City = details.City;
        PostalCode = details.PostalCode;
        State = details.State;
        Country = details.Country;
    }

    public override void WriteTo(CustomerDetails details)
    {
        details.Street = Street;
        details.City = City;
        details.PostalCode = PostalCode;
        details.State = State;
        details.Country = Country;
    }
}