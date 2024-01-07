using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingPaymentHistoryAndUpdatingBilingRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Billings_BillingId",
                table: "BillingLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId",
                table: "BillingsDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_BillingsDiscounts_BillingId",
                table: "BillingsDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billings",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_BillingLines_BillingId",
                table: "BillingLines");

            migrationBuilder.AddColumn<Guid>(
                name: "BillingCustomerId",
                table: "BillingsDiscounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "BillingLines",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "BillingCustomerId",
                table: "BillingLines",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                columns: new[] { "Id", "CustomerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billings",
                table: "Billings",
                columns: new[] { "Id", "CustomerId" });

            migrationBuilder.CreateTable(
                name: "PaymentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BillingId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    PaidDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    BillingCustomerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentCustomerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistories", x => new { x.Id, x.BillingId, x.PaymentId });
                    table.ForeignKey(
                        name: "FK_PaymentHistories_Billings_BillingId_BillingCustomerId",
                        columns: x => new { x.BillingId, x.BillingCustomerId },
                        principalTable: "Billings",
                        principalColumns: new[] { "Id", "CustomerId" });
                    table.ForeignKey(
                        name: "FK_PaymentHistories_Payments_PaymentId_PaymentCustomerId",
                        columns: x => new { x.PaymentId, x.PaymentCustomerId },
                        principalTable: "Payments",
                        principalColumns: new[] { "Id", "CustomerId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingsDiscounts_BillingId_BillingCustomerId",
                table: "BillingsDiscounts",
                columns: new[] { "BillingId", "BillingCustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_BillingId_BillingCustomerId",
                table: "BillingLines",
                columns: new[] { "BillingId", "BillingCustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_BillingId_BillingCustomerId",
                table: "PaymentHistories",
                columns: new[] { "BillingId", "BillingCustomerId" });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_PaymentId_PaymentCustomerId",
                table: "PaymentHistories",
                columns: new[] { "PaymentId", "PaymentCustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Billings_BillingId_BillingCustomerId",
                table: "BillingLines",
                columns: new[] { "BillingId", "BillingCustomerId" },
                principalTable: "Billings",
                principalColumns: new[] { "Id", "CustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId_BillingCustomerId",
                table: "BillingsDiscounts",
                columns: new[] { "BillingId", "BillingCustomerId" },
                principalTable: "Billings",
                principalColumns: new[] { "Id", "CustomerId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingLines_Billings_BillingId_BillingCustomerId",
                table: "BillingLines");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId_BillingCustomerId",
                table: "BillingsDiscounts");

            migrationBuilder.DropTable(
                name: "PaymentHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_BillingsDiscounts_BillingId_BillingCustomerId",
                table: "BillingsDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billings",
                table: "Billings");

            migrationBuilder.DropIndex(
                name: "IX_BillingLines_BillingId_BillingCustomerId",
                table: "BillingLines");

            migrationBuilder.DropColumn(
                name: "BillingCustomerId",
                table: "BillingsDiscounts");

            migrationBuilder.DropColumn(
                name: "BillingCustomerId",
                table: "BillingLines");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "BillingLines",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billings",
                table: "Billings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BillingsDiscounts_BillingId",
                table: "BillingsDiscounts",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingLines_BillingId",
                table: "BillingLines",
                column: "BillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingLines_Billings_BillingId",
                table: "BillingLines",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillingsDiscounts_Billings_BillingId",
                table: "BillingsDiscounts",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
