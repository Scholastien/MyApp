using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Customers;

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

    protected CustomerDto(T entity) : base(entity)
    {
        Id = entity.Id;
        Email = entity.Email;
        PhoneNumber = entity.PhoneNumber;
        Status = (int) entity.StatusEnum;
        StatusText = entity.StatusEnum.ToString();
    }

    public override void WriteTo(T entity)
    {
        entity.Email = Email;
        entity.PhoneNumber = PhoneNumber;
        entity.StatusEnum = (CustomerStatusEnum)Status;
        
        entity.LastModifiedOn = DateTimeOffset.Now;
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}