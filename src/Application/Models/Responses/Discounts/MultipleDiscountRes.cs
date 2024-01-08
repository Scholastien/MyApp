using MyApp.Application.Models.Dtos.Discounts;
using MyApp.Domain.Entities.Discounts;

namespace MyApp.Application.Models.Responses.Discounts;

public class MultipleDiscountRes : MultipleBaseResponse<DiscountDto, Discount>
{
    public required Guid CustomerId { get; set; }
    public required Guid BillingId { get; set; }
}