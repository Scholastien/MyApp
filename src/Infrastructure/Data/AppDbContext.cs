using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Entities.Billings;
using MyApp.Domain.Entities.BillingsDiscounts;
using MyApp.Domain.Entities.Customers;
using MyApp.Domain.Entities.DiscountPolicy;
using MyApp.Domain.Entities.DiscountPolicy.Companies;
using MyApp.Domain.Entities.DiscountPolicy.Individuals;
using MyApp.Domain.Entities.Discounts;
using MyApp.Domain.Entities.PaymentHistories;
using MyApp.Domain.Entities.Payments;
using MyApp.Domain.Entities.Products;
using MyApp.Domain.Enums;

namespace MyApp.Infrastructure.Data;

public class AppDbContext : IdentityDbContext<IdentityUserBase>, IDataProtectionKeyContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;

    // Customers
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Individual> Individuals { get; set; } = null!;

    // CustomersDetails
    public DbSet<CustomerDetails> CustomersDetails { get; set; } = null!;

    public DbSet<Payment> Payments { get; set; } = null!;

    public DbSet<PaymentHistory> PaymentHistories { get; set; } = null!;

    public DbSet<Billing> Billings { get; set; } = null!;

    public DbSet<BillingLine> BillingLines { get; set; } = null!;

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<BillingDiscount> BillingsDiscounts { get; set; } = null!;

    public DbSet<Discount> Discounts { get; set; } = null!;

    // DiscountPolicies
    public DbSet<DiscountPolicyBase> DiscountPolicies { get; set; } = null!;
    public DbSet<IndividualDiscountPolicy> IndividualDiscountPolicies { get; set; } = null!;
    public DbSet<CompanyDiscountPolicy> CompanyDiscountPolicies { get; set; } = null!;

    /// <inheritdoc />
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        DataProtectionKeyMapping(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Discriminator on CustomerType to differentiate Companies from Individuals
        modelBuilder.Entity<Customer>()
            .HasDiscriminator<CustomerTypeEnum>("CustomerType")
            .HasValue<Company>(CustomerTypeEnum.Company)
            .HasValue<Individual>(CustomerTypeEnum.Individual);

        // Discriminator on CustomerType to differentiate CompanyDiscountPolicies from IndividualDiscountPolicies
        modelBuilder.Entity<DiscountPolicyBase>()
            .HasDiscriminator<CustomerTypeEnum>("CustomerType")
            .HasValue<IndividualDiscountPolicy>(CustomerTypeEnum.Individual)
            .HasValue<CompanyDiscountPolicy>(CustomerTypeEnum.Company);

        // 1 to 1 relationship for Customer-BillingDetails
        modelBuilder.Entity<Customer>()
            .HasOne(r => r.BillingDetails)
            .WithOne()
            .HasForeignKey<CustomerDetails>("BillingDetailsId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        // 1 to 1 relationship for Customer-ShippingDetails
        modelBuilder.Entity<Customer>()
            .HasOne(r => r.ShippingDetails)
            .WithOne()
            .HasForeignKey<CustomerDetails>("ShippingDetailsId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        // * to * relationship with navigation Billing-Discount
        modelBuilder.Entity<Billing>()
            .HasMany(e => e.Discounts)
            .WithMany(e => e.Billings)
            .UsingEntity<BillingDiscount>(
                l => l.HasOne<Discount>().WithMany(e => e.BillingsDiscounts),
                r => r.HasOne<Billing>().WithMany(e => e.BillingsDiscounts));

        // Data seeding on DiscountPolicy
        modelBuilder.Entity<DiscountPolicyBase>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                CustomerType = CustomerTypeEnum.Individual,
                DiscountType = DiscountTypeEnum.Bulk,
                DiscountUnit = DiscountUnitEnum.Percentage,
                MaxValue = 30,
                CreatedBy = new Guid(),
                CreatedOn = DateTimeOffset.Now,
                IsDeleted = false,
                Name = "Individual.Bulk.Percentage"
            },
            new
            {
                Id = Guid.NewGuid(),
                CustomerType = CustomerTypeEnum.Individual,
                DiscountType = DiscountTypeEnum.Bulk,
                DiscountUnit = DiscountUnitEnum.Flat,
                MaxValue = 20,
                CreatedBy = new Guid(),
                CreatedOn = DateTimeOffset.Now,
                IsDeleted = false,
                Name = "Individual.Bulk.Flat"
            },
            new
            {
                Id = Guid.NewGuid(),
                CustomerType = CustomerTypeEnum.Company,
                DiscountType = DiscountTypeEnum.Bulk,
                DiscountUnit = DiscountUnitEnum.Percentage,
                MaxValue = 40,
                CreatedBy = new Guid(),
                CreatedOn = DateTimeOffset.Now,
                IsDeleted = false,
                Name = "Company.Bulk.Percentage"
            },
            new
            {
                Id = Guid.NewGuid(),
                CustomerType = CustomerTypeEnum.Company,
                DiscountType = DiscountTypeEnum.Bulk,
                DiscountUnit = DiscountUnitEnum.Flat,
                MaxValue = 200,
                CreatedBy = new Guid(),
                CreatedOn = DateTimeOffset.Now,
                IsDeleted = false,
                Name = "Company.Bulk.Flat"
            },
            new
            {
                Id = Guid.NewGuid(),
                CustomerType = CustomerTypeEnum.Company,
                DiscountType = DiscountTypeEnum.Targeted,
                DiscountUnit = DiscountUnitEnum.Percentage,
                MaxValue = 20,
                CreatedBy = new Guid(),
                CreatedOn = DateTimeOffset.Now,
                IsDeleted = false,
                Name = "Company.Targeted.Percentage"
            },
            new
            {
                Id = Guid.NewGuid(),
                CustomerType = CustomerTypeEnum.Company,
                DiscountType = DiscountTypeEnum.Targeted,
                DiscountUnit = DiscountUnitEnum.Flat,
                MaxValue = 100,
                CreatedBy = new Guid(),
                CreatedOn = DateTimeOffset.Now,
                IsDeleted = false,
                Name = "Company.Targeted.Flat"
            }
        );
    }
    
    private static void DataProtectionKeyMapping(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataProtectionKey>()
            .ToTable("myapp_protection_keys", "public")
            ;

        modelBuilder.Entity<DataProtectionKey>()
            .Property(x => x.Id)
            .HasColumnName("id")
            ;

        modelBuilder.Entity<DataProtectionKey>()
            .Property(x => x.FriendlyName)
            .HasColumnName("friendly_name")
            ;

        modelBuilder.Entity<DataProtectionKey>()
            .Property(x => x.Xml)
            .HasColumnName("xml")
            ;
    }

}