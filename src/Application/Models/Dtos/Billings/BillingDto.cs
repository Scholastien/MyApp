using MyApp.Domain.Entities.Billings;
namespace MyApp.Application.Models.Dtos.Billings;

public class BillingDto : BaseDto<Billing>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int ItemsCount { get; set; }
    
    public BillingDto(){}
    
    public BillingDto(Billing entity) : base(entity)
    {
        Id = entity.Id;
        CustomerId = entity.CustomerId;
        ItemsCount = entity.BillingLines.Select(b => b.Quantity).Sum();
    }

    public override void WriteTo(Billing entity)
    {
        base.WriteTo(entity);
    }
}