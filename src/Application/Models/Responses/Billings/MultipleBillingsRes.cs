using MyApp.Application.Models.Dtos.Billings;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Responses.Billings;

public class MultipleBillingsRes : MultipleBaseResponse<BillingDto, Billing>
{
    public required Guid CustomerId { get; set; }
    public required CustomerTypeEnum CustomerType { get; set; }
}