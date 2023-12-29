using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixFkDiscountPolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountPolicies_Billings_BillingId",
                table: "DiscountPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountPolicies_Customers_CustomerId",
                table: "DiscountPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountPolicies",
                table: "DiscountPolicies");

            migrationBuilder.RenameColumn(
                name: "BillingId",
                table: "DiscountPolicies",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "DiscountPolicies",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountPolicies_BillingId",
                table: "DiscountPolicies",
                newName: "IX_DiscountPolicies_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountPolicies",
                table: "DiscountPolicies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountPolicies_Products_ProductId",
                table: "DiscountPolicies",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountPolicies_Products_ProductId",
                table: "DiscountPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscountPolicies",
                table: "DiscountPolicies");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "DiscountPolicies",
                newName: "BillingId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DiscountPolicies",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_DiscountPolicies_ProductId",
                table: "DiscountPolicies",
                newName: "IX_DiscountPolicies_BillingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscountPolicies",
                table: "DiscountPolicies",
                columns: new[] { "CustomerId", "BillingId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountPolicies_Billings_BillingId",
                table: "DiscountPolicies",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountPolicies_Customers_CustomerId",
                table: "DiscountPolicies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
