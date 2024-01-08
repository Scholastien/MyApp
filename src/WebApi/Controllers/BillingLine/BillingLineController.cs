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
    private readonly IBillingLineService _billingLineService;

    public BillingLineController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<BillingLineController> logger,
        AppDbContext dbContext, IBillingLineService billingLineService) : base(userManager,
        signInManager, logger, dbContext)
    {
        _billingLineService = billingLineService;
    }
    
    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpPost]
    public async Task<ActionResult> Add([FromForm] BillingEditReq req)
    {
        await _billingLineService.CreateOrUpdateBillingLine(req);
        
        return RedirectToAction("Edit", "Billing", new { id = req.Id, customerId = req.CustomerId });
    }

    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpGet]
    public async Task<ActionResult> Delete(Guid id)
    {
        var ids = await _billingLineService.DeleteBillingLine(id);
        
        return RedirectToAction("Edit", "Billing", new { id = ids.BillingId, customerId = ids.BillingCustomerId });
    }
}