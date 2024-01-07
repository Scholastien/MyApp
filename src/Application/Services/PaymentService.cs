using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Payments;
using MyApp.Application.Models.Requests.Payments;
using MyApp.Application.Models.Responses.Payments;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.Payments;
using MyApp.Domain.Enums;

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
        var customer = await UnitOfWork.Repository<Customer>().GetByIdAsync(createReq.CustomerId, ctk);

        var payment = await UnitOfWork.Repository<Payment>().AddAsync(new Payment
        {
            CustomerId = createReq.CustomerId,
            PaymentType = createReq.PaymentType
        }, ctk);


        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo("New payment created");

        return new PaymentRes
        {
            Data = new PaymentDto(payment)
            {
                EntityController = null
            }
        };
    }

    public async Task UpdatePayment(PaymentEditReq editReq, CancellationToken ctk = default)
    {
        var payment = await UnitOfWork.Repository<Payment>().GetByIdAsync(new object[]{editReq.Id, editReq.CustomerId}, ctk);

        if (payment == null)
        {
            LoggerService.LogError($"Couldn't find Payment with ID {editReq.Id}");
            throw new NullReferenceException();
        }

        editReq.WriteTo(payment);
        UnitOfWork.Repository<Payment>().Update(payment);
        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo($"Payment {editReq.Id} updated");
    }

    public async Task DeletePaymentWithId(Guid id, Guid customerId, CancellationToken ctk = default)
    {
        var payment = await UnitOfWork.Repository<Payment>().GetByIdAsync(new object[] { id, customerId }, ctk);

        if (payment == null)
        {
            LoggerService.LogError($"Couldn't find payment with ID {id}");
            throw new NullReferenceException();
        }

        UnitOfWork.Repository<Payment>().Delete(payment);
        await UnitOfWork.SaveChangesAsync(ctk);
    }

    public async Task<PaymentDto> GetPaymentDtoById(Guid id, Guid customerId, CustomerTypeEnum customerType,
        CancellationToken ctk = default)
    {
        var individual = await UnitOfWork.Repository<Payment>().GetByIdAsync(new object[] { id, customerId }, ctk);

        // Return if not null
        if (individual != null)
            return new PaymentDto(individual)
            {
                EntityController = customerType.ToString()
            };

        // Log and throw
        LoggerService.LogError($"Couldn't find individual with ID {id}");
        throw new NullReferenceException();
    }
}