using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Payments;

namespace MyApp.Domain.Specifications.Payments;

public static class PaymentSpecifications
{
    public static BaseSpecification<Payment> GetPaymentById(Guid id)
    {
        return new BaseSpecification<Payment>(c => c.Id == id);
    }
    
    public static BaseSpecification<Payment> GetPaymentsForCustomer(Guid customerId)
    {
        return new BaseSpecification<Payment>(p => p.CustomerId == customerId);
    }
}