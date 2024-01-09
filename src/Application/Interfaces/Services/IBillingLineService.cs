using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.BillingLines;

namespace MyApp.Application.Interfaces.Services;

public interface IBillingLineService
{
    Task<BillingLineRes> CreateOrUpdateBillingLine(BillingEditReq req, CancellationToken ctk = default);
    Task<(Guid BillingId, Guid BillingCustomerId)> DeleteBillingLine(Guid id, CancellationToken ctk = default);
}