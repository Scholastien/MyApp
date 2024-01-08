using MyApp.Domain.Entities.BillingsDiscounts;

namespace MyApp.Application.Models.Dtos.BillingsDiscounts;

public class BillingDiscountDto : BaseDto<BillingDiscount>
{
    public Guid DiscountId { get; set; }
    public Guid BillingId { get; set; }
    public Guid CustomerId { get; set; }
    public string Name { get; set; }

    public BillingDiscountDto()
    {
    }

    public BillingDiscountDto(BillingDiscount entity)
    {
        DiscountId = entity.DiscountId;
        BillingId = entity.BillingId;
        CustomerId = entity.BillingCustomerId;
    }


    public override void WriteTo(BillingDiscount entity)
    {
    }
}