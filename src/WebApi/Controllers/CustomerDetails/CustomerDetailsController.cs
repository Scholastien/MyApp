using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Requests.Customers;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.CustomerDetails;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class CustomerDetailsController : BaseControllerApp
{
    private readonly ICustomerDetailsService _customerDetailsService;

    public CustomerDetailsController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<CustomerDetailsController> logger,
        AppDbContext dbContext, ICustomerDetailsService customerDetailsService)
        : base(userManager, signInManager, logger, dbContext)
    {
        _customerDetailsService = customerDetailsService;
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var dto = await _customerDetailsService.GetCustomerDetailsDtoById(id);

        var editReq = new CustomerDetailsEditReq(dto)
        {
            CustomerType = dto.CustomerType,
        };

        return View(editReq);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] CustomerDetailsEditReq req)
    {
        if (!ModelState.IsValid)
        {
            return View(req);
        }

        await _customerDetailsService.UpdateCustomerDetails(req);

        return req.CustomerType switch
        {
            CustomerTypeEnum.Individual => RedirectToAction("Edit", "Individual", new { id = req.CustomerId }),
            CustomerTypeEnum.Company => RedirectToAction("Edit", "Company", new { id = req.CustomerId }),
            _ => RedirectToAction("Index", "Home")
        };
    }
}