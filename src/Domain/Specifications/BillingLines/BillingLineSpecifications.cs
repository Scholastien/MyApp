using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Billings;

namespace MyApp.Domain.Specifications.BillingLines;

public static class BillingLineSpecifications
{
    public static BaseSpecification<BillingLine> WithBillingIdAndProductIdSpec(Guid billingId, Guid productId)
    {
        var spec = new BaseSpecification<BillingLine>(c => c.BillingId == billingId && c.ProductId == productId);
        spec.AddInclude(c => c.Product);
        return spec;
    }
}