using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.BillingsDiscounts;
using MyApp.Application.Models.Requests.BillingsDiscounts;
using MyApp.Application.Models.Responses.BillingsDiscounts;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Enums;

namespace MyApp.Application.Services;

public class BillingsDiscountsService : ServiceBase, IBillingsDiscountsService
{
    private readonly IBillingService _billingService;
    private readonly IDiscountService _discountService;

    public BillingsDiscountsService(IUnitOfWork unitOfWork, ILoggerService loggerService,
        IBillingService billingService, IDiscountService discountService) : base(unitOfWork,
        loggerService)
    {
        _billingService = billingService;
        _discountService = discountService;
    }

    private async Task<bool> NewDiscountExceedsTotal(BillingDiscountCreateReq req, CancellationToken ctk = default)
    {
        var billing = await _billingService.GetBillingDtoById(req.BillingId, req.CustomerId, ctk);

        if (billing == null)
        {
            throw new NullReferenceException("Couldn't find Billing");
        }

        var discount = await _discountService.GetDiscountDtoById(req.NewDiscount, ctk);

        if (discount == null)
        {
            throw new NullReferenceException("Couldn't find Discount");
        }

        return discount.DiscountUnit switch
        {
            DiscountUnitEnum.Flat => billing.TotalNet - discount.Value <= 0,
            DiscountUnitEnum.Percentage => billing.TotalNet - (float)discount.Value / 100 * billing.TotalNet <= 0,
            _ => throw new ArgumentOutOfRangeException(nameof(discount.DiscountUnit),
                $"Expected a DiscountUnit in range, got '{discount.DiscountUnit.ToString()}' instead")
        };
    }

    public async Task<BillingDiscountRes> CreateBillingDiscount(BillingDiscountCreateReq req,
        CancellationToken ctk = default)
    {
        try
        {
            if (await NewDiscountExceedsTotal(req, ctk))
            {
                return new BillingDiscountRes
                {
                    Data = new BillingDiscountDto
                    {
                        BillingId = req.BillingId,
                        CustomerId = req.CustomerId
                    },
                    Message = $"Can't add discount if Discount exceeds total net"
                };
            }

            var billingDiscount = await UnitOfWork.Repository<BillingDiscount>().AddAsync(new BillingDiscount
            {
                DiscountId = req.NewDiscount,
                BillingId = req.BillingId,
                BillingCustomerId = req.CustomerId,
                CreatedBy = Guid.NewGuid(),
                CreatedOn = DateTimeOffset.Now,
            }, ctk);

            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo("New BillingDiscount created");
            
            // Remove authorization BulkDiscountAfter Line addition
            await _billingService.RemoveStateFlagAsync(req.BillingId, req.CustomerId,
                BillingStateFlag.CanAddBillingLines, ctk);
            await _billingService.RemoveStateFlagAsync(req.BillingId, req.CustomerId,
                BillingStateFlag.CanModifyBillingLines, ctk);

            return new BillingDiscountRes
            {
                Data = new BillingDiscountDto(billingDiscount),
                Message = $"Discount added to Billing {req.BillingId}"
            };
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingDiscount creation occured", e);
            throw;
        }
    }

    public async Task<(Guid BillingId, Guid BillingCustomerId)> DeleteBillingDiscountWithIds(Guid discountId, Guid billingId,
        CancellationToken ctk = default)
    {
        try
        {
            var billingDiscount = await GetEntityByIdAsync<BillingDiscount>(new object[] { discountId, billingId}, ctk);
            
            UnitOfWork.Repository<BillingDiscount>().Delete(billingDiscount);
            await UnitOfWork.SaveChangesAsync(ctk);

            return (billingDiscount.BillingId, billingDiscount.BillingCustomerId);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during BillingDiscount deletion occured", e);
            throw;
        }
    }
}