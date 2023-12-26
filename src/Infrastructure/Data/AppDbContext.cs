using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Discounts;

namespace MyApp.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUserBase>
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<DiscountPolicy> DiscountPolicies { get; set; }
    
    /// <inheritdoc />
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        builder.Entity<BulkDiscount>()
            .Property(b => b.EntrepriseId)
            .HasColumnName("EntrepriseId");
        
        builder.Entity<PunctualDiscount>()
            .Property(b => b.DiscountType)
            .HasColumnName("DiscountType");
    }
}