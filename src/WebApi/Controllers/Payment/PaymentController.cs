using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Requests.Customers.Companies;
using MyApp.Application.Models.Requests.Payment;
using MyApp.Domain.Entities;
using MyApp.Domain.Enums;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.Payment;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class PaymentController : BaseControllerApp
{
    private readonly IPaymentService _paymentService;
    private readonly ICustomerService _customerService;

    public PaymentController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
        ILogger<PaymentController> logger, AppDbContext dbContext, IPaymentService paymentService,
        ICustomerService customerService)
        : base(userManager, signInManager, logger, dbContext)
    {
        _paymentService = paymentService;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IActionResult> Add(Guid customerId)
    {
        var type = await _customerService.GetCustomerTypeWithId(customerId);

        var req = new PaymentCreateReq
        {
            CustomerId = customerId,
            EntityController = type.ToString()
        };
        return View(req);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm] PaymentCreateReq req)
    {
        if (!ModelState.IsValid)
        {
            return View(req);
        }

        await _paymentService.CreatePayment(req);

        return RedirectToAction("Edit", req.EntityController, new { id = req.CustomerId });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid paymentId, Guid customerId)
    {
        var type = await _customerService.GetCustomerTypeWithId(customerId);

        var dto = await _paymentService.GetPaymentDtoById(paymentId, type);

        var editReq = new PaymentEditReq(dto)
        {
            EntityController = type.ToString()
        };

        return View(editReq);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] PaymentEditReq req)
    {
        if (!ModelState.IsValid)
        {
            return View(req);
        }

        await _paymentService.UpdatePayment(req);

        return RedirectToAction("Edit", req.EntityController, new { id = req.CustomerId });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid paymentId, Guid customerId)
    {
        var type = await _customerService.GetCustomerTypeWithId(customerId);

        await _paymentService.DeletePaymentWithId(paymentId);

        return RedirectToAction("Edit", type.ToString(), new { id = customerId });
    }
}