using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.DTOs.Payments;
using MyApp.Application.Models.Requests.Payment;
using MyApp.Application.Models.Responses.Payment;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications;

namespace MyApp.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerService _loggerService;

    public PaymentService(IUnitOfWork unitOfWork, ILoggerService loggerService)
    {
        _unitOfWork = unitOfWork;
        _loggerService = loggerService;
    }

    public async Task<IBaseResponse<PaymentDto>> CreatePayment(PaymentCreateReq createReq, CancellationToken ctk = default)
    {
        var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(createReq.CustomerId, ctk);
        
        var payment = await _unitOfWork.Repository<Payment>().AddAsync(new Payment
        {
            PaymentType = createReq.PaymentType,
            Customer = customer
        }, ctk);
        
        
        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo("New payment created");

        return new PaymentRes { Data = new PaymentDto(payment)
            {
                EntityController = null
            }
        };
    }

    public async Task UpdatePayment(PaymentEditReq editReq, CancellationToken ctk = default)
    {
        var payment = await _unitOfWork.Repository<Payment>().GetByIdAsync(editReq.Id, ctk);
        
        if (payment == null)
        {
            _loggerService.LogError($"Couldn't find Payment with ID {editReq.Id}");
            throw new NullReferenceException();
        }
        
        editReq.WriteTo(payment);
        _unitOfWork.Repository<Payment>().Update(payment);
        await _unitOfWork.SaveChangesAsync(ctk);

        _loggerService.LogInfo($"Payment {editReq.Id} updated");
    }

    public async Task DeletePaymentWithId(Guid id, CancellationToken ctk = default)
    {
        var payment = await _unitOfWork.Repository<Payment>().GetByIdAsync(id, ctk);

        if (payment == null)
        {
            _loggerService.LogError($"Couldn't find payment with ID {id}");
            throw new NullReferenceException();
        }

        _unitOfWork.Repository<Payment>().Delete(payment);
        await _unitOfWork.SaveChangesAsync(ctk);
    }

    public async Task<PaymentDto> GetPaymentDtoById(Guid id, CustomerTypeEnum customerType, CancellationToken ctk = default)
    {
        var individual = await _unitOfWork.Repository<Payment>().GetByIdAsync(id, ctk);

        // Return if not null
        if (individual != null) return new PaymentDto(individual)
        {
            EntityController = customerType.ToString()
        };
        
        // Log and throw
        _loggerService.LogError($"Couldn't find individual with ID {id}");
        throw new NullReferenceException();
    }
}