using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers;

public abstract class BaseControllerApp : Controller

{
    protected readonly UserManager<IdentityUserBase> UserManager;
    protected readonly SignInManager<IdentityUserBase> SignInManager;
    protected readonly ILogger<BaseControllerApp> Logger;
    protected readonly AppDbContext DbContext;


    protected BaseControllerApp(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager,
        ILogger<BaseControllerApp> logger, AppDbContext dbContext)
    {
        UserManager = userManager;
        SignInManager = signInManager;
        Logger = logger;
        DbContext = dbContext;
    }
}