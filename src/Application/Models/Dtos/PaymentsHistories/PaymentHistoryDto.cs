﻿using MyApp.Domain.Entities.PaymentHistories;

namespace MyApp.Application.Models.Dtos.PaymentsHistories;

public class PaymentHistoryDto : BaseDto<PaymentHistory>
{
    public Guid Id { get; set; }
    public Guid BillingId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTimeOffset? DueDate { get; set; }
    public DateTimeOffset? PaidDate { get; set; }

    public PaymentHistoryDto()
    {
    }

    public PaymentHistoryDto(PaymentHistory entity) : base(entity)
    {
        Id = entity.Id;
        BillingId = entity.BillingId;
        PaymentId = entity.PaymentId;
        CustomerId = entity.Billing.CustomerId;
        DueDate = entity.DueDate;
        PaidDate = entity.PaidDate;
    }

    public override void WriteTo(PaymentHistory entity)
    {
        base.WriteTo(entity);
        entity.LastModifiedOn = DateTimeOffset.Now;
        entity.DueDate = DueDate;
        entity.PaidDate = PaidDate;
    }
}