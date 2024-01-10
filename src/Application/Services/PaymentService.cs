using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Payments;
using MyApp.Application.Models.Requests.Payments;
using MyApp.Application.Models.Responses.Payments;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Payments;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Payments;

namespace MyApp.Application.Services;

public class PaymentService : ServiceBase, IPaymentService
{
    public PaymentService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        : base(unitOfWork, loggerService)
    {
    }

    public async Task<IBaseResponse<PaymentDto>> CreatePayment(PaymentCreateReq createReq,
        CancellationToken ctk = default)
    {
        try
        {
            var payment = await UnitOfWork.Repository<Payment>().AddAsync(new Payment
            {
                CustomerId = createReq.CustomerId,
                PaymentType = createReq.PaymentType
            }, ctk);

            await UnitOfWork.SaveChangesAsync(ctk);
            LoggerService.LogInfo("New payment created");

            return new PaymentRes { Data = new PaymentDto(payment) { EntityController = null } };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Payment creation occured", e);
            throw;
        }
    }

    public async Task UpdatePayment(PaymentEditReq editReq, CancellationToken ctk = default)
    {
        try
        {
            var payment = await GetEntityByIdAsync<Payment>(new object[] { editReq.Id, editReq.CustomerId }, ctk);

            editReq.WriteTo(payment);
            UnitOfWork.Repository<Payment>().Update(payment);
            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo($"Payment {editReq.Id} updated");
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Payment update occured", e);
            throw;
        }
    }

    public async Task DeletePaymentWithId(Guid id, Guid customerId, CancellationToken ctk = default)
    {
        try
        {
            var payment = await GetEntityByIdAsync<Payment>(new object[] { id, customerId }, ctk);

            UnitOfWork.Repository<Payment>().Delete(payment);
            await UnitOfWork.SaveChangesAsync(ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Payment deletion occured", e);
            throw;
        }
    }

    public async Task<PaymentDto> GetPaymentDtoById(Guid id, Guid customerId, CustomerTypeEnum customerType,
        CancellationToken ctk = default)
    {
        try
        {
            var payment = await GetEntityByIdAsync<Payment>(new object[] { id, customerId }, ctk);

            return new PaymentDto(payment)
            {
                EntityController = customerType.ToString()
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Payment fetching as Dto occured", e);
            throw;
        }
    }

    public async Task<MultiplePaymentRes> GetAllPaymentForUserId(Guid customerId, CancellationToken ctk = default)
    {
        var spec = PaymentSpecifications.GetPaymentsForCustomer(customerId);
        var paymentHistories = await UnitOfWork.Repository<Payment>().ListAsync(spec, ctk);

        return new MultiplePaymentRes
        {
            Data = paymentHistories.Select(b => new PaymentDto(b) { EntityController = null }).ToList(),
        };
    }
}