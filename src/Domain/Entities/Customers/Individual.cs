using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.Entities.Customers;

public class Individual : Customer
{
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
}