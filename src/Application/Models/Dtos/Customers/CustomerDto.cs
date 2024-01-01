using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Application.Models.DTOs.CustumersDetails;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.DTOs.Customers;

public abstract class CustomerDto<T>: BaseDto<T>, ICustomerDto
    where T : Customer 
{
    #region ICustomerDto

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Status { get; set; }
    public string StatusText { get; set; }

    #endregion

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
    }

    public override void WriteTo(T customer)
    {
        customer.Email = Email;
        customer.PhoneNumber = PhoneNumber;
        customer.StatusEnum = (CustomerStatusEnum)Status;
        
        customer.LastModifiedOn = DateTimeOffset.Now;
    }
}