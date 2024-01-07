using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Application.Interfaces.Models.Requests.Customers;
using MyApp.Application.Models.Dtos.Customers;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.Customers;

public abstract class CustomerEditReq<TCustomerDto, TCustomer> : BaseEditRequest<TCustomerDto, TCustomer>,
    ICustomerWithDetailsReq
    where TCustomerDto : CustomerWithDetailsDto<TCustomer>
    where TCustomer : Customer
{
    [Required] public Guid Id { get; set; }
    public required CustomerTypeEnum CustomerType { get; set; }

    #region ICustomerWithDetailsReq

    [Required] [MaxLength(50)] public string Email { get; set; }
    [Required] [MaxLength(15)] public string PhoneNumber { get; set; }
    public IEnumerable<IPaymentDto> Payments { get; set; }
    public Guid BillingId { get; set; }
    public Guid ShippinId { get; set; }
    public string BStreet { get; set; }
    public string BCity { get; set; }
    public string BPostalCode { get; set; }
    public string BState { get; set; }
    public string BCountry { get; set; }
    public string SStreet { get; set; }
    public string SCity { get; set; }
    public string SPostalCode { get; set; }
    public string SState { get; set; }
    public string SCountry { get; set; }

    #endregion


    protected CustomerEditReq()
    {
    }

    protected CustomerEditReq(TCustomerDto data)
    {
        Id = data.Id;
        Email = data.Email;
        PhoneNumber = data.PhoneNumber;

        CustomerType = data.CustomerType;
        Controller = data.CustomerType.ToString();

        Payments = data.Payments;

        BillingId = data.BillingDetails.Id;
        ShippinId = data.ShippingDetails.Id;

        BStreet = data.BillingDetails.Street;
        BCity = data.BillingDetails.City;
        BPostalCode = data.BillingDetails.PostalCode;
        BState = data.BillingDetails.State;
        BCountry = data.BillingDetails.Country;

        SStreet = data.ShippingDetails.Street;
        SCity = data.ShippingDetails.City;
        SPostalCode = data.ShippingDetails.PostalCode;
        SState = data.ShippingDetails.State;
        SCountry = data.ShippingDetails.Country;
    }

    public override void WriteTo(TCustomer entity)
    {
        entity.Email = Email;
        entity.PhoneNumber = PhoneNumber;
    }
}