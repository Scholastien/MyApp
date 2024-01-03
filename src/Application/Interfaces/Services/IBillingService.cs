using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;

namespace MyApp.Application.Interfaces.Services;

public interface IBillingService
{
    Task<IBaseResponse<BillingDto>> CreateBilling(BillingCreateReq createReq, CancellationToken ctk = default);
    Task<MultipleBillingsRes> GetAllBillingsForCustomer(Guid customerId, CancellationToken ctk = default);

}