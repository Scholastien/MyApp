using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities.Customers;

public class Company : Customer
{
    [MaxLength(100)] public required string Kbis { get; set; }
    public required CompanySizeEnum CompanySize { get; set; }
}