using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Requests.PaymentsHistories;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.PaymentHistory;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class PaymentHistoryController : BaseControllerApp
{
    private readonly IPaymentHistoryService _paymentHistoryService;
    private readonly IPaymentService _paymentService;
    private readonly IBillingService _billingService;

    public PaymentHistoryController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<PaymentHistoryController> logger,
        AppDbContext dbContext, IPaymentHistoryService paymentHistoryService, IPaymentService paymentService, IBillingService billingService) : base(
        userManager, signInManager, logger, dbContext)
    {
        _paymentHistoryService = paymentHistoryService;
        _paymentService = paymentService;
        _billingService = billingService;
    }

    [HttpGet]
    public async Task<ActionResult> Index(Guid billingId, Guid customerId)
    {
        var payments = await _paymentService.GetAllPaymentForUserId(customerId);

        if (payments != null)
        {
            ViewBag.Payments = new SelectList(
                payments.Data.ToList(),
                "Id",
                "Name");
        }

        var res = await _paymentHistoryService.GetAllPaymentHistoriesForBillingId(billingId);

        return View(res);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] PaymentHistoryCreateReq req)
    {
        var res = await _paymentHistoryService.CreatePaymentHistory(req);

        return RedirectToAction("Index", "PaymentHistory",
            new { billingId = res.Data.BillingId, customerId = res.Data.CustomerId });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var billingId = await _paymentHistoryService.DeletePaymentHistoryWithId(id);

        var customerId = await _billingService.GetCustomerId(billingId);
        
        return RedirectToAction("Index", "PaymentHistory",
            new { billingId, customerId });
    }
}