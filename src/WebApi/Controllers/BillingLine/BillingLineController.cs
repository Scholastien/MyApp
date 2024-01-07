using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    private readonly IBillingService _billingService;

    public BillingLineController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<BillingLineController> logger,
        AppDbContext dbContext, IBillingService billingService) : base(userManager,
        signInManager, logger, dbContext)
    {
        _billingService = billingService;
    }
    
    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpPost]
    public async Task<ActionResult> Add([FromForm] BillingEditReq req)
    {
        await _billingService.CreateOrUpdateBillingLine(req);
        
        return RedirectToAction("Edit", "Billing", new { id = req.Id, customerId = req.CustomerId });
    }

    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpGet]
    public async Task<ActionResult> Delete(Guid id)
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
}