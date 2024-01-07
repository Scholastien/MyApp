using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Domain.Entities.DiscountPolicy;

namespace MyApp.Application.Models.Responses.DiscountPolicies;

public class DiscountPolicyRes : BaseResponse<DiscountPolicyDto<DiscountPolicyBase>, DiscountPolicyBase>
{
    public string CreateDiscountMessage { get; set; }
}