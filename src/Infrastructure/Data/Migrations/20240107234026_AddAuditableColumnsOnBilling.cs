using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableColumnsOnBilling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId_BillingCustomerId",
                table: "BillingsDiscounts");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "BillingCustomerId",
                table: "BillingsDiscounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "BillingsDiscounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "BillingsDiscounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy",
                table: "BillingsDiscounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "BillingsDiscounts",
                type: "timestamp with time zone",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId_BillingCustomerId",
                table: "BillingsDiscounts",
                columns: new[] { "BillingId", "BillingCustomerId" },
                principalTable: "Billings",
                principalColumns: new[] { "Id", "CustomerId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId_BillingCustomerId",
                table: "BillingsDiscounts");

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

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BillingsDiscounts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BillingsDiscounts");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "BillingsDiscounts");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "BillingsDiscounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "BillingCustomerId",
                table: "BillingsDiscounts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId_BillingCustomerId",
                table: "BillingsDiscounts",
                columns: new[] { "BillingId", "BillingCustomerId" },
                principalTable: "Billings",
                principalColumns: new[] { "Id", "CustomerId" });
        }
    }
}
