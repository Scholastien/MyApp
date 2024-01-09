﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApp.Infrastructure.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyApp.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.DataProtection.EntityFrameworkCore.DataProtectionKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FriendlyName")
                        .HasColumnType("text")
                        .HasColumnName("friendly_name");

                    b.Property<string>("Xml")
                        .HasColumnType("text")
                        .HasColumnName("xml");

                    b.HasKey("Id");

                    b.ToTable("myapp_protection_keys", "public");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Billings.Billing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StateFlag")
                        .HasColumnType("integer");

                    b.HasKey("Id", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Billings.BillingLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillingCustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("BillingId", "BillingCustomerId");

                    b.ToTable("BillingLines");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.BillingsDiscounts.BillingDiscount", b =>
                {
                    b.Property<Guid>("DiscountId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillingCustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DiscountId", "BillingId");

                    b.HasIndex("BillingId", "BillingCustomerId");

                    b.ToTable("BillingsDiscounts");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BillingDetailsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerType")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<Guid?>("ShippingDetailsId")
                        .HasColumnType("uuid");

                    b.Property<int>("StatusEnum")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasDiscriminator<int>("CustomerType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Customers.CustomerDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BillingDetailsId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid?>("ShippingDetailsId")
                        .HasColumnType("uuid");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("BillingDetailsId")
                        .IsUnique();

                    b.HasIndex("ShippingDetailsId")
                        .IsUnique();

                    b.ToTable("CustomersDetails");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.DiscountPolicy.DiscountPolicyBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerType")
                        .HasColumnType("integer");

                    b.Property<int>("DiscountType")
                        .HasColumnType("integer");

                    b.Property<int>("DiscountUnit")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MaxValue")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerType");

                    b.ToTable("DiscountPolicies");

                    b.HasDiscriminator<int>("CustomerType");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = new Guid("eda4e17e-1d0d-4caa-893c-f7df099a5989"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5334), new TimeSpan(0, 1, 0, 0, 0)),
                            CustomerType = 1,
                            DiscountType = 1,
                            DiscountUnit = 2,
                            IsDeleted = false,
                            MaxValue = 30,
                            Name = "Individual.Bulk.Percentage"
                        },
                        new
                        {
                            Id = new Guid("887332b7-ee96-477b-8af7-7b80fef23c7b"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 1, 0, 0, 0)),
                            CustomerType = 1,
                            DiscountType = 1,
                            DiscountUnit = 1,
                            IsDeleted = false,
                            MaxValue = 20,
                            Name = "Individual.Bulk.Flat"
                        },
                        new
                        {
                            Id = new Guid("d0fdedb4-bed3-4215-a902-f6cfe62449f0"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 1, 0, 0, 0)),
                            CustomerType = 2,
                            DiscountType = 1,
                            DiscountUnit = 2,
                            IsDeleted = false,
                            MaxValue = 40,
                            Name = "Company.Bulk.Percentage"
                        },
                        new
                        {
                            Id = new Guid("d8410437-7835-444c-99b7-9769bd83eb2b"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 1, 0, 0, 0)),
                            CustomerType = 2,
                            DiscountType = 1,
                            DiscountUnit = 1,
                            IsDeleted = false,
                            MaxValue = 200,
                            Name = "Company.Bulk.Flat"
                        },
                        new
                        {
                            Id = new Guid("e6ff75f6-7353-4277-8580-ce28d06e29c7"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5400), new TimeSpan(0, 1, 0, 0, 0)),
                            CustomerType = 2,
                            DiscountType = 2,
                            DiscountUnit = 2,
                            IsDeleted = false,
                            MaxValue = 20,
                            Name = "Company.Targeted.Percentage"
                        },
                        new
                        {
                            Id = new Guid("e4815d0a-0ca5-49ed-8578-64eacaa8952c"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedOn = new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 1, 0, 0, 0)),
                            CustomerType = 2,
                            DiscountType = 2,
                            DiscountUnit = 1,
                            IsDeleted = false,
                            MaxValue = 100,
                            Name = "Company.Targeted.Flat"
                        });
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Discounts.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DiscountPolicyId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DiscountPolicyId");

                    b.HasIndex("Value");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.IdentityUserBase", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MyApp.Domain.Entities.PaymentHistories.PaymentHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BillingId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BillingCustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("PaidDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("PaymentCustomerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id", "BillingId", "PaymentId");

                    b.HasIndex("BillingId", "BillingCustomerId");

                    b.HasIndex("PaymentId", "PaymentCustomerId");

                    b.ToTable("PaymentHistories");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Payments.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.HasKey("Id", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LastModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("LastModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Customers.Company", b =>
                {
                    b.HasBaseType("MyApp.Domain.Entities.Customers.Customer");

                    b.Property<int>("CompanySize")
                        .HasColumnType("integer");

                    b.Property<string>("Kbis")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Customers.Individual", b =>
                {
                    b.HasBaseType("MyApp.Domain.Entities.Customers.Customer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("MyApp.Domain.Entities.DiscountPolicy.Companies.CompanyDiscountPolicy", b =>
                {
                    b.HasBaseType("MyApp.Domain.Entities.DiscountPolicy.DiscountPolicyBase");

                    b.Property<int>("CompanySize")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("MyApp.Domain.Entities.DiscountPolicy.Individuals.IndividualDiscountPolicy", b =>
                {
                    b.HasBaseType("MyApp.Domain.Entities.DiscountPolicy.DiscountPolicyBase");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.IdentityUserBase", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.IdentityUserBase", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyApp.Domain.Entities.IdentityUserBase", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.IdentityUserBase", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Billings.Billing", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany("Billings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Billings.BillingLine", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.Products.Product", "Product")
                        .WithMany("BillingLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyApp.Domain.Entities.Billings.Billing", "Billing")
                        .WithMany("BillingLines")
                        .HasForeignKey("BillingId", "BillingCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Billing");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.BillingsDiscounts.BillingDiscount", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.Discounts.Discount", null)
                        .WithMany("BillingsDiscounts")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyApp.Domain.Entities.Billings.Billing", null)
                        .WithMany("BillingsDiscounts")
                        .HasForeignKey("BillingId", "BillingCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Customers.CustomerDetails", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.Customers.Customer", null)
                        .WithOne("BillingDetails")
                        .HasForeignKey("MyApp.Domain.Entities.Customers.CustomerDetails", "BillingDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyApp.Domain.Entities.Customers.Customer", null)
                        .WithOne("ShippingDetails")
                        .HasForeignKey("MyApp.Domain.Entities.Customers.CustomerDetails", "ShippingDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Discounts.Discount", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.DiscountPolicy.DiscountPolicyBase", "DiscountPolicy")
                        .WithMany("Discounts")
                        .HasForeignKey("DiscountPolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiscountPolicy");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.PaymentHistories.PaymentHistory", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.Billings.Billing", null)
                        .WithMany("PaymentHistories")
                        .HasForeignKey("BillingId", "BillingCustomerId");

                    b.HasOne("MyApp.Domain.Entities.Payments.Payment", null)
                        .WithMany("PaymentHistories")
                        .HasForeignKey("PaymentId", "PaymentCustomerId");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Payments.Payment", b =>
                {
                    b.HasOne("MyApp.Domain.Entities.Customers.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Billings.Billing", b =>
                {
                    b.Navigation("BillingLines");

                    b.Navigation("BillingsDiscounts");

                    b.Navigation("PaymentHistories");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Customers.Customer", b =>
                {
                    b.Navigation("BillingDetails")
                        .IsRequired();

                    b.Navigation("Billings");

                    b.Navigation("Payments");

                    b.Navigation("ShippingDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("MyApp.Domain.Entities.DiscountPolicy.DiscountPolicyBase", b =>
                {
                    b.Navigation("Discounts");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Discounts.Discount", b =>
                {
                    b.Navigation("BillingsDiscounts");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Payments.Payment", b =>
                {
                    b.Navigation("PaymentHistories");
                });

            modelBuilder.Entity("MyApp.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("BillingLines");
                });
#pragma warning restore 612, 618
        }
    }
}
