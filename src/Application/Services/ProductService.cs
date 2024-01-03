using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Products;
using MyApp.Application.Models.Requests.Products;
using MyApp.Application.Models.Responses.Products;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Payments;
using MyApp.Domain.Entities.Products;
using MyApp.Domain.Specifications.Products;

namespace MyApp.Application.Services;

public class ProductService : ServiceBase, IProductService
{
    public ProductService(IUnitOfWork unitOfWork, ILoggerService loggerService)
        : base(unitOfWork, loggerService)
    {
    }

    public async Task<MultipleProductRes> GetAllProducts(CancellationToken ctk = default)
    {
        var availableProductsSpec = ProductSpecifications.GetAllAvailableProductsSpec();

        var individuals = await UnitOfWork.Repository<Product>().ListAsync(availableProductsSpec, ctk);

        return new MultipleProductRes
        {
            Data = individuals.Select(x => new ProductDto(x)).ToList()
        };
    }

    public async Task<IBaseResponse<ProductDto>> CreateProduct(ProductCreateReq req, CancellationToken ctk = default)
    {
        var product = await UnitOfWork.Repository<Product>().AddAsync(new Product
        {
            Name = req.Name,
            Price = req.Price
        }, ctk);

        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo("New product created");

        return new ProductRes
        {
            Data = new ProductDto(product)
        };
    }

    public async Task<ProductDto> GetProductDtoById(Guid id, CancellationToken ctk = default)
    {
        var product = await UnitOfWork.Repository<Product>().GetByIdAsync(id, ctk);

        // Return if not null
        if (product != null)
            return new ProductDto(product);

        // Log and throw
        LoggerService.LogError($"Couldn't find product with ID {id}");
        throw new NullReferenceException();
    }

    public async Task UpdateProduct(ProductEditReq req, CancellationToken ctk = default)
    {
        var product = await UnitOfWork.Repository<Product>().GetByIdAsync(req.Id, ctk);

        if (product == null)
        {
            LoggerService.LogError($"Couldn't find product with ID {req.Id}");
            throw new NullReferenceException();
        }

        req.WriteTo(product);
        UnitOfWork.Repository<Product>().Update(product);
        await UnitOfWork.SaveChangesAsync(ctk);

        LoggerService.LogInfo($"Payment {req.Id} updated");
    }

    public async Task DeleteProductWithId(Guid id, CancellationToken ctk = default)
    {
        var product = await UnitOfWork.Repository<Product>().GetByIdAsync(id, ctk);

        if (product == null)
        {
            LoggerService.LogError($"Couldn't find product with ID {id}");
            throw new NullReferenceException();
        }

        UnitOfWork.Repository<Product>().Delete(product);
        await UnitOfWork.SaveChangesAsync(ctk);
    }
}