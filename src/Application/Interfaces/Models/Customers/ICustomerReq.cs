namespace MyApp.Application.Interfaces.Models.Customers;

public interface ICustomerReq
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}