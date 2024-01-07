using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Services;

public interface IBillingService
{
    Task<BillingRes> CreateBilling(BillingCreateReq req, CancellationToken ctk = default);
    Task<MultipleBillingsRes> GetAllBillingsForCustomer(Guid customerId, CancellationToken ctk = default);
    Task<BillingDto> GetBillingDtoById(Guid id, Guid customerId, CancellationToken ctk = default);
    Task<BillingRes> CreateOrUpdateBillingLine(BillingEditReq req, CancellationToken ctk = default);
    Task<BillingRes> CreateBillingLine(BillingEditReq req, CancellationToken ctk = default);
    Task<BillingRes> UpdateBillingLine(BillingEditReq req, BillingLine line, CancellationToken ctk = default);
    Task<(Guid BillingId, Guid BillingCustomerId)> DeleteBillingLine(Guid id, CancellationToken ctk = default);
    Task DeleteBillingWithId(Guid id, Guid customerId, CancellationToken ctk = default);
    BillingStateEnum GetBillingState(Guid id, Guid customerId, CancellationToken ctk = default);
}