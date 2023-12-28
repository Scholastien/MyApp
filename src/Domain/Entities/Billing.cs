using System.ComponentModel.DataAnnotations;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities.Discounts;

namespace MyApp.Domain.Entities;

public class Billing : BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}