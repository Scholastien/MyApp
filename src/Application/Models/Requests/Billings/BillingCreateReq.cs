namespace MyApp.Application.Models.Requests.Billings;

public class BillingCreateReq
{
    public required Guid CustomerID { get; set; }
}