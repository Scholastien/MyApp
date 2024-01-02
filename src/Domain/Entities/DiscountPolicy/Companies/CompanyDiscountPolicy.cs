using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.DiscountPolicy.Companies;

public class CompanyDiscountPolicy : DiscountPolicyBase
{
    public CompanySizeEnum CompanySize { get; set; }
}