using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Billings;
namespace MyApp.Domain.Specifications.Billings;

public static class BillingSpecifications
{
    public static BaseSpecification<Billing> IncludeBillingsForCustomerIdSpec(Guid customerId)
    {
        var spec = new BaseSpecification<Billing>(c => c.CustomerId == customerId);
        spec.AddInclude(c => c.BillingLines);
        spec.AddInclude("BillingLines.Product");
        spec.AddInclude(c => c.Discounts);
        return spec;
    }

    public static BaseSpecification<Billing> IncludeBillingLinesWithIdSpec(Guid id)
    {
        var spec = new BaseSpecification<Billing>(c => c.Id == id);
        spec.AddInclude(c => c.BillingLines);
        spec.AddInclude("BillingLines.Product");
        spec.AddInclude(c => c.Discounts);
        return spec;
    }
}