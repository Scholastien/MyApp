using MyApp.Application.Extensions;
using MyApp.Application.Models.Dtos.BillingLines;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Billings;

public class BillingDto : BaseDto<Billing>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
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
        CustomerType = entity.Customer.CustomerType;
        Lines = entity.BillingLines.Select(b => new BillingLineDto(b)).ToList();
        
        // Label display
        Name = Convert.ToBase64String(entity.Id.ToByteArray());
        
        // Discount display
        DiscountPercentage = entity.Discounts.Where(d => d.DiscountUnit == DiscountUnitEnum.Percentage).Select(d => d.Value).Sum();
        DiscountFlat = entity.Discounts.Where(d => d.DiscountUnit == DiscountUnitEnum.Flat).Select(d => d.Value).Sum();
        if (DiscountFlat != 0 && DiscountPercentage != 0) DiscountString = $"{DiscountFlat}$ + {DiscountPercentage}%";
        else if(DiscountFlat == 0) DiscountString = $"{DiscountPercentage}%";
        else if(DiscountPercentage == 0) DiscountString = $"{DiscountFlat}$";
        
        // Checkout display
        ItemsCount = entity.BillingLines.Select(b => b.Quantity).Sum();
        TotalGross = entity.BillingLines.Select(b => b.Quantity * b.Product.Price).Sum();
        TotalNet = TotalGross - DiscountPercentage / 100 * TotalGross - DiscountFlat;
    }

    public override void WriteTo(Billing entity)
    {
        base.WriteTo(entity);
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}