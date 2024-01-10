using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.PaymentHistories;

namespace MyApp.Domain.Specifications.PaymentsHistories;

public class PaymentHistorySpecifications
{
    public static BaseSpecification<PaymentHistory> MultiplePaymentsHistoriesForBillingIdSpec(Guid billingId)
    {
        var spec = new BaseSpecification<PaymentHistory>(c => c.BillingId == billingId);
        spec.AddInclude(p => p.Billing);
        spec.AddInclude(p => p.Payment);
        return spec;
    }

    public static BaseSpecification<PaymentHistory> SinglePaymentHistorySpec(Guid id)
    {
        return new BaseSpecification<PaymentHistory>(c => c.Id == id);
    }
}