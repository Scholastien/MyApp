using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Billings;

namespace MyApp.Domain.Specifications.Billings;

public static class BillingSpecifications
{
    public static BaseSpecification<Billing> MultipleBillingsForCustomerIdSpec(Guid customerId)
    {
        var spec = new BaseSpecification<Billing>(c 
            => c.CustomerId == customerId
            && c.IsDeleted == false);
        return spec.IncludeEntitiesForListing();
    }

    public static BaseSpecification<Billing> SingleBillingWithAllIncludesSpec(Guid id, Guid customerId)
    {
        var spec = new BaseSpecification<Billing>(c => c.Id == id && c.CustomerId == customerId);
        return spec.IncludeAllLinkedEntities();
    }
    
    public static BaseSpecification<Billing> IncludeEntitiesForListing(this BaseSpecification<Billing> spec)
    {
        return spec.IncludeBillingLines()
            .IncludeDiscounts()
            .IncludeBillingHistory();
    }
    
    public static BaseSpecification<Billing> IncludeAllLinkedEntities(this BaseSpecification<Billing> spec)
    {
        return spec.IncludeBillingLines()
            .IncludeCustomer()
            .IncludeDiscounts()
            .IncludeBillingHistory();
    }

    public static BaseSpecification<Billing> IncludeBillingLines(this BaseSpecification<Billing> spec)
    {
        spec.AddInclude(c => c.BillingLines);
        spec.AddInclude("BillingLines.Product");
        return spec;
    }
    
    public static BaseSpecification<Billing> IncludeDiscounts(this BaseSpecification<Billing> spec)
    {
        spec.AddInclude(c => c.BillingsDiscounts);
        spec.AddInclude(c => c.Discounts);
        spec.AddInclude("Discounts.DiscountPolicy");
        return spec;
    }
    
    public static BaseSpecification<Billing> IncludeBillingHistory(this BaseSpecification<Billing> spec)
    {
        spec.AddInclude(c => c.PaymentHistories);
        return spec;
    }
    
    public static BaseSpecification<Billing> IncludeCustomer(this BaseSpecification<Billing> spec)
    {
        spec.AddInclude(c => c.Customer);
        return spec;
    }
}