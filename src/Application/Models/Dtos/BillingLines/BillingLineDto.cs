using MyApp.Domain.Entities.Billings;

namespace MyApp.Application.Models.Dtos.BillingLines;

public class BillingLineDto : BaseDto<BillingLine>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public uint Quantity { get; set; }
    public float Total { get; set; }
    
    public BillingLineDto(BillingLine entity) : base(entity)
    {
        Id = entity.Id;
        Name = entity.Product.Name;
        Price = entity.Product.Price;
        Quantity = entity.Quantity;
        Total = Quantity * Price;
    }

    public override void WriteTo(BillingLine entity)
    {
        base.WriteTo(entity);
        entity.Quantity = Quantity;
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}