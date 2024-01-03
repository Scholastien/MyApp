using MyApp.Application.Interfaces.Models.Requests;
using MyApp.Application.Models.Dtos.Products;
using MyApp.Application.Models.Requests.Products;
using MyApp.Application.Models.Responses.Products;

namespace MyApp.Application.Interfaces.Services;

public interface IProductService
{
    Task<MultipleProductRes> GetAllProducts(CancellationToken ctk = default);
    Task<IBaseResponse<ProductDto>> CreateProduct(ProductCreateReq req, CancellationToken ctk = default);
    Task<ProductDto> GetProductDtoById(Guid id, CancellationToken ctk = default);
    Task UpdateProduct(ProductEditReq req, CancellationToken ctk = default);
    Task DeleteProductWithId(Guid id, CancellationToken ctk = default);
}