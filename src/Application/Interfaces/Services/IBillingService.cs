using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;
using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Services;

public interface IBillingService
{
    Task<BillingRes> CreateBilling(BillingCreateReq req, CancellationToken ctk = default);
    Task<MultipleBillingsRes> GetAllBillingsForCustomer(Guid customerId, CancellationToken ctk = default);
    Task<BillingDto> GetBillingDtoById(Guid id, Guid customerId, CancellationToken ctk = default);
    Task DeleteBillingWithId(Guid id, Guid customerId, CancellationToken ctk = default);
    Task<BillingStateFlag> GetBillingState(Guid billingId, CancellationToken ctk = default);
    Task<Guid> GetCustomerId(Guid billingId, CancellationToken ctk = default);
}