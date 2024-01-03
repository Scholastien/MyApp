using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.Requests.BillingLines;

namespace MyApp.Application.Models.Requests.Billings;

public class MultipleBillingsRes
{
    public required Guid CustomerId { get; set; }
    public string Name { get; set; }

    public virtual List<BillingLineCreateReq> BillingLines { get; set; } =
        new List<BillingLineCreateReq>();
}