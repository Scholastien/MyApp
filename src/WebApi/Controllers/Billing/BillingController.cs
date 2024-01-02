using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.Billing;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class BillingController : BaseControllerApp
{
    private readonly IBillingService _billingService;

    public BillingController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
        ILogger<BillingController> logger, AppDbContext dbContext, IBillingService billingService)
        : base(userManager, signInManager, logger, dbContext)
    {
        _billingService = billingService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid customerId)
    {
        var customerBillings = await _billingService.GetAllBillingsForCustomer(customerId);

        return View(customerBillings);
    }

    [HttpGet]
    public IActionResult Add(Guid customerId)
    {
        var req = new BillingCreateReq
        {
            CustomerID = customerId
        };
        return View(req);
    }
}