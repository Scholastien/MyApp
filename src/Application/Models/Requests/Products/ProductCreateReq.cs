using System.ComponentModel.DataAnnotations;
using MyApp.Application.Interfaces.Models.Requests.Products;

namespace MyApp.Application.Models.Requests.Products;

public class ProductCreateReq : IProductReq
{
    #region IProductReq

    [MaxLength(50)]
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Range(0.1f, float.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    [Required(ErrorMessage = "Price is required")]
    public float Price { get; set; }

    #endregion
}