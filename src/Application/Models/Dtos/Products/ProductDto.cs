using MyApp.Domain.Entities.Products;

namespace MyApp.Application.Models.Dtos.Products;

public class ProductDto : BaseDto<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }

    public ProductDto()
    {
    }

    public ProductDto(Product entity) : base(entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Price = entity.Price;
    }

    public override void WriteTo(Product entity)
    {
        base.WriteTo(entity);
        entity.Name = Name;
        entity.Price = Price;
        entity.LastModifiedOn = DateTimeOffset.Now;
    }
}