using MyApp.Application.Core.Services;
using MyApp.Application.Interfaces.Services;
using MyApp.Application.Models.Dtos.BillingsDiscounts;
using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Application.Models.Dtos.Discounts;
using MyApp.Application.Models.Requests.BillingsDiscounts;
using MyApp.Application.Models.Requests.DiscountPolicies;
using MyApp.Application.Models.Responses.DiscountPolicies;
using MyApp.Application.Models.Responses.Discounts;
using MyApp.Domain.Core.Repositories;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Enums;
using MyApp.Domain.Specifications.Billings;
using MyApp.Domain.Specifications.DiscountPolicies;
using MyApp.Domain.Specifications.Discounts;

namespace MyApp.Application.Services;

public class DiscountPolicyService : ServiceBase, IDiscountPolicyService
{
    public DiscountPolicyService(IUnitOfWork unitOfWork, ILoggerService loggerService) : base(unitOfWork, loggerService)
    {
    }

    private async Task<Billing> getBillingByIds(Guid billingId, Guid customerId, CancellationToken ctk = default)
    {
        var billingSpec = BillingSpecifications.SingleBillingWithAllIncludesSpec(billingId, customerId);
        var billing = await UnitOfWork.Repository<Billing>().FirstOrDefaultAsync(billingSpec, ctk);

        // Return if not null
        if (billing != null) return billing;

        // Log and throw
        LoggerService.LogError($"Couldn't find Billing with ID {billingId}");
        throw new NullReferenceException();
    }

    private async Task<DiscountPolicyBase> getDiscountPolicyById(Guid discountPolicyId, CancellationToken ctk = default)
    {
        var spec = DiscountPolicySpecifications.GetDiscountPolicyByIdSpec(discountPolicyId);
        var discountPolicy = await UnitOfWork.Repository<DiscountPolicyBase>().FirstOrDefaultAsync(spec, ctk);

        // Return if not null
        if (discountPolicy != null)
            return discountPolicy;

        // Log and throw
        LoggerService.LogError($"Couldn't find DiscountPolicy with ID {discountPolicyId}");
        throw new NullReferenceException();
    }

    public async Task<MultipleDiscountPolicyRes<DiscountPolicyBase>> GetAllDiscountPolicies(
        CancellationToken ctk = default)
    {
        var spec = DiscountPolicySpecifications.GetAllAvailableDiscountPoliciesSpec();

        var individuals = await UnitOfWork.Repository<DiscountPolicyBase>().ListAsync(spec, ctk);

        return new MultipleDiscountPolicyRes<DiscountPolicyBase>
        {
            Data = individuals.Select(x => new DiscountPolicyDto<DiscountPolicyBase>(x)).ToList()
        };
    }

    public async Task<DiscountPolicyDto<DiscountPolicyBase>> GetDiscountPolicyDtoById(Guid id,
        CancellationToken ctk = default)
    {
        var discountPolicy = await getDiscountPolicyById(id, ctk);

        return new DiscountPolicyDto<DiscountPolicyBase>(discountPolicy);
    }

    public async Task<DiscountPolicyRes> CreateDiscount(
        DiscountPolicyEditReq<DiscountPolicyDto<DiscountPolicyBase>, DiscountPolicyBase> req,
        CancellationToken ctk = default)
    {
        var discountPolicy = await getDiscountPolicyById(req.Id, ctk);

        var discountfound = discountPolicy?.Discounts.FirstOrDefault(d => d.Value == req.NewDiscountValue);

        string msg;

        if (discountPolicy != null && discountfound == null && req.NewDiscountValue <= discountPolicy.MaxValue)
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
        else if (discountPolicy != null && req.NewDiscountValue > discountPolicy.MaxValue)
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
        try
        {
            var discount = await GetEntityByIdAsync<Discount>(id, ctk);

            UnitOfWork.Repository<Discount>().Delete(discount);
            await UnitOfWork.SaveChangesAsync(ctk);

            return discount.DiscountPolicyId;
        }
        catch (Exception e)
        {
            LoggerService.LogError("A problem during Discount deletion occured", e);
            throw;
        }
    }

    public async Task<MultipleDiscountRes> GetAllAvailableBulkDiscountsLinkedToBilling(Guid billingId, Guid customerId,
        CancellationToken ctk = default)
    {
        var billing = await getBillingByIds(billingId, customerId, ctk);

        var discountPolicySpec =
            DiscountPolicySpecifications.GetAllAvailableDiscountPoliciesByCustomerTypeAndDiscountTypeSpec(
                billing.Customer.CustomerType, DiscountTypeEnum.Bulk, billing.Discounts);

        var discountPolicies = await UnitOfWork.Repository<DiscountPolicyBase>().ListAsync(discountPolicySpec, ctk);

        var availablePolicies = discountPolicies
            .Where(d => !d.Discounts.Any(billing.Discounts.Contains))
            .SelectMany(d => d.Discounts).ToList();


        return new MultipleDiscountRes
        {
            CustomerId = customerId,
            BillingId = billingId,
            Data = availablePolicies.Select(p => new DiscountDto(p)).ToList(),
        };
    }

    public async Task<BillingDiscountCreateReq> AttachDiscountToBilling(Guid billingId, Guid customerId,
        CancellationToken ctk = default)
    {
        var billing = await getBillingByIds(billingId, customerId, ctk);

        return new BillingDiscountCreateReq
        {
            CustomerType = billing.Customer.CustomerType.ToString(),
            BillingId = billingId,
            CustomerId = customerId,
            NewDiscount = Guid.Empty,
            //Discounts = billing.BillingsDiscounts.Select(d => new BillingDiscountDto(d)).ToList()
            Discounts = billing.Discounts
                .Select(d => d.BillingsDiscounts
                    .Where(b => b.BillingId == billingId && b.BillingCustomerId == customerId)
                    .Select(b => new BillingDiscountDto(b)
                    {
                        Name = d.Name
                    }))
                .SelectMany(b => b)
                .ToList(),
        };
    }
}