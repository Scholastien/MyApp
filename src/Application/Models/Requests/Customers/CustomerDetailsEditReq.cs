using MyApp.Application.Models.DTOs.CustumersDetails;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.Customers;

public class CustomerDetailsEditReq : BaseEditRequest<CustomerDetailsDto, CustomerDetails>
{
    public Guid Id { get; set; }
    public required CustomerTypeEnum CustomerType { get; set; }
    public bool IsBilling { get; set; }
    public Guid? CustomerId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    
    public CustomerDetailsEditReq()
    {
    }

    public CustomerDetailsEditReq(CustomerDetailsDto dto)
    {
        Id = dto.Id;
        CustomerType = dto.CustomerType;
        Controller = dto.CustomerType.ToString();
        IsBilling = dto.IsBilling;
        CustomerId = dto.CustomerId;
        Street = dto.Street;
        City = dto.City;
        PostalCode = dto.PostalCode;
        State = dto.State;
        Country = dto.Country;
    }

    public override void WriteTo(CustomerDetails entity)
    {
        base.WriteTo(entity);
        
        entity.Street=Street;
        entity.City=City;
        entity.PostalCode=PostalCode;
        entity.State=State;
        entity.Country=Country;
    }
}