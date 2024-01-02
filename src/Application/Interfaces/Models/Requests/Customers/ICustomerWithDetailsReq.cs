using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Application.Interfaces.Models.Requests.CustomersDetails;

namespace MyApp.Application.Interfaces.Models.Requests.Customers;

public interface ICustomerWithDetailsReq : ICustomerReq, IBothCustomerDetailsReq
{
    public Guid Id { get; set; }
    public Guid BillingId { get; set; }
    public Guid ShippinId { get; set; }
    public IEnumerable<IPaymentDto> Payments { get; set; }
}