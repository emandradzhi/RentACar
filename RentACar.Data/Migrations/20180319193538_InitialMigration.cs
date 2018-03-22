using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RentACar.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsTheCarAvailable = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    PlaceId = table.Column<int>(nullable: true),
                    RentFrom = table.Column<DateTime>(nullable: false),
                    RentTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    PlaceId = table.Column<int>(nullable: true),
                    TypeOfUser = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
