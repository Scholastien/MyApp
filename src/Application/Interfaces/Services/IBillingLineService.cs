using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;
using MyApp.Domain.Entities.Billings;

namespace MyApp.Application.Interfaces.Services;

public interface IBillingLineService
{
    Task<BillingRes> CreateOrUpdateBillingLine(BillingEditReq req, CancellationToken ctk = default);
    Task<BillingRes> CreateBillingLine(BillingEditReq req, CancellationToken ctk = default);
    Task<BillingRes> UpdateBillingLine(BillingEditReq req, BillingLine line, CancellationToken ctk = default);
    Task<(Guid BillingId, Guid BillingCustomerId)> DeleteBillingLine(Guid id, CancellationToken ctk = default);
}