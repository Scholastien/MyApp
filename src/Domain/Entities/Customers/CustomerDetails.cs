using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Core.Models;

namespace MyApp.Domain.Entities.Customers;

public class CustomerDetails : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; init; }

    public Guid? BillingDetailsId { get; set; }
    public Guid? ShippingDetailsId { get; set; }

    // [MaxLength(100)] public required string Street { get; set; }
    // [MaxLength(100)] public required string City { get; set; }
    // [MaxLength(100)] public required string PostalCode { get; set; }
    // [MaxLength(100)] public required string State { get; set; }
    // [MaxLength(100)] public required string Country { get; set; }
}