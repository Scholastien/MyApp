using MyApp.Application.Models.Dtos.Billings;
using MyApp.Domain.Entities.Billings;

namespace MyApp.Application.Models.Responses.Billings;

public class MultipleBillingsRes : MultipleBaseResponse<BillingDto, Billing>
{
    public required Guid CustomerId { get; set; }
}