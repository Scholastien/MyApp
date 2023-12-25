using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;
using ControllerBase = MyApp.WebApi.Controllers.ControllerBase;

namespace WebApi.Controllers;

public class HealthController : ControllerBase
{
    public HealthController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager, ILogger<ControllerBase> logger, AppDbContext dbContext) : base(userManager, signInManager, logger, dbContext)
    {
    }
    
    [HttpGet]
    public IActionResult IsPostgresConnected()
    {
        return DbContext.Database.CanConnect() ? Ok() : Forbid();
    }
}