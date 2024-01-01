using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Application.Models.DTOs.CustumersDetails;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.Customers;

public class CustomerWithDetailsDto<T> : CustomerDto<T>, ICustomerWithDetailsDto
    where T : Customer
{
    #region ICustomerWithDetailsDto

    public CustomerTypeEnum CustomerType { get; set; }
    public CustomerDetailsDto BillingDetails { get; set; }
    public CustomerDetailsDto ShippingDetails { get; set; }

    #endregion

    protected CustomerWithDetailsDto()
    {
    }

    protected CustomerWithDetailsDto(T customer) : base(customer)
    {
        BillingDetails = new CustomerDetailsDto(customer.BillingDetails);
        ShippingDetails = new CustomerDetailsDto(customer.ShippingDetails);
    }

    public override void WriteTo(T customer)
    {
        base.WriteTo(customer);

        BillingDetails.WriteTo(customer.BillingDetails);
        ShippingDetails.WriteTo(customer.ShippingDetails);
    }
}