using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductInv.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    HSNCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Variants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubVariants_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubVariants_VariantId",
                table: "SubVariants",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubVariants");

            migrationBuilder.DropTable(
                name: "Variants");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
