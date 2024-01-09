namespace MyApp.Application.Interfaces.Services;

public interface IBillingFlagService
{
    Task AddBillingLineFlags(Guid billingId, Guid customerId, CancellationToken ctk = default);
    Task DeleteBillingLineFlags(Guid billingId, Guid customerId, CancellationToken ctk = default);
    Task AddBulkDiscountFlags(Guid billingId, Guid customerId, CancellationToken ctk = default);
    Task DeleteBulkDiscountFlags(Guid billingId, Guid customerId, CancellationToken ctk = default);
}