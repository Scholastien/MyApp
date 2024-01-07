using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Application.Models.Dtos.Discounts;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Enums;

namespace MyApp.Application.Models.Requests.DiscountPolicies;

public class DiscountPolicyEditReq<TDto, TEntity> : BaseEditRequest<TDto, TEntity>
    where TDto : DiscountPolicyDto<TEntity>
    where TEntity : DiscountPolicyBase
{
    [Required] public Guid Id { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
    public DiscountUnitEnum DiscountUnit { get; set; }
    public string DiscountUnitString { get; set; }
    public int MaxValue { get; set; }
    [Range(1, int.MaxValue)] public uint NewDiscountValue { get; set; } = 1;
    public string Name { get; set; }
    public IList<DiscountDto> Discounts { get; set; }

    public DiscountPolicyEditReq()
    {
    }

    public DiscountPolicyEditReq(TDto data)
    {
        Id = data.Id;
        Name = data.Name;
        CustomerType = data.CustomerType;
        MaxValue = data.MaxValue;
        DiscountUnit = data.DiscountUnit;
        DiscountUnitString = data.DiscountUnit switch
        {
            DiscountUnitEnum.Flat => "$",
            DiscountUnitEnum.Percentage => "%",
            _ => throw new ArgumentOutOfRangeException(nameof(data),
                $"DiscountUnit not defined on DiscountPolicyBase entity with id {data.Id}")
        };
        Discounts = data.Discounts.OrderBy(d => d.Value).ToList();
    }

    public override void WriteTo(TEntity entity)
    {
        base.WriteTo(entity);
        entity.MaxValue = MaxValue;
    }
}