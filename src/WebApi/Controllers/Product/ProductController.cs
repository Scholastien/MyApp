using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Requests.Products;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.WebApi.Controllers.Product;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class ProductController : BaseControllerApp
{
    private readonly IProductService _productService;

    public ProductController(UserManager<IdentityUserBase> userManager, SignInManager<IdentityUserBase> signInManager,
        ILogger<ProductController> logger, AppDbContext dbContext, IProductService productService)
        : base(userManager, signInManager, logger, dbContext)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProducts();

        return View(products);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var req = new ProductCreateReq();
        return View(req);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromForm] ProductCreateReq req)
    { 
        if (!ModelState.IsValid)
        {
            return View(req);
        }
        
        await _productService.CreateProduct(req);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var dto = await _productService.GetProductDtoById(id);

        var editReq = new ProductEditReq(dto);
        
        return View(editReq);    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] ProductEditReq req)
    { 
        if (!ModelState.IsValid)
        {
            return View(req);
        }
        
        await _productService.UpdateProduct(req);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _productService.DeleteProductWithId(id);
        
        return RedirectToAction("Index");
    }
}