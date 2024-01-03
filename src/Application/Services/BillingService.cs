using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Billings;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Specifications.Customers;
using MultipleBillingsRes = MyApp.Application.Models.Requests.Billings.MultipleBillingsRes;

namespace MyApp.Application.Services;

public class BillingService : ServiceBase, IBillingService
{
    public BillingService(ILoggerService loggerService, IUnitOfWork unitOfWork) : base(unitOfWork,loggerService)
    {
    }

    public Task<IBaseResponse<BillingDto>> CreateBilling(MultipleBillingsRes createReq, CancellationToken ctk = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Models.Responses.Billings.MultipleBillingsRes> GetAllBillingsForCustomer(Guid customerId,
        CancellationToken ctk = default)
    {
        var companySpec = CustomerSpecifications<Customer>.IncludeBillingsForCustomerWithIdSpec(customerId);

        var customer = await UnitOfWork.Repository<Customer>().FirstOrDefaultAsync(companySpec, ctk);

        if (customer != null)
            return new Models.Responses.Billings.MultipleBillingsRes
            {
                Data = customer.Billings.Select(_ => new BillingDto(_)).ToList(),
                CustomerId = customerId
            };

        LoggerService.LogError($"Couldn't find customer with ID {customerId}");
        throw new NullReferenceException();
    }
}