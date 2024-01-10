using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.PaymentsHistories;
using MyApp.Application.Models.Requests.PaymentsHistories;
using MyApp.Application.Models.Responses.PaymentsHistories;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.PaymentHistories;
using MyApp.Domain.Specifications.PaymentsHistories;

namespace MyApp.Application.Services;

public class PaymentHistoryService : ServiceBase, IPaymentHistoryService
{
    private readonly IBillingService _billingService;

    public PaymentHistoryService(IUnitOfWork unitOfWork, ILoggerService loggerService, IBillingService billingService) : base(unitOfWork, loggerService)
    {
        _billingService = billingService;
    }

    public async Task<PaymentHistoryRes> CreatePaymentHistory(PaymentHistoryCreateReq createReq,
        CancellationToken ctk = default)
    {
        try
        {
            var payment = await UnitOfWork.Repository<PaymentHistory>().AddAsync(new PaymentHistory
            {
                BillingId = createReq.BillingId,
                PaymentId = createReq.PaymentId,
                CreatedOn = DateTimeOffset.Now,
            }, ctk);

            await UnitOfWork.SaveChangesAsync(ctk);
            LoggerService.LogInfo("New PaymentHistory created");

            var customerId = await _billingService.GetCustomerId(createReq.BillingId, ctk);

            return new PaymentHistoryRes
            {
                Data = new PaymentHistoryDto(payment)
                {
                    CustomerId = customerId
                }
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during PaymentHistory creation occured", e);
            throw;
        }
    }

    public async Task UpdatePaymentHistory(PaymentHistoryEditReq editReq, CancellationToken ctk = default)
    {
        try
        {
            var payment =
                await GetEntityByIdAsync<PaymentHistory>(
                    new object[] { editReq.Id, editReq.BillingId, editReq.PaymentId }, ctk);

            editReq.WriteTo(payment);
            UnitOfWork.Repository<PaymentHistory>().Update(payment);
            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo($"Payment {editReq.Id} updated");
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during PaymentHistory update occured", e);
            throw;
        }
    }

    public async Task<Guid> DeletePaymentHistoryWithId(Guid id, CancellationToken ctk = default)
    {
        try
        {
            var spec = PaymentHistorySpecifications.SinglePaymentHistorySpec(id);
            var hist = await UnitOfWork.Repository<PaymentHistory>().FirstOrDefaultAsync(spec, ctk);

            if (hist != null)
            {
                UnitOfWork.Repository<PaymentHistory>().Delete(hist);
                await UnitOfWork.SaveChangesAsync(ctk);
                return hist.BillingId;
            }

            // Log and throw
            LoggerService.LogError($"Couldn't find PaymentHistory with ID {id}");
            throw new NullReferenceException();
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during PaymentHistory deletion occured", e);
            throw;
        }
    }

    public async Task<PaymentHistoryDto> GetPaymentHistoryDtoById(Guid id, Guid billingId, Guid paymentId,
        CancellationToken ctk = default)
    {
        try
        {
            var payment = await GetEntityByIdAsync<PaymentHistory>(new object[] { id, billingId, paymentId }, ctk);

            return new PaymentHistoryDto(payment);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during PaymentHistory fetching as Dto occured", e);
            throw;
        }
    }

    public async Task<MultiplePaymentHistoriesRes> GetAllPaymentHistoriesForBillingId(Guid billingId,
        CancellationToken ctk = default)
    {
        var spec = PaymentHistorySpecifications.MultiplePaymentsHistoriesForBillingIdSpec(billingId);
        var paymentHistories = await UnitOfWork.Repository<PaymentHistory>().ListAsync(spec, ctk);

        var customerId = await _billingService.GetCustomerId(billingId, ctk);
        var state = await _billingService.GetBillingState(billingId, ctk);

        return new MultiplePaymentHistoriesRes
        {
            Data = paymentHistories.Select(b => new PaymentHistoryDto(b))
                .ToList(),
            CustomerId = customerId,
            CreateReq = new PaymentHistoryCreateReq
            {
                StateFlag = state
            }
        };
    }
}