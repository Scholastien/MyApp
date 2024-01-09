using MyApp.Application.Models.Dtos.PaymentsHistories;
using MyApp.Domain.Entities.PaymentHistories;

namespace MyApp.Application.Models.Requests.PaymentsHistories;

public class PaymentHistoryEditReq : BaseEditRequest<PaymentHistoryDto, PaymentHistory>
{
    public Guid Id { get; set; }
    public Guid BillingId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTimeOffset? DueDate { get; set; }
    public DateTimeOffset? PaidDate { get; set; }

    public PaymentHistoryEditReq()
    {
    }

    public PaymentHistoryEditReq(PaymentHistoryDto data) : base(data)
    {
        Id = data.Id;
        BillingId = data.BillingId;
        PaymentId = data.PaymentId;
        CustomerId = data.CustomerId;
        DueDate = data.DueDate;
        PaidDate = data.PaidDate;
    }

    public override void WriteTo(PaymentHistory entity)
    {
        base.WriteTo(entity);
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}