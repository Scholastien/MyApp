using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.Payments;

namespace MyApp.Domain.Specifications;

public static class PaymentSpecification
{
    public static BaseSpecification<Payment> GetPaymentsForCustomer(Guid customerId)
    {
        return new BaseSpecification<Payment>(p => p.CustomerId == customerId);
    }
}