using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Billings;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Application.Models.Responses.Customers.Billings;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Specifications.Customers;

namespace MyApp.Application.Services;

public class BillingService : IBillingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public BillingService(ILoggerService loggerService, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _loggerService = loggerService;
    }

    public Task<IBaseResponse<BillingDto>> CreateBilling(BillingCreateReq createReq, CancellationToken ctk = default)
    {
        throw new NotImplementedException();
    }

    public async Task<MultipleBillingsRes> GetAllBillingsForCustomer(Guid customerId,
        CancellationToken ctk = default)
    {
        var companySpec = CustomerSpecifications<Customer>.IncludeBillingsForCustomerWithId(customerId);

        var customer = await _unitOfWork.Repository<Customer>().FirstOrDefaultAsync(companySpec, ctk);

        if (customer != null)
            return new MultipleBillingsRes
            {
                Data = customer.Billings.Select(_ => new BillingDto(_)).ToList(),
                CustomerId = customerId
            };

        _loggerService.LogError($"Couldn't find customer with ID {customerId}");
        throw new NullReferenceException();
    }
}