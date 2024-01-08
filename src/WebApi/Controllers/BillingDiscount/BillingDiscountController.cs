using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Discounts;
using MyApp.Application.Models.Requests.BillingsDiscounts;
using MyApp.Application.Models.Responses.BillingsDiscounts;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.BillingDiscount;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class BillingDiscountController : BaseControllerApp
{
    private readonly IBillingsDiscountsService _billingsDiscountsService;
    private readonly IDiscountPolicyService _discountPolicyService;

    public BillingDiscountController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<BillingDiscountController> logger,
        AppDbContext dbContext, IBillingsDiscountsService billingsDiscountsService,
        IDiscountPolicyService discountPolicyService) : base(userManager, signInManager, logger, dbContext)
    {
        _billingsDiscountsService = billingsDiscountsService;
        _discountPolicyService = discountPolicyService;
    }

    [HttpGet]
    public async Task<ActionResult> Index(Guid billingId, Guid customerId, string? msg)
    {
        var availableDiscountsRes =
            await _discountPolicyService.GetAllAvailableBulkDiscountsLinkedToBilling(billingId, customerId);

        if (availableDiscountsRes != null)
        {
            var availableDiscounts = availableDiscountsRes.Data
                .OrderBy(d => d.DiscountUnit)
                .ThenBy(d => d.Name)
                .ToList();

            var hasDiscounts = availableDiscounts.Any();
            var placeholder = hasDiscounts
                ? "--Select Discount--" 
                : "--No Discount Available--";

            availableDiscounts.Insert(0, new DiscountDto
            {
                Id = Guid.Empty,
                Name = placeholder
            });

            ViewBag.HasAvailableDiscounts = hasDiscounts;
            ViewBag.AvailableDiscounts = new SelectList(
                availableDiscounts,
                "Id",
                "Name");
            
        }

        if (!string.IsNullOrEmpty(msg))
        {
            ViewBag.Message = msg;
        }

        var req = await _discountPolicyService.AttachDiscountToBilling(billingId, customerId);
        
        return View(req);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] BillingDiscountCreateReq req)
    {
        var res = await _billingsDiscountsService.CreateBillingDiscount(req);

        return RedirectToAction("Index", "BillingDiscount",
            new
            {
                billingId = req.BillingId,
                customerId = req.CustomerId,
                msg = res.Message,
            });
    }

    public async Task<IActionResult> Delete(Guid discountId, Guid billingId)
    {
        var res = await _billingsDiscountsService.DeleteProductWithId(discountId, billingId);

        return RedirectToAction("Index", "BillingDiscount", new { billingId = res.BillingId, customerId = res.BillingCustomerId, msg = "Billing Discount deleted" });
    }
}