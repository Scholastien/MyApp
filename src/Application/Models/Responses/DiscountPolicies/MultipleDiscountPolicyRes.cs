using MyApp.Application.Models.Dtos.DiscountPolicies;
using MyApp.Domain.Entities.DiscountPolicy;

namespace MyApp.Application.Models.Responses.DiscountPolicies;

public class MultipleDiscountPolicyRes<T> : MultipleBaseResponse<DiscountPolicyDto<T>, T>
    where T : DiscountPolicyBase
{
}