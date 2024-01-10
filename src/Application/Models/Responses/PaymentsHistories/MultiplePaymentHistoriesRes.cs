using MyApp.Application.Models.Dtos.PaymentsHistories;
using MyApp.Application.Models.Requests.PaymentsHistories;
using MyApp.Domain.Entities.PaymentHistories;

namespace MyApp.Application.Models.Responses.PaymentsHistories;

public class MultiplePaymentHistoriesRes : MultipleBaseResponse<PaymentHistoryDto, PaymentHistory>
{
    public required PaymentHistoryCreateReq CreateReq { get; set; } 
    public required Guid CustomerId { get; set; }
}