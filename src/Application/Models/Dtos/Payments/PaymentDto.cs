using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Domain.Entities.Payments;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Payments;

public class PaymentDto: BaseDto<Payment>, IPaymentDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public PaymentTypeEnum PaymentType { get; set; }
    public required string EntityController { get; set; }

    public PaymentDto(){}
    
    public PaymentDto(Payment entity) : base(entity)
    {
        Id = entity.Id;
        CustomerId = entity.CustomerId;
        PaymentType = entity.PaymentType;
    }

    public override void WriteTo(Payment entity)
    {
        base.WriteTo(entity);
        entity.PaymentType = PaymentType;
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}