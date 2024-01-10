using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Payments;
using MyApp.Application.Models.Requests.Payments;
using MyApp.Application.Models.Responses.Payments;
using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Services;

public interface IPaymentService
{
    Task<IBaseResponse<PaymentDto>> CreatePayment(PaymentCreateReq createReq, CancellationToken ctk = default);
    Task UpdatePayment(PaymentEditReq editReq, CancellationToken ctk = default);
    Task DeletePaymentWithId(Guid id, Guid customerId, CancellationToken ctk = default);
    Task<PaymentDto> GetPaymentDtoById(Guid id, Guid customerId, CustomerTypeEnum customerType,
        CancellationToken ctk = default);
    Task<MultiplePaymentRes> GetAllPaymentForUserId(Guid customerId, CancellationToken ctk = default);
}