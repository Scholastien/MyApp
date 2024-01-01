using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Specifications.Customers;

public static class CustomerSpecifications<T>
    where T : Customer
{
    public static BaseSpecification<T> GetCustomerById(Guid id)
    {
        return new BaseSpecification<T>(c => c.Id == id);
    }
    
    public static BaseSpecification<T> GetCustomerWithDetailsMatchingId(Guid id)
    {
        var spec = new BaseSpecification<T>(customer => customer.BillingDetails.Id == id || customer.ShippingDetails.Id == id);
        spec.AddInclude(c => c.BillingDetails);
        spec.AddInclude(c => c.ShippingDetails);
        return spec;
    }

    public static BaseSpecification<T> GetAllActiveCustomersSpec()
    {
        return new BaseSpecification<T>(c => c.StatusEnum == CustomerStatusEnum.Active && c.IsDeleted == false);
    }

    public static BaseSpecification<T> IncludeDetailsToCustomerWithId(Guid id)
    {
        var spec = new BaseSpecification<T>(c => c.Id == id);
        spec.AddInclude(c => c.BillingDetails);
        spec.AddInclude(c => c.ShippingDetails);
        return spec;
    }
}