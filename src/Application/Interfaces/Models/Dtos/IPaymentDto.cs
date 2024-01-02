using MyApp.Domain.Enums;

namespace MyApp.Application.Interfaces.Models.Dtos;

public interface IPaymentDto
{
    Guid Id { get; set; }
    Guid CustomerId { get; set; }
    PaymentTypeEnum PaymentType { get; set; }
    string EntityController { get; set; }
}