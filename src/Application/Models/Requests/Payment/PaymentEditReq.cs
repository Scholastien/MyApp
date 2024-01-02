using MyApp.Application.Models.Dtos.Payments;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.Payment;

public class PaymentEditReq : BaseEditRequest<PaymentDto, Domain.Entities.Payment>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public PaymentTypeEnum PaymentType { get; set; }
    public required string EntityController { get; set; }
    public PaymentEditReq()
    {
    }

    public PaymentEditReq(PaymentDto data) : base(data)
    {
        Id = data.Id;
        CustomerId = data.CustomerId;
        PaymentType = data.PaymentType;
        EntityController = data.EntityController;
    }

    public override void WriteTo(Domain.Entities.Payment entity)
    {
        base.WriteTo(entity);
        entity.PaymentType = PaymentType;
    }
}