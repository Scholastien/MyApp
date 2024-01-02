using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.Payment;

public class PaymentCreateReq
{
    public Guid Id { get; set; }
    public required Guid CustomerId { get; set; }
    public PaymentTypeEnum PaymentType { get; set; }
    public required string EntityController { get; set; }
}