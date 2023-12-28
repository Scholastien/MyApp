using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Domain.Entities.Customers;

public class Company : Customer
{
    [MaxLength(100)] public string Kbis { get; set; }
}