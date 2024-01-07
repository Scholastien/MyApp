using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Application.Models.Requests.DiscountPolicies;
using MyApp.Application.Models.Responses.DiscountPolicies;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Specifications.DiscountPolicies;
using MyApp.Domain.Specifications.Discounts;

namespace MyApp.Application.Services;

public class DiscountPolicyService: ServiceBase, IDiscountPolicyService
{
    public DiscountPolicyService(IUnitOfWork unitOfWork, ILoggerService loggerService) : base(unitOfWork, loggerService)
    {
    }

    public async Task<MultipleDiscountPolicyRes<DiscountPolicyBase>> GetAllDiscountPolicys(CancellationToken ctk = default)
    {
        var spec = DiscountPolicySpecifications.GetAllAvailableDiscountPoliciesSpec();

        var individuals = await UnitOfWork.Repository<DiscountPolicyBase>().ListAsync(spec, ctk);

        return new MultipleDiscountPolicyRes<DiscountPolicyBase>
        {
            Data = individuals.Select(x => new DiscountPolicyDto<DiscountPolicyBase>(x)).ToList()
        };
    }

    public async Task<DiscountPolicyDto<DiscountPolicyBase>> GetDiscountPolicyDtoById(Guid id, CancellationToken ctk = default)
    {
        var spec = DiscountPolicySpecifications.GetDiscountPolicyDtoByIdSpec(id);
        var discountPolicy = await UnitOfWork.Repository<DiscountPolicyBase>().FirstOrDefaultAsync(spec, ctk);

        // Return if not null
        if (discountPolicy != null)
            return new DiscountPolicyDto<DiscountPolicyBase>(discountPolicy);

        // Log and throw
        LoggerService.LogError($"Couldn't find DiscountPolicy with ID {id}");
        throw new NullReferenceException();
    }

    public async Task<DiscountPolicyRes> CreateDiscount(DiscountPolicyEditReq<DiscountPolicyDto<DiscountPolicyBase>, DiscountPolicyBase> req, CancellationToken ctk = default)
    {
        var lineSpec = DiscountSpecifications.WithExistingValueForDiscountPolicyIdSpec(req.Id, req.NewDiscountValue);
        var line = await UnitOfWork.Repository<Discount>().FirstOrDefaultAsync(lineSpec, ctk);


        var spec = DiscountPolicySpecifications.GetDiscountPolicyDtoByIdSpec(req.Id);
        var policy = await UnitOfWork.Repository<DiscountPolicyBase>().FirstOrDefaultAsync(spec, ctk);

        var discountfound = policy?.Discounts.FirstOrDefault(d => d.Value == req.NewDiscountValue);
        
        string msg;
        
        if (discountfound == null && req.NewDiscountValue <= policy.MaxValue)
        {
            var discount = await UnitOfWork.Repository<Discount>().AddAsync(new Discount
            {
                DiscountPolicyId = req.Id,
                Value = req.NewDiscountValue,
                CreatedOn = DateTimeOffset.Now,
                CreatedBy = Guid.NewGuid(),
            }, ctk);

            await UnitOfWork.SaveChangesAsync(ctk);

            msg = $"New billing line created: {discount.Id}";
            LoggerService.LogInfo(msg);
        }
        else if (req.NewDiscountValue > policy.MaxValue)
        {
            msg = $"The Value chose ({req.NewDiscountValue}) exceed the policy max value";
            LoggerService.LogInfo(msg);
        }
        else
        {
            msg = $"A Discount with that value ({req.NewDiscountValue} already exist)";
            LoggerService.LogInfo(msg);
        }
        
        return new DiscountPolicyRes
        {
            Data = await GetDiscountPolicyDtoById(req.Id, ctk),
            CreateDiscountMessage = msg
        };
    }

    public async Task<Guid> DeleteDiscount(Guid id, CancellationToken ctk = default)
    {
        var discount = await UnitOfWork.Repository<Discount>().GetByIdAsync(id, ctk);

        if (discount == null)
        {
            LoggerService.LogError($"Couldn't find Discount with ID {id}");
            throw new NullReferenceException();
        }

        UnitOfWork.Repository<Discount>().Delete(discount);
        await UnitOfWork.SaveChangesAsync(ctk);

        return discount.DiscountPolicyId;
    }
}