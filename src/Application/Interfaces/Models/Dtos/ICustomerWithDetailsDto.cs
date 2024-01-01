using MyApp.Application.Models.DTOs.CustumersDetails;
using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Models.Dtos;

public interface ICustomerWithDetailsDto
{
    public CustomerTypeEnum CustomerType { get; set; }
    public CustomerDetailsDto BillingDetails { get; set; }
    public CustomerDetailsDto ShippingDetails { get; set; }
}