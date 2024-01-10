using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Products;
using MyApp.Application.Models.Requests.Products;
using MyApp.Application.Models.Responses.Products;
using MyApp.Domain.Core.Repositories;
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
        try
        {
            var product = await GetEntityByIdAsync<Product>(id, ctk);

            return new ProductDto(product);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Product fetching as Dto occured", e);
            throw;
        }
    }

    public async Task UpdateProduct(ProductEditReq req, CancellationToken ctk = default)
    {
        try
        {
            var product = await GetEntityByIdAsync<Product>(req.Id, ctk);

            req.WriteTo(product);
            UnitOfWork.Repository<Product>().Update(product);
            await UnitOfWork.SaveChangesAsync(ctk);

            LoggerService.LogInfo($"Payment {req.Id} updated");
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Product update occured", e);
            throw;
        }
    }

    public async Task DeleteProductWithId(Guid id, CancellationToken ctk = default)
    {
        try
        {
            var product = await GetEntityByIdAsync<Product>(id, ctk);

            UnitOfWork.Repository<Product>().Delete(product);
            await UnitOfWork.SaveChangesAsync(ctk);
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Product deletion occured", e);
            throw;
        }
    }
}