using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Requests.Customers.Individuals;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.Customer;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class IndividualController : BaseControllerApp
{
    private readonly IIndividualService _individualService;

    public IndividualController(UserManager<IdentityUserBase> userManager,
        SignInManager<IdentityUserBase> signInManager, ILogger<IndividualController> logger, AppDbContext dbContext,
        IIndividualService individualService)
        : base(userManager, signInManager, logger, dbContext)
    {
        _individualService = individualService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var activeUsers = await _individualService.GetAllActiveIndividuals();

        return View(activeUsers);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        var req = new IndividualCreateReq();
        return View(req);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] IndividualCreateReq req)
    {
        if (!ModelState.IsValid)
        {
            return View(req);
        }
        
        await _individualService.CreateIndividual(req);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    { 
        var dto = await _individualService.GetIndividualDtoById(id);

        var editReq = new IndividualEditReq(dto)
        {
            CustomerType = CustomerTypeEnum.Individual
        };
        
        return View(editReq);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] IndividualEditReq req)
    { 
        if (!ModelState.IsValid)
        {
            return View(req);
        }
        
        await _individualService.UpdateIndividual(req);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _individualService.DeleteIndividualWithId(id);
        
        return RedirectToAction("Index");
    }
}