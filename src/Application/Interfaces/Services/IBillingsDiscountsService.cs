using MyApp.Application.Models.Requests.BillingsDiscounts;
using MyApp.Application.Models.Responses.BillingsDiscounts;

namespace MyApp.Application.Interfaces.Services;

public interface IBillingsDiscountsService
{
    Task<BillingDiscountRes> CreateBillingDiscount(BillingDiscountCreateReq req, CancellationToken ctk = default);
    Task<(Guid BillingId, Guid BillingCustomerId)> DeleteProductWithId(Guid discountId, Guid billingId, CancellationToken ctk = default);
}