using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Payments;
using MyApp.Application.Models.Requests.Payment;
using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<IBaseResponse<PaymentDto>> CreatePayment(PaymentCreateReq createReq, CancellationToken ctk = default);
    Task UpdatePayment(PaymentEditReq editReq, CancellationToken ctk = default);
    Task DeletePaymentWithId(Guid id, CancellationToken ctk = default);
    Task<PaymentDto> GetPaymentDtoById(Guid id, CustomerTypeEnum customerType, CancellationToken ctk = default);

}