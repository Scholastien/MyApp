using MyApp.Domain.Core.Specifications;
using MyApp.Domain.Entities.Products;

namespace MyApp.Domain.Specifications.Products;

public class ProductSpecifications
{
    public static BaseSpecification<Product> GetAllAvailableProductsSpec()
    {
        return new BaseSpecification<Product>(c => c.IsDeleted == false);
    }
}