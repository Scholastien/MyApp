﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.Models.DTOs.Customers;
using MyApp.Application.Models.Requests.Customers.Companies;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.Customers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class CompanyController : BaseControllerApp
{
    private readonly ICompanyService<CompanyDto> _companyService;

    public CompanyController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
        ILogger<CompanyController> logger, AppDbContext dbContext, ICompanyService<CompanyDto> companyService) 
        : base(userManager, signInManager, logger, dbContext)
    {
        _companyService = companyService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var activeUsers = await _companyService.GetAllActiveCompanies();

        return View(activeUsers);
    }
    
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] CompanyCreateReq req)
    {
        await _companyService.CreateCompany(req);
        
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    { 
        var dto = await _companyService.GetCompanyDtoById(id);

        var editReq = new CompanyEditReq(dto);
        
        return View(editReq);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] CompanyEditReq req)
    { 
        await _companyService.UpdateCompany(req);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _companyService.DeleteCompanyWithId(id);
        
        return RedirectToAction("Index");
    }
}