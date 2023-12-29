using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUuidOnEachRelevantEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BillingDetailsId",
                table: "Customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShippingDetailsId",
                table: "Customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomersDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BillingDetailsId = table.Column<Guid>(type: "uuid", nullable: true),
                    ShippingDetailsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomersDetails_Customers_BillingDetailsId",
                        column: x => x.BillingDetailsId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomersDetails_Customers_ShippingDetailsId",
                        column: x => x.ShippingDetailsId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomersDetails_BillingDetailsId",
                table: "CustomersDetails",
                column: "BillingDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersDetails_ShippingDetailsId",
                table: "CustomersDetails",
                column: "ShippingDetailsId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersDetails");

            migrationBuilder.DropColumn(
                name: "BillingDetailsId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShippingDetailsId",
                table: "Customers");
        }
    }
}
