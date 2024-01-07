using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterColumnValueOnDiscountNonNegativeValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<long>(
                name: "Value",
                table: "Discounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "DiscountPolicies",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerType", "DiscountType", "DiscountUnit", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "MaxValue", "Name" },
                values: new object[,]
                {
                    { new Guid("721401f9-7330-4947-9ea1-e7bfe10eff2a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 14, 40, 12, 906, DateTimeKind.Unspecified).AddTicks(1867), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 2, false, null, null, 40, "Company.Bulk.Percentage" },
                    { new Guid("7b46edb7-83e4-48d3-8ebe-8f4c0c0c9e1f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 14, 40, 12, 906, DateTimeKind.Unspecified).AddTicks(1864), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 1, false, null, null, 20, "Individual.Bulk.Flat" },
                    { new Guid("8b64278e-b67f-43c9-9787-7ace52333c79"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 14, 40, 12, 906, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 1, false, null, null, 100, "Company.Targeted.Flat" },
                    { new Guid("92860606-79bf-47f3-a0de-f8cee69c7c16"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 14, 40, 12, 906, DateTimeKind.Unspecified).AddTicks(1869), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 1, false, null, null, 200, "Company.Bulk.Flat" },
                    { new Guid("c2039db8-06d4-437a-b060-ebc1e5d63b7e"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 14, 40, 12, 906, DateTimeKind.Unspecified).AddTicks(1808), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 2, false, null, null, 30, "Individual.Bulk.Percentage" },
                    { new Guid("dc567ff4-d61e-4591-ab8c-65de067eda1d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 7, 14, 40, 12, 906, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 2, false, null, null, 20, "Company.Targeted.Percentage" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("721401f9-7330-4947-9ea1-e7bfe10eff2a"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("7b46edb7-83e4-48d3-8ebe-8f4c0c0c9e1f"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("8b64278e-b67f-43c9-9787-7ace52333c79"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("92860606-79bf-47f3-a0de-f8cee69c7c16"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("c2039db8-06d4-437a-b060-ebc1e5d63b7e"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("dc567ff4-d61e-4591-ab8c-65de067eda1d"));

            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Discounts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
        }
    }
}
