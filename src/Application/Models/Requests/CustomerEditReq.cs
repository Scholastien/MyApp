using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Models.Requests;

public class CustomerEditReq
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(50)]
    public string EmailId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Address { get; set; }

    public CustomerEditReq()
    {
    }

    public CustomerEditReq(CustomerDTO data)
    {
        Id = data.Id;
        FirstName = data.FirstName;
        LastName = data.LastName;
        EmailId = data.EmailId;
        Address = data.Address;
    }

    public void WriteTo(Customer customer)
    {
        customer.FirstName = FirstName;
        customer.LastName = LastName;
        customer.EmailId = EmailId;
        customer.Address = Address;
        customer.LastModifiedOn = DateTimeOffset.Now;
    }
}