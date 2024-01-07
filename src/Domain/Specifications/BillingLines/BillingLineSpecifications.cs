using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Billings;

namespace MyApp.Domain.Specifications.BillingLines;

public static class BillingLineSpecifications
{
    public static BaseSpecification<BillingLine> WithBillingIdAndProductIdSpec(
        (Guid BillingId, Guid BillingCustomerId) billingIds, Guid productId)
    {
        var spec = new BaseSpecification<BillingLine>(c
            => c.BillingId == billingIds.BillingId
               && c.BillingCustomerId == billingIds.BillingCustomerId
               && c.ProductId == productId);
        return spec.IncludeProducts();
    }

    public static BaseSpecification<BillingLine> IncludeProducts(this BaseSpecification<BillingLine> spec)
    {
        spec.AddInclude(c => c.Product);
        return spec;
    }
}