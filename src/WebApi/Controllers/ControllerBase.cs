using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers;

public abstract class ControllerBase : Controller

{
    protected readonly UserManager<IdentityUserBase> UserManager;
    protected readonly SignInManager<IdentityUserBase> SignInManager;
    protected readonly ILogger<ControllerBase> Logger;
    protected AppDbContext DbContext;


    protected ControllerBase(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager,
        ILogger<ControllerBase> logger, AppDbContext dbContext)
    {
        UserManager = userManager;
        SignInManager = signInManager;
        Logger = logger;
        DbContext = dbContext;
    }
}