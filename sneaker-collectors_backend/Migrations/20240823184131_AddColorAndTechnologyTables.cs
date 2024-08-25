using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sneaker_collectors_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddColorAndTechnologyTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "SneakersColors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SneakersColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SneakerTechnologies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SneakerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technology = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SneakerTechnologies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "brand_founders");

            migrationBuilder.DropTable(
                name: "news_hashtags");

            migrationBuilder.DropTable(
                name: "news_photo");

            migrationBuilder.DropTable(
                name: "sneaker_materials");

            migrationBuilder.DropTable(
                name: "sneaker_purpose");

            migrationBuilder.DropTable(
                name: "sneaker_samples_photos");

            migrationBuilder.DropTable(
                name: "sneakers_state");

            migrationBuilder.DropTable(
                name: "SneakersColors");

            migrationBuilder.DropTable(
                name: "SneakerTechnologies");

            migrationBuilder.DropTable(
                name: "user_sneakers_photos");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropTable(
                name: "sneaker_samples");

            migrationBuilder.DropTable(
                name: "user_sneakers");

            migrationBuilder.DropTable(
                name: "brands");
        }
    }
}
