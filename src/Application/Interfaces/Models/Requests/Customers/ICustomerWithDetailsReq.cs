using MyApp.Application.Interfaces.Models.Requests.CustomersDetails;

namespace MyApp.Application.Interfaces.Models.Requests.Customers;

public interface ICustomerWithDetailsReq : ICustomerReq, IBothCustomerDetailsReq
{
    public Guid BillingId { get; set; }
    public Guid ShippinId { get; set; }
}