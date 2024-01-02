using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyRelationshipBillingDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountPolicies_Products_ProductId",
                table: "DiscountPolicies");

            migrationBuilder.DropIndex(
                name: "IX_DiscountPolicies_ProductId",
                table: "DiscountPolicies");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DiscountPolicies");

            migrationBuilder.RenameColumn(
                name: "EntrepriseId",
                table: "DiscountPolicies",
                newName: "CompanySize");

            migrationBuilder.AddColumn<int>(
                name: "CustomerType",
                table: "DiscountPolicies",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountPolicyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_DiscountPolicies_DiscountPolicyId",
                        column: x => x.DiscountPolicyId,
                        principalTable: "DiscountPolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillingsDiscounts",
                columns: table => new
                {
                    DiscountId = table.Column<Guid>(type: "uuid", nullable: false),
                    BillingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingsDiscounts", x => new { x.DiscountId, x.BillingId });
                    table.ForeignKey(
                        name: "FK_BillingsDiscounts_Billings_BillingId",
                        column: x => x.BillingId,
                        principalTable: "Billings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingsDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingsDiscounts_BillingId",
                table: "BillingsDiscounts",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_DiscountPolicyId",
                table: "Discounts",
                column: "DiscountPolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingsDiscounts");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "DiscountPolicies");

            migrationBuilder.RenameColumn(
                name: "CompanySize",
                table: "DiscountPolicies",
                newName: "EntrepriseId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "DiscountPolicies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DiscountPolicies_ProductId",
                table: "DiscountPolicies",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountPolicies_Products_ProductId",
                table: "DiscountPolicies",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
