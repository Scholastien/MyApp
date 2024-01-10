using MyApp.Application.Models.Dtos.PaymentsHistories;
using MyApp.Application.Models.Requests.PaymentsHistories;
using MyApp.Application.Models.Responses.PaymentsHistories;

namespace MyApp.Application.Interfaces.Services;

public interface IPaymentHistoryService
{
    Task<PaymentHistoryRes> CreatePaymentHistory(PaymentHistoryCreateReq createReq, CancellationToken ctk = default);
    Task UpdatePaymentHistory(PaymentHistoryEditReq editReq, CancellationToken ctk = default);
    Task<PaymentHistoryDto> GetPaymentHistoryDtoById(Guid id, Guid billingId, Guid paymentId, CancellationToken ctk = default);
    Task<MultiplePaymentHistoriesRes> GetAllPaymentHistoriesForBillingId(Guid billingId, CancellationToken ctk = default);
    Task<Guid> DeletePaymentHistoryWithId(Guid id, CancellationToken ctk = default);
}