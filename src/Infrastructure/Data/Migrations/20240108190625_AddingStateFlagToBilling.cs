using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingStateFlagToBilling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("2baa7800-ffeb-4318-8b1d-e1c3f1693c2a"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("4920f12a-9daa-425f-8517-97310c4980c7"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("60138b79-d7f6-45bc-a9fc-d6857d307e00"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("66ef26ae-fee6-4b12-8124-dda82b9128ed"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("a5cf6105-a793-4776-9899-b31abd985424"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("a8ce8539-0723-42c7-bc4d-5fa266efe2f6"));

            migrationBuilder.AddColumn<int>(
                name: "StateFlag",
                table: "Billings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DiscountPolicies",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerType", "DiscountType", "DiscountUnit", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "MaxValue", "Name" },
                values: new object[,]
                {
                    { new Guid("887332b7-ee96-477b-8af7-7b80fef23c7b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5392), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 1, false, null, null, 20, "Individual.Bulk.Flat" },
                    { new Guid("d0fdedb4-bed3-4215-a902-f6cfe62449f0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 2, false, null, null, 40, "Company.Bulk.Percentage" },
                    { new Guid("d8410437-7835-444c-99b7-9769bd83eb2b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5398), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 1, false, null, null, 200, "Company.Bulk.Flat" },
                    { new Guid("e4815d0a-0ca5-49ed-8578-64eacaa8952c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5402), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 1, false, null, null, 100, "Company.Targeted.Flat" },
                    { new Guid("e6ff75f6-7353-4277-8580-ce28d06e29c7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5400), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 2, false, null, null, 20, "Company.Targeted.Percentage" },
                    { new Guid("eda4e17e-1d0d-4caa-893c-f7df099a5989"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 20, 6, 25, 592, DateTimeKind.Unspecified).AddTicks(5334), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 2, false, null, null, 30, "Individual.Bulk.Percentage" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("887332b7-ee96-477b-8af7-7b80fef23c7b"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("d0fdedb4-bed3-4215-a902-f6cfe62449f0"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("d8410437-7835-444c-99b7-9769bd83eb2b"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("e4815d0a-0ca5-49ed-8578-64eacaa8952c"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("e6ff75f6-7353-4277-8580-ce28d06e29c7"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("eda4e17e-1d0d-4caa-893c-f7df099a5989"));

            migrationBuilder.DropColumn(
                name: "StateFlag",
                table: "Billings");

            migrationBuilder.InsertData(
                table: "DiscountPolicies",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerType", "DiscountType", "DiscountUnit", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "MaxValue", "Name" },
                values: new object[,]
                {
                    { new Guid("2baa7800-ffeb-4318-8b1d-e1c3f1693c2a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 14, 2, 38, 33, DateTimeKind.Unspecified).AddTicks(789), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 2, false, null, null, 30, "Individual.Bulk.Percentage" },
                    { new Guid("4920f12a-9daa-425f-8517-97310c4980c7"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 14, 2, 38, 33, DateTimeKind.Unspecified).AddTicks(842), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 2, false, null, null, 40, "Company.Bulk.Percentage" },
                    { new Guid("60138b79-d7f6-45bc-a9fc-d6857d307e00"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 14, 2, 38, 33, DateTimeKind.Unspecified).AddTicks(849), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 1, false, null, null, 100, "Company.Targeted.Flat" },
                    { new Guid("66ef26ae-fee6-4b12-8124-dda82b9128ed"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 14, 2, 38, 33, DateTimeKind.Unspecified).AddTicks(844), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 1, false, null, null, 200, "Company.Bulk.Flat" },
                    { new Guid("a5cf6105-a793-4776-9899-b31abd985424"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 14, 2, 38, 33, DateTimeKind.Unspecified).AddTicks(847), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 2, false, null, null, 20, "Company.Targeted.Percentage" },
                    { new Guid("a8ce8539-0723-42c7-bc4d-5fa266efe2f6"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 14, 2, 38, 33, DateTimeKind.Unspecified).AddTicks(839), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 1, false, null, null, 20, "Individual.Bulk.Flat" }
                });
        }
    }
}
