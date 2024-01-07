using MyApp.Application.Models.Requests.BillingLines;

namespace MyApp.Application.Models.Requests.Billings;

public class BillingCreateReq
{
    public required Guid CustomerId { get; set; }
    public string Name { get; set; }

    public List<BillingLineCreateReq> BillingLines { get; set; } =
        new List<BillingLineCreateReq>();
}