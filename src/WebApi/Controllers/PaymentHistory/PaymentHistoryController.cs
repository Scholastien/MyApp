using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.PaymentHistory;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class PaymentHistoryController : BaseControllerApp
{
    public PaymentHistoryController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<PaymentHistoryController> logger,
        AppDbContext dbContext) : base(userManager, signInManager, logger, dbContext)
    {
    }
    
    [HttpGet]
    public async Task<ActionResult> Index(Guid billingId, Guid customerId)
    {
        return View();
    }
}