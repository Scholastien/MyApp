using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Requests.Billings;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.BillingLine;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class BillingLineController : BaseControllerApp
{
    private readonly IBillingLineService _billingLineService;
    private readonly IBillingService _billingService;
    private readonly IProductService _productService;

    public BillingLineController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<BillingLineController> logger,
        AppDbContext dbContext, IBillingLineService billingLineService, IBillingService billingService, IProductService productService) : base(userManager,
        signInManager, logger, dbContext)
    {
        _billingLineService = billingLineService;
        _billingService = billingService;
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(Guid id, Guid customerId)
    {
        var products = await _productService.GetAllProducts();

        if (products != null)
        {
            ViewBag.Products = new SelectList(
                products.Data.ToList(),
                "Id",
                "Name");
        }
        
        var billing = await _billingService.GetBillingDtoById(id, customerId);

        if (billing != null)
        {
            ViewBag.HasDiscount = billing.HasDiscount;
        }

        return View(new BillingEditReq(billing));
    }
    
    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpPost]
    public async Task<ActionResult> Add([FromForm] BillingEditReq req)
    {
        var res = await _billingLineService.CreateOrUpdateBillingLine(req);
        
        return RedirectToAction("Index", "BillingLine", new { id = res.Data.BillingId, customerId = res.Data.CustomerId });
    }

    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpGet]
    public async Task<ActionResult> Delete(Guid id)
    {
        var ids = await _billingLineService.DeleteBillingLine(id);
        
        return RedirectToAction("Index", "BillingLine", new { id = ids.BillingId, customerId = ids.BillingCustomerId });
    }
}