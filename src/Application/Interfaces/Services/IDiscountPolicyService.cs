using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Application.Models.Requests.DiscountPolicies;
using MyApp.Application.Models.Responses.DiscountPolicies;
using MyApp.Domain.Entities.DiscountPolicy;

namespace MyApp.Application.Interfaces.Services;

public interface IDiscountPolicyService
{
    Task<MultipleDiscountPolicyRes<DiscountPolicyBase>> GetAllDiscountPolicys(CancellationToken ctk = default);
    Task<DiscountPolicyDto<DiscountPolicyBase>> GetDiscountPolicyDtoById(Guid id, CancellationToken ctk = default);
    Task<DiscountPolicyRes> CreateDiscount(DiscountPolicyEditReq<DiscountPolicyDto<DiscountPolicyBase>, DiscountPolicyBase> req, CancellationToken ctk = default);
    Task<Guid> DeleteDiscount(Guid id, CancellationToken ctk = default);
}