using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.Requests;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class CustomerController : BaseControllerApp
{
    private readonly ICustomerService _customerService;

    public CustomerController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
        ILogger<BaseControllerApp> logger, AppDbContext dbContext, ICustomerService customerService) : base(userManager, signInManager, logger, dbContext)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken ctk = default)
    {
        var activeUsers = await _customerService.GetAllActiveCustomers(ctk);

        return View(activeUsers);
    }
    
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(CustomerCreateReq req, CancellationToken ctk = default)
    {
        await _customerService.CreateCustomer(req, ctk);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id, CancellationToken ctk = default)
    { 
        var dto = await _customerService.GetCustomerDtoById(id, ctk);

        var editReq = new CustomerEditReq(dto);
        
        return View(editReq);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] CustomerEditReq req, CancellationToken ctk = default)
    { 
        await _customerService.UpdateCustomer(req, ctk);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ctk = default)
    {
        await _customerService.DeleteCustomerWithId(id, ctk);
        
        return RedirectToAction("Index");
    }
}