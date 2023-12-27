using MyApp.Domain.Entities;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs;

public class CustomerDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailId { get; set; }
    public string Address { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }
    
    public CustomerDTO(){}

    public CustomerDTO(Customer customer)
    {
        Id = customer.Id;
        FirstName = customer.FirstName;
        LastName = customer.LastName;
        EmailId = customer.EmailId;
        Address = customer.Address;
        Status = (int) customer.Status;
        StatusText = customer.Status.ToString();
    }

    public void WriteTo(Customer customer)
    {
        customer.FirstName = FirstName;
        customer.LastName = LastName;
        customer.EmailId = EmailId;
        customer.Address = Address;
        customer.Status = (CustomerStatus)Status;
    }
}