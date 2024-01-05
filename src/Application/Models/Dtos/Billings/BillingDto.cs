using MyApp.Application.Extensions;
using MyApp.Application.Models.Dtos.BillingLines;
using MyApp.Domain.Entities.Billings;
namespace MyApp.Application.Models.Dtos.Billings;

public class BillingDto : BaseDto<Billing>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public uint ItemsCount { get; set; }
    public float TotalGross { get; set; }
    public float DiscountPercentage { get; set; }
    public float DiscountFlat { get; set; }
    public float TotalNet { get; set; }
    public string DiscountString { get; set; }
    public List<BillingLineDto> Lines { get; set; }

    public BillingDto(){}
    
    public BillingDto(Billing entity) : base(entity)
    {
        Id = entity.Id;
        CustomerId = entity.CustomerId;
        Name = Convert.ToBase64String(entity.Id.ToByteArray());
        DiscountPercentage = 10;
        DiscountFlat = 20;
        DiscountString = $"{DiscountFlat}$ + {DiscountPercentage}%";
        Lines = entity.BillingLines.Select(b => new BillingLineDto(b)).ToList();
        ItemsCount = entity.BillingLines.Select(b => b.Quantity).Sum();
        TotalGross = entity.BillingLines.Select(b => b.Quantity * b.Product.Price).Sum();
        TotalNet = TotalGross - DiscountPercentage / 100 * TotalGross - DiscountFlat;
    }

    public override void WriteTo(Billing entity)
    {
        base.WriteTo(entity);
    }
}