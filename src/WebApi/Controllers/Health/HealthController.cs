using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.Health;

public class HealthController : BaseControllerApp
{
    public HealthController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager, ILogger<HealthController> logger, AppDbContext dbContext) 
        : base(userManager, signInManager, logger, dbContext)
    {
    }
    
    [HttpGet]
    public IActionResult IsPostgresConnected()
    {
        return DbContext.Database.CanConnect() ? Ok() : Forbid();
    }
}