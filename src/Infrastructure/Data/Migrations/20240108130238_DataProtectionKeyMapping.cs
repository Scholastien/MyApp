using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataProtectionKeyMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("030ad149-ada1-4365-9acb-7648c648a338"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("177f3aca-06ed-420d-8b2d-a017ba832cc0"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("1d3c88bb-0ce6-4224-a9b7-d3b12f092f10"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("516a94ba-222f-4ce1-8f7b-d7e5ae1c7b06"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("88437a47-68a9-4e4b-af37-ab7a0ea8ff5f"));

            migrationBuilder.DeleteData(
                table: "DiscountPolicies",
                keyColumn: "Id",
                keyValue: new Guid("cf437721-aa32-423a-806f-55a40e573345"));

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "myapp_protection_keys",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    friendly_name = table.Column<string>(type: "text", nullable: true),
                    xml = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myapp_protection_keys", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "myapp_protection_keys",
                schema: "public");

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

            migrationBuilder.InsertData(
                table: "DiscountPolicies",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerType", "DiscountType", "DiscountUnit", "IsDeleted", "LastModifiedBy", "LastModifiedOn", "MaxValue", "Name" },
                values: new object[,]
                {
                    { new Guid("030ad149-ada1-4365-9acb-7648c648a338"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 0, 40, 26, 741, DateTimeKind.Unspecified).AddTicks(173), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 2, false, null, null, 40, "Company.Bulk.Percentage" },
                    { new Guid("177f3aca-06ed-420d-8b2d-a017ba832cc0"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 0, 40, 26, 741, DateTimeKind.Unspecified).AddTicks(179), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 2, false, null, null, 20, "Company.Targeted.Percentage" },
                    { new Guid("1d3c88bb-0ce6-4224-a9b7-d3b12f092f10"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 0, 40, 26, 741, DateTimeKind.Unspecified).AddTicks(176), new TimeSpan(0, 1, 0, 0, 0)), 2, 1, 1, false, null, null, 200, "Company.Bulk.Flat" },
                    { new Guid("516a94ba-222f-4ce1-8f7b-d7e5ae1c7b06"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 0, 40, 26, 741, DateTimeKind.Unspecified).AddTicks(113), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 2, false, null, null, 30, "Individual.Bulk.Percentage" },
                    { new Guid("88437a47-68a9-4e4b-af37-ab7a0ea8ff5f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 0, 40, 26, 741, DateTimeKind.Unspecified).AddTicks(182), new TimeSpan(0, 1, 0, 0, 0)), 2, 2, 1, false, null, null, 100, "Company.Targeted.Flat" },
                    { new Guid("cf437721-aa32-423a-806f-55a40e573345"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2024, 1, 8, 0, 40, 26, 741, DateTimeKind.Unspecified).AddTicks(170), new TimeSpan(0, 1, 0, 0, 0)), 1, 1, 1, false, null, null, 20, "Individual.Bulk.Flat" }
                });
        }
    }
}
