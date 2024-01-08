using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Specifications.DiscountPolicies;

public static class DiscountPolicySpecifications
{
    public static ISpecification<DiscountPolicyBase> GetAllAvailableDiscountPoliciesSpec()
    {
        return new BaseSpecification<DiscountPolicyBase>(c
                => c.IsDeleted == false)
            .IncludeDiscounts();
    }

    public static ISpecification<DiscountPolicyBase> GetDiscountPolicyByIdSpec(Guid id)
    {
        return new BaseSpecification<DiscountPolicyBase>(c
                => c.Id == id)
            .IncludeDiscounts();
    }

    public static ISpecification<DiscountPolicyBase> GetAllAvailableDiscountPoliciesByCustomerTypeAndDiscountTypeSpec(
        CustomerTypeEnum customerType, DiscountTypeEnum discountType, ICollection<Discount> billingDiscounts)
    {
        return new BaseSpecification<DiscountPolicyBase>(c
                => c.CustomerType == customerType && c.DiscountType == discountType && c.IsDeleted == false)
            .IncludeDiscounts();
    }

    public static BaseSpecification<DiscountPolicyBase> IncludeDiscounts(
        this BaseSpecification<DiscountPolicyBase> spec)
    {
        spec.AddInclude(c => c.Discounts);
        return spec;
    }
}