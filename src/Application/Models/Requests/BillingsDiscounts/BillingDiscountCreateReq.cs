using MyApp.Application.Models.Dtos.BillingsDiscounts;

namespace MyApp.Application.Models.Requests.BillingsDiscounts;

public class BillingDiscountCreateReq
{
    public required string CustomerType { get; set; }
    public Guid BillingId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid NewDiscount { get; set; }
    public List<BillingDiscountDto> Discounts { get; set; } =
        new List<BillingDiscountDto>();
}