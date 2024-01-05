using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.Dtos.BillingLines;
using MyApp.Application.Models.Dtos.Billings;
using MyApp.Domain.Entities.Billings;

namespace MyApp.Application.Models.Requests.Billings;

public class BillingEditReq : BaseEditRequest<BillingDto, Billing>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }

    [Range(1, int.MaxValue)] public uint NewLineQuantity { get; set; } = 1;
    public Guid NewLineProduct { get; set; }


    public IList<BillingLineDto> Lines { get; set; }

    public BillingEditReq()
    {
    }

    public BillingEditReq(BillingDto data)
    {
        Id = data.Id;
        CustomerId = data.CustomerId;
        Lines = data.Lines;
    }

    public override void WriteTo(Billing entity)
    {
    }
}