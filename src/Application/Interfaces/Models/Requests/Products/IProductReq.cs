namespace MyApp.Application.Interfaces.Models.Requests.Products;

public interface IProductReq
{
    public string Name { get; set; }
    public float Price { get; set; }
}