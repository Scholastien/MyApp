using System.ComponentModel.DataAnnotations;
using MyApp.Application.Models.Dtos.Products;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Products;

namespace MyApp.Application.Models.Requests.Products;

public class ProductEditReq : BaseEditRequest<ProductDto, Product>
{
    public Guid Id { get; set; }
    [MaxLength(50)] public string Name { get; set; }
    [Range(0.1f, float.MaxValue)] public float Price { get; set; }

    public ProductEditReq()
    {
    }

    public ProductEditReq(ProductDto data) : base(data)
    {
        Id = data.Id;
        Name = data.Name;
        Price = data.Price;
    }

    public override void WriteTo(Product entity)
    {
        base.WriteTo(entity);
        entity.Name = Name;
        entity.Price = Price;
    }
}