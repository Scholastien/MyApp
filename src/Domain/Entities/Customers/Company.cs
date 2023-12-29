using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.Entities.Customers;

public class Company : Customer
{
    [MaxLength(100)] public required string Kbis { get; set; }
}