using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.Customers;

public abstract class CustomerDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }

    protected CustomerDto()
    {
    }

    protected CustomerDto(Customer customer)
    {
        Id = customer.Id;
        Email = customer.Email;
        Status = (int) customer.StatusEnum;
        StatusText = customer.StatusEnum.ToString();
        // TODO : shipping address
    }

    protected void WriteTo(Customer customer)
    {
        customer.Email = Email;
        customer.StatusEnum = (CustomerStatusEnum)Status;
        // TODO : shipping address
    }
}