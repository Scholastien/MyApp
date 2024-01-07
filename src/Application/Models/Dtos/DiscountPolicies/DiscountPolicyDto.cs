using MyApp.Application.Interfaces.Models.Dtos;
using MyApp.Application.Models.Dtos.Discounts;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Dtos.DiscountPolicies;

public class DiscountPolicyDto<T> : BaseDto<T>, IDiscountPolicyDto
    where T : DiscountPolicyBase
{
    public Guid Id { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
    public DiscountTypeEnum DiscountType { get; set; }
    public DiscountUnitEnum DiscountUnit { get; set; }
    public int MaxValue { get; set; }
    public string Name { get; set; }
    public IList<DiscountDto> Discounts { get; set; }
    public string Preview { get; set; }
    public string UnitString { get; set; }

    public DiscountPolicyDto()
    {
    }

    public DiscountPolicyDto(T entity) : base(entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        CustomerType = entity.CustomerType;
        DiscountType = entity.DiscountType;
        DiscountUnit = entity.DiscountUnit;
        MaxValue = entity.MaxValue;
        Discounts = entity.Discounts.Select(d => new DiscountDto(d)).ToList();
        UnitString = entity.DiscountUnit switch
        {
            DiscountUnitEnum.Flat => "$",
            DiscountUnitEnum.Percentage => "%",
            _ => throw new ArgumentOutOfRangeException(nameof(entity),
                $"DiscountUnit not defined on DiscountPolicyBase entity with id {entity.Id}")
        };
        Preview = string.Concat(
            entity.Discounts.OrderBy(d => d.Value)
                .Select(d => d.Value + UnitString + ", "))
            .TrimEnd(',', ' ');
    }

    public override void WriteTo(T entity)
    {
        base.WriteTo(entity);
        
        entity.MaxValue = MaxValue;
        entity.LastModifiedOn = DateTimeOffset.Now;
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}