using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBillingPerimeter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountPolicies_Billing_BillingId",
                table: "DiscountPolicies");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Billing_BillingId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_BillingId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billing",
                table: "Billing");

            migrationBuilder.RenameTable(
                name: "Billing",
                newName: "Billings");

            migrationBuilder.RenameColumn(
                name: "BillingId",
                table: "Payments",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Billings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedOn",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifiedBy",
                table: "Billings",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedOn",
                table: "Billings",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "Billings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billings",
                table: "Billings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BillingId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingLines_Billings_BillingId",
                        column: x => x.BillingId,
                        principalTable: "Billings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillingLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_PaymentId",
                table: "Billings",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_BillingId",
                table: "BillingLines",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_ProductId",
                table: "BillingLines",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_Payments_PaymentId",
                table: "Billings",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountPolicies_Billings_BillingId",
                table: "DiscountPolicies",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_Payments_PaymentId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountPolicies_Billings_BillingId",
                table: "DiscountPolicies");

            migrationBuilder.DropTable(
                name: "BillingLines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billings",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_Billings_PaymentId",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Billings");

            migrationBuilder.RenameTable(
                name: "Billings",
                newName: "Billing");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Payments",
                newName: "BillingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                columns: new[] { "CustomerId", "BillingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billing",
                table: "Billing",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BillingId",
                table: "Payments",
                column: "BillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountPolicies_Billing_BillingId",
                table: "DiscountPolicies",
                column: "BillingId",
                principalTable: "Billing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Billing_BillingId",
                table: "Payments",
                column: "BillingId",
                principalTable: "Billing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
