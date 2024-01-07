using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexOnValueOnTableDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("1103a614-93c9-4ed9-9a3a-364caa433e14"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("2610a75b-56e0-4000-96ba-37332c720a82"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("4ca99318-4990-4beb-b7b4-231215a3cfd1"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("8de911b3-5c38-4428-8d9e-c3d145ffbc5f"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("988fabc4-c55b-4a9e-99d0-c7ff4c076b08"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cd94b3ec-91b2-4e08-b429-de4b5483e6b3"));

            migrationBuilder.InsertData(
                table: "DiscountPolicies",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerType", "DiscountType", "DiscountUnit", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "MaxValue", "Name" },
                values: new object[,]
                {
                    { new Guid("185211e4-f455-410d-8448-60c9e89f2d13"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 13, 59, 58, 68, DateTimeKind.Unspecified).AddTicks(138), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 1, false, null, null, 20, "Individual.Bulk.Flat" },
                    { new Guid("1a468e8f-bda6-4d1e-8d8c-d895f9718963"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 13, 59, 58, 68, DateTimeKind.Unspecified).AddTicks(141), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 2, false, null, null, 40, "Company.Bulk.Percentage" },
                    { new Guid("274ddbb5-0657-4329-b175-0eb6fcb0f537"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 13, 59, 58, 68, DateTimeKind.Unspecified).AddTicks(70), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 2, false, null, null, 30, "Individual.Bulk.Percentage" },
                    { new Guid("2cf4a5c4-0a4f-4e32-83d3-d698ad30d174"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 13, 59, 58, 68, DateTimeKind.Unspecified).AddTicks(180), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 1, false, null, null, 100, "Company.Targeted.Flat" },
                    { new Guid("d1a892fc-5060-45c0-a4d5-65af3988ceb0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 13, 59, 58, 68, DateTimeKind.Unspecified).AddTicks(178), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 2, false, null, null, 20, "Company.Targeted.Percentage" },
                    { new Guid("d54ac313-b2c3-4bf0-a12f-128e55bda008"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 13, 59, 58, 68, DateTimeKind.Unspecified).AddTicks(144), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 1, false, null, null, 200, "Company.Bulk.Flat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_Value",
                table: "Discounts",
                column: "Value");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Discounts_Value",
                table: "Discounts");

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("185211e4-f455-410d-8448-60c9e89f2d13"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("1a468e8f-bda6-4d1e-8d8c-d895f9718963"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("274ddbb5-0657-4329-b175-0eb6fcb0f537"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("2cf4a5c4-0a4f-4e32-83d3-d698ad30d174"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("d1a892fc-5060-45c0-a4d5-65af3988ceb0"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("d54ac313-b2c3-4bf0-a12f-128e55bda008"));

            migrationBuilder.InsertData(
                table: "DiscountPolicies",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerType", "DiscountType", "DiscountUnit", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "MaxValue", "Name" },
                values: new object[,]
                {
                    { new Guid("1103a614-93c9-4ed9-9a3a-364caa433e14"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 2, 17, 22, 714, DateTimeKind.Unspecified).AddTicks(519), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 2, false, null, null, 40, "Company.Bulk.Percentage" },
                    { new Guid("2610a75b-56e0-4000-96ba-37332c720a82"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 2, 17, 22, 714, DateTimeKind.Unspecified).AddTicks(600), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 2, false, null, null, 20, "Company.Targeted.Percentage" },
                    { new Guid("4ca99318-4990-4beb-b7b4-231215a3cfd1"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 2, 17, 22, 714, DateTimeKind.Unspecified).AddTicks(603), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 1, false, null, null, 100, "Company.Targeted.Flat" },
                    { new Guid("8de911b3-5c38-4428-8d9e-c3d145ffbc5f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 2, 17, 22, 714, DateTimeKind.Unspecified).AddTicks(448), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 2, false, null, null, 30, "Individual.Bulk.Percentage" },
                    { new Guid("988fabc4-c55b-4a9e-99d0-c7ff4c076b08"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 2, 17, 22, 714, DateTimeKind.Unspecified).AddTicks(502), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 1, false, null, null, 20, "Individual.Bulk.Flat" },
                    { new Guid("cd94b3ec-91b2-4e08-b429-de4b5483e6b3"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 2, 17, 22, 714, DateTimeKind.Unspecified).AddTicks(523), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 1, false, null, null, 200, "Company.Bulk.Flat" }
                });
        }
    }
}
