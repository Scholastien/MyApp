using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Application.Models.Requests.DiscountPolicies;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.DiscountPolicy;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class DiscountPolicyController : BaseControllerApp
{
    private readonly IDiscountPolicyService _discountPolicyService;

    public DiscountPolicyController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<DiscountPolicyController> logger, AppDbContext dbContext,
        IDiscountPolicyService discountPolicyService) : base(userManager, signInManager, logger, dbContext)
    {
        _discountPolicyService = discountPolicyService;
    }

    public async Task<IActionResult> Index()
    {
        var res = await _discountPolicyService.GetAllDiscountPolicys();

        res.Data = res.Data
            .OrderBy(d => d.CustomerType)
            .ThenBy(d => d.DiscountType)
            .ToList();
        
        return View(res);
    }
    
    public async Task<IActionResult> Edit(Guid id, string? msg)
    {
        var dto = await _discountPolicyService.GetDiscountPolicyDtoById(id);

        var editReq = new DiscountPolicyEditReq<DiscountPolicyDto<DiscountPolicyBase>, DiscountPolicyBase>(dto);

        if (msg != null)
        {
            ViewBag.CreateMsg = msg;
        }
        
        return View(editReq);
    }
    
    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpPost]
    public async Task<ActionResult> CreateDiscount([FromForm] DiscountPolicyEditReq<DiscountPolicyDto<DiscountPolicyBase>, DiscountPolicyBase> req)
    {
        var res = await _discountPolicyService.CreateDiscount(req);
        
        return RedirectToAction("Edit", "DiscountPolicy", new { id = req.Id, msg = res.CreateDiscountMessage});
    }
    
    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique" de ligne pendant la creation de la facture
    [HttpGet]
    public async Task<ActionResult> DeleteDiscount(Guid id)
    {
        var discountPolicyId = await _discountPolicyService.DeleteDiscount(id);
        
        return RedirectToAction("Edit", "DiscountPolicy", new { id = discountPolicyId });
    }
}