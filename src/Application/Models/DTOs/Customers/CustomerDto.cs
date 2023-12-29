using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.Customers;

public abstract class CustomerDto<T>: BaseDto<T> where T : Customer 
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }

    protected CustomerDto()
    {
    }

    protected CustomerDto(T customer) : base(customer)
    {
        Id = customer.Id;
        Email = customer.Email;
        PhoneNumber = customer.PhoneNumber;
        Status = (int) customer.StatusEnum;
        StatusText = customer.StatusEnum.ToString();
        // TODO : shipping address
    }

    public override void WriteTo(T customer)
    {
        customer.Email = Email;
        customer.PhoneNumber = PhoneNumber;
        customer.StatusEnum = (CustomerStatusEnum)Status;
        
        customer.LastModifiedOn = DateTimeOffset.Now;
        // TODO : shipping address
    }
}