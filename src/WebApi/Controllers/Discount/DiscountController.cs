using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Application.Models.Requests.DiscountPolicies;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.Discount;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class DiscountController : BaseControllerApp
{
    private readonly IDiscountPolicyService _discountPolicyService;

    public DiscountController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
        ILogger<DiscountController> logger, AppDbContext dbContext,
        IDiscountPolicyService discountPolicyService) : base(userManager, signInManager, logger, dbContext)
    {
        _discountPolicyService = discountPolicyService;
    }

    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique"
    [HttpPost]
    public async Task<ActionResult> Add(
        [FromForm] DiscountPolicyEditReq<DiscountPolicyDto<DiscountPolicyBase>, DiscountPolicyBase> req)
    {
        var res = await _discountPolicyService.CreateDiscount(req);

        return RedirectToAction("Edit", "DiscountPolicy", new { id = req.Id, msg = res.CreateDiscountMessage });
    }

    // TODO : utiliser Session and state management pour l'ajout/suppression "dynamique"
    [HttpGet]
    public async Task<ActionResult> Delete(Guid id)
    {
        var discountPolicyId = await _discountPolicyService.DeleteDiscount(id);

        return RedirectToAction("Edit", "DiscountPolicy", new { id = discountPolicyId });
    }
}