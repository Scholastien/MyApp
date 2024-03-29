﻿using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.PaymentsHistories;

public class PaymentHistoryCreateReq
{
    public Guid BillingId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid CustomerId { get; set; }
    public required BillingStateFlag StateFlag { get; set; }

}