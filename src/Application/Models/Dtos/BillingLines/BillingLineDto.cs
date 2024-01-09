using MyApp.Domain.Entities.Billings;

namespace MyApp.Application.Models.Dtos.BillingLines;

public class BillingLineDto : BaseDto<BillingLine>
{
    public Guid Id { get; set; }
    public Guid BillingId { get; set; }
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
    public required string Name { get; set; }
    public required float Price { get; set; }
    public uint Quantity { get; set; }
    public float Total { get; set; }
    
    public BillingLineDto(BillingLine entity) : base(entity)
    {
        Id = entity.Id;
        BillingId = entity.BillingId;
        ProductId = entity.ProductId;
        CustomerId = entity.BillingCustomerId;
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