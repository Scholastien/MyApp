using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Domain.Entities.Customers;

namespace MyApp.Application.Models.Requests.Customers;

public class CustomerEditReq
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }

    public CustomerEditReq()
    {
    }

    public CustomerEditReq(CustomerDto data)
    {
        Id = data.Id;
        Email = data.Email;
        
        // TODO : shipping address
    }

    public void WriteTo(Customer customer)
    {
        customer.Email = Email;
        customer.LastModifiedOn = DateTimeOffset.Now;
        
        // TODO : shipping address
    }
}