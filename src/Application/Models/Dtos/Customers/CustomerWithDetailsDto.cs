using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Application.Models.Dtos.CustumersDetails;
using MyApp.Application.Models.Dtos.Payments;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Customers;

public class CustomerWithDetailsDto<T> : CustomerDto<T>, ICustomerWithDetailsDto
    where T : Customer
{
    #region ICustomerWithDetailsDto

    public CustomerTypeEnum CustomerType { get; set; }
    public CustomerDetailsDto BillingDetails { get; set; }
    public CustomerDetailsDto ShippingDetails { get; set; }
    public IEnumerable<PaymentDto> Payments { get; set; }

    #endregion

    protected CustomerWithDetailsDto()
    {
    }

    protected CustomerWithDetailsDto(T entity) : base(entity)
    {
        BillingDetails = new CustomerDetailsDto(entity.BillingDetails);
        ShippingDetails = new CustomerDetailsDto(entity.ShippingDetails);
        Payments = entity.Payments.Select(p => new PaymentDto(p)
        {
            EntityController = CustomerType.ToString()
        });
    }
}