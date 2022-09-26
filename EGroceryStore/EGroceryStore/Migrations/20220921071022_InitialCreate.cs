using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EGroceryStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyModel",
                columns: table => new
                {
                    BuyerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingAddress = table.Column<string>(nullable: true),
                    PaymentMode = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyModel", x => x.BuyerId);
                });

            migrationBuilder.CreateTable(
                name: "GroceryModels",
                columns: table => new
                {
                    GroceryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryModels", x => x.GroceryId);
                });

            migrationBuilder.CreateTable(
                name: "LoginModels",
                columns: table => new
                {
                    EmailId = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModels", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VegetableModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    QuantityInKg = table.Column<long>(nullable: false),
                    CostPerKg = table.Column<long>(nullable: false),
                    HybridOrNatural = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VegetableModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartModels",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<float>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartModels", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_CartModels_UserModels_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatingModels",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingScalevalue = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    userModelUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingModels", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_RatingModels_UserModels_userModelUserId",
                        column: x => x.userModelUserId,
                        principalTable: "UserModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartModels_UserId",
                table: "CartModels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingModels_userModelUserId",
                table: "RatingModels",
                column: "userModelUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyModel");

            migrationBuilder.DropTable(
                name: "CartModels");

            migrationBuilder.DropTable(
                name: "GroceryModels");

            migrationBuilder.DropTable(
                name: "LoginModels");

            migrationBuilder.DropTable(
                name: "RatingModels");

            migrationBuilder.DropTable(
                name: "VegetableModels");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
