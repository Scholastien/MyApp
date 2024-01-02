using MyApp.Application.Models.DTOs.CustumersDetails;
using MyApp.Application.Models.DTOs.Payments;
using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Models.Dtos;

public interface ICustomerWithDetailsDto
{
    public CustomerTypeEnum CustomerType { get; set; }
    public CustomerDetailsDto BillingDetails { get; set; }
    public CustomerDetailsDto ShippingDetails { get; set; }
    public IEnumerable<PaymentDto> Payments { get; set; }
}