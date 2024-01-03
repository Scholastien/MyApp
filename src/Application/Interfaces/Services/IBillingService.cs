using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;
using MultipleBillingsRes = MyApp.Application.Models.Requests.Billings.MultipleBillingsRes;

namespace MyApp.Application.Interfaces.Services;

public interface IBillingService
{
    Task<IBaseResponse<BillingDto>> CreateBilling(MultipleBillingsRes createReq, CancellationToken ctk = default);
    Task<Application.Models.Responses.Billings.MultipleBillingsRes> GetAllBillingsForCustomer(Guid customerId, CancellationToken ctk = default);

}