using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Products;
using MyApp.Application.Models.Requests.BillingLines;
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
    private readonly IProductService _productService;

    public BillingController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
        ILogger<BillingController> logger, AppDbContext dbContext, IBillingService billingService,
        IProductService productService)
        : base(userManager, signInManager, logger, dbContext)
    {
        _billingService = billingService;
        _productService = productService;
    }


    [HttpGet]
    public async Task<IActionResult> Index(Guid customerId)
    {
        var customerBillings = await _billingService.GetAllBillingsForCustomer(customerId);

        return View(customerBillings);
    }

    [HttpGet]
    public async Task<IActionResult> Add(Guid customerId)
    {
        var result = new BillingCreateReq
        {
            CustomerId = customerId,
            Name = Guid.NewGuid().ToString(),
            BillingLines = new List<BillingLineCreateReq>()
        };

        // Add to db
        await _billingService.CreateBilling(result);

        return RedirectToAction("Index", "Billing", new { customerId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, Guid customerId)
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

        return View(new BillingEditReq(billing));
    }


    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpPost]
    public async Task<ActionResult> AddBillingLine([FromForm] BillingEditReq req)
    {
        await _billingService.CreateOrUpdateBillingLine(req);
        
        return RedirectToAction("Edit", "Billing", new { id = req.Id, customerId = req.CustomerId });
    }

    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpGet]
    public async Task<ActionResult> RemoveBillingLine(Guid id)
    {
        var ids = await _billingService.DeleteBillingLine(id);
        
        return RedirectToAction("Edit", "Billing", new { id = ids.BillingId, customerId = ids.BillingCustomerId });
    }

    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    // [HttpPost]
    // public async Task<ActionResult> CancelAndRefresh([FromForm] BillingCreateReq req)
    // {
    //     // force reload of data from database
    //     return RedirectToAction("Add", "Billing", new { customerId = req.CustomerId });
    // }
    
    [HttpGet]
    public async Task<ActionResult> Delete(Guid id, Guid customerId)
    {
        await _billingService.DeleteBillingWithId(id, customerId);
        
        return RedirectToAction("Index", "Billing", new { customerId });
    }
}