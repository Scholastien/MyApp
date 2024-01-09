using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.PaymentsHistories;
using MyApp.Application.Models.Requests.PaymentsHistories;
using MyApp.Application.Models.Responses.PaymentsHistories;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.PaymentHistories;

namespace MyApp.Application.Services;

public class PaymentHistoryService : ServiceBase, IPaymentHistoryService
{
    private readonly IBillingFlagService _billingFlagService;

    public PaymentHistoryService(IUnitOfWork unitOfWork, ILoggerService loggerService,
        IBillingFlagService billingFlagService) : base(unitOfWork, loggerService)
    {
        _billingFlagService = billingFlagService;
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
            }, ctk);

            await UnitOfWork.SaveChangesAsync(ctk);
            LoggerService.LogInfo("New PaymentHistory created");

            return new PaymentHistoryRes { Data = new PaymentHistoryDto(payment) };
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

    public async Task DeletePaymentHistoryWithId(Guid id, Guid billingId, Guid paymentId,
        CancellationToken ctk = default)
    {
        try
        {
            var hist = await GetEntityByIdAsync<PaymentHistory>(new object[] { id, billingId, paymentId }, ctk);

            UnitOfWork.Repository<PaymentHistory>().Delete(hist);
            await UnitOfWork.SaveChangesAsync(ctk);
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
}