using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;

namespace WebApp.Controllers
{
    public class AccountController : ControllerBase
    {
        public AccountController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
            ILogger<AccountController> logger, ApplicationDbContext dbContext) 
            : base(userManager, signInManager, logger, dbContext)
        {
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new IdentityUserRegistrationDto();
            return View(model);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(IdentityUserRegistrationDto request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var userCheck = await UserManager.FindByEmailAsync(request.Email);

            if (userCheck == null)
            {
                var user = request.ToNewIdentityUser();

                var result = await UserManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                if (!result.Errors.Any()) return View(request);

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("message", error.Description);
                }

                return View(request);
            }

            ModelState.AddModelError("message", "Email already exists.");
            return View(request);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new IdentityUserLoginDto();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(IdentityUserLoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user is { EmailConfirmed: false })
            {
                ModelState.AddModelError("message", "Email not confirmed yet");
                return View(model);
            }

            if (await UserManager.CheckPasswordAsync(user, model.Password) == false)
            {
                ModelState.AddModelError("message", "Invalid credentials");
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                await UserManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("message", "Invalid login attempt");
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}