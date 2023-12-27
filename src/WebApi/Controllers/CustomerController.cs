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
    public async Task<IActionResult> Index()
    {
        var activeUsers = await _customerService.GetAllActiveCustomers();

        return View(activeUsers);
    }
    
    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(CustomerCreateReq req)
    {
        await _customerService.CreateCustomer(req);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    { 
        var dto = await _customerService.GetCustomerDtoById(id);

        var editReq = new CustomerEditReq(dto);
        
        return View(editReq);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] CustomerEditReq req)
    { 
        await _customerService.UpdateCustomer(req);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _customerService.DeleteCustomerWithId(id);
        
        return RedirectToAction("Index");
    }
}