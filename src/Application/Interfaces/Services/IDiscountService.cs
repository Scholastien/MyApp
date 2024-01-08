using MyApp.Application.Models.Dtos.Discounts;

namespace MyApp.Application.Interfaces.Services;

public interface IDiscountService
{
    Task<DiscountDto> GetDiscountDtoById(Guid id, CancellationToken ctk = default);
}