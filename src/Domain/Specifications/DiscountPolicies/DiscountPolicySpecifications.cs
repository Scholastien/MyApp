using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.DiscountPolicy;

namespace MyApp.Domain.Specifications.DiscountPolicies;

public static class DiscountPolicySpecifications
{
    public static ISpecification<DiscountPolicyBase> GetAllAvailableDiscountPoliciesSpec()
    {
        return new BaseSpecification<DiscountPolicyBase>(c 
                => c.IsDeleted == false)
            .IncludeDiscounts();
    }
    
    public static ISpecification<DiscountPolicyBase> GetDiscountPolicyDtoByIdSpec(Guid id)
    {
        return new BaseSpecification<DiscountPolicyBase>(c 
            => c.Id == id)
            .IncludeDiscounts();
    }
    
    public static BaseSpecification<DiscountPolicyBase> IncludeDiscounts(this BaseSpecification<DiscountPolicyBase> spec)
    {
        spec.AddInclude(c => c.Discounts);
        return spec;
    }
}