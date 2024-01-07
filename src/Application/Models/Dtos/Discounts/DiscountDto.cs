using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.Discounts;

public class DiscountDto : BaseDto<Discount>
{
    public Guid Id { get; set; }
    public DiscountUnitEnum DiscountUnit { get; set; }
    public uint Value { get; set; }
    public string Name { get; set; }
    public int NumberUsed { get; set; }
    public DiscountDto()
    {
    }

    public DiscountDto(Discount entity) : base(entity)
    {
        Id = entity.Id;
        DiscountUnit = entity.DiscountPolicy.DiscountUnit;
        Value = entity.Value;
        Name = entity.Value + entity.DiscountPolicy.DiscountUnit switch
        {
            DiscountUnitEnum.Flat => "$",
            DiscountUnitEnum.Percentage => "%",
            _ => throw new ArgumentOutOfRangeException(nameof(entity),
                $"DiscountUnit not defined on DiscountPolicyBase entity with id {entity.DiscountPolicy.Id}")
        };
        NumberUsed = entity.Billings.Count;
    }

    public override void WriteTo(Discount entity)
    {
        base.WriteTo(entity);
        
        entity.Value = Value;
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}