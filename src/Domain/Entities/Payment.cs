using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities;

public class Payment
{
    public PaymentTypeEnum PaymentType { get; set; }
    public Customer Customer { get; set; }
}