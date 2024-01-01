namespace MyApp.Application.Interfaces.Models.Requests.Customers;

public interface ICustomerReq
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}