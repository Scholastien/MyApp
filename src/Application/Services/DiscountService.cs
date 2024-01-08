using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.Discounts;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Specifications.Discounts;

namespace MyApp.Application.Services;

public class DiscountService : ServiceBase, IDiscountService
{
    public DiscountService(IUnitOfWork unitOfWork, ILoggerService loggerService) : base(unitOfWork, loggerService)
    {
    }

    public async Task<DiscountDto> GetDiscountDtoById(Guid id, CancellationToken ctk = default)
    {
        var discountWithIdSpec = DiscountSpecifications.GetDiscountWithIdSpec(id);
        var discount = await UnitOfWork.Repository<Discount>().FirstOrDefaultAsync(discountWithIdSpec, ctk);

        // Return if not null
        if (discount != null)
            return new DiscountDto(discount);

        // Log and throw
        LoggerService.LogError($"Couldn't find Discount with ID {id}");
        throw new NullReferenceException();
    }
}