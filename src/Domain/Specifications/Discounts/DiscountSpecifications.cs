using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Discounts;

namespace MyApp.Domain.Specifications.Discounts;

public static class DiscountSpecifications
{
    public static BaseSpecification<Discount> WithExistingValueForDiscountPolicyIdSpec(Guid discountPolicyId,
        uint reqNewDiscountValue)
    {
        return new BaseSpecification<Discount>(d
                => d.DiscountPolicyId == discountPolicyId
                   && d.Value == reqNewDiscountValue
                   && d.IsDeleted != false)
            .IncludeDiscountPolicy();
    }

    public static BaseSpecification<Discount> IncludeDiscountPolicy(this BaseSpecification<Discount> spec)
    {
        spec.AddInclude(c => c.DiscountPolicy);
        return spec;
    }

    public static BaseSpecification<Discount> GetDiscountWithIdSpec(Guid id)
    {
        return new BaseSpecification<Discount>(d => d.Id == id)
            .IncludeDiscountPolicy();
    }
}