using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Enums;

namespace MyApp.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUserBase>
{
    public DbSet<CustomerDetails>? CustomersDetails { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Company>? Companies { get; set; }
    public DbSet<Individual>? Individuals { get; set; }
    public DbSet<Payment>? Payments { get; set; }
    public DbSet<Billing>? Billings { get; set; }
    public DbSet<BillingLine>? BillingLines { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<DiscountPolicy>? DiscountPolicies { get; set; }

    /// <inheritdoc />
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        builder.Entity<Customer>()
            .HasDiscriminator<CustomerTypeEnum>("CustomerType")
            .HasValue<Company>(CustomerTypeEnum.Company)
            .HasValue<Individual>(CustomerTypeEnum.Individual);

        builder.Entity<DiscountPolicy>()
            .HasDiscriminator<DiscountTypeEnum>("DiscountType")
            .HasValue<BulkDiscount>(DiscountTypeEnum.Bulk)
            .HasValue<PunctualDiscount>(DiscountTypeEnum.Punctual);
        
        builder.Entity<Customer>()
            .HasOne(r => r.BillingDetails)
            .WithOne()
            .HasForeignKey<CustomerDetails>("BillingDetailsId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        builder.Entity<Customer>()
            .HasOne(r => r.ShippingDetails)
            .WithOne()
            .HasForeignKey<CustomerDetails>("ShippingDetailsId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}