﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Entities.DiscountPolicy.Companies;
using MyApp.Domain.Entities.DiscountPolicy.Individuals;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Enums;

namespace MyApp.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUserBase>
{
    // Customers
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Company>? Companies { get; set; }
    public DbSet<Individual>? Individuals { get; set; }
    
    // CustomersDetails
    public DbSet<CustomerDetails>? CustomersDetails { get; set; }
    
    public DbSet<Payment>? Payments { get; set; }
    
    public DbSet<Billing>? Billings { get; set; }
    
    public DbSet<BillingLine>? BillingLines { get; set; }
    
    public DbSet<Product>? Products { get; set; }
    
    public DbSet<BillingDiscount>? BillingsDiscounts { get; set; }
    
    public DbSet<Discount>? Discounts { get; set; }
    
    // DiscountPolicies
    public DbSet<DiscountPolicyBase>? DiscountPolicies { get; set; }
    public DbSet<IndividualDiscountPolicy>? IndividualDiscountPolicies { get; set; }
    public DbSet<CompanyDiscountPolicy>? CompanyDiscountPolicies { get; set; }

    /// <inheritdoc />
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Discriminator on CustomerType to differentiate Companies from Individuals
        builder.Entity<Customer>()
            .HasDiscriminator<CustomerTypeEnum>("CustomerType")
            .HasValue<Company>(CustomerTypeEnum.Company)
            .HasValue<Individual>(CustomerTypeEnum.Individual);

        // Discriminator on CustomerType to differentiate CompanyDiscountPolicies from IndividualDiscountPolicies
        builder.Entity<DiscountPolicyBase>()
            .HasDiscriminator<CustomerTypeEnum>("CustomerType")
            .HasValue<IndividualDiscountPolicy>(CustomerTypeEnum.Individual)
            .HasValue<CompanyDiscountPolicy>(CustomerTypeEnum.Company);
        
        // 1 to 1 relationship for Customer-BillingDetails
        builder.Entity<Customer>()
            .HasOne(r => r.BillingDetails)
            .WithOne()
            .HasForeignKey<CustomerDetails>("BillingDetailsId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        
        // 1 to 1 relationship for Customer-ShippingDetails
        builder.Entity<Customer>()
            .HasOne(r => r.ShippingDetails)
            .WithOne()
            .HasForeignKey<CustomerDetails>("ShippingDetailsId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        
        // * to * relationship with navigation Billing-Discount
        builder.Entity<Billing>()
            .HasMany(e => e.Discounts)
            .WithMany(e => e.Billings)
            .UsingEntity<BillingDiscount>(
                l => l.HasOne<Discount>().WithMany(e => e.BillingsDiscounts),
                r => r.HasOne<Billing>().WithMany(e => e.BillingsDiscounts));
    }
}