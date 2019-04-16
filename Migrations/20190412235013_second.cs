using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginRegistration.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EvilGroups",
                columns: table => new
                {
                    EvilGroupId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvilGroups", x => x.EvilGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    VillainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plans_Villains_VillainId",
                        column: x => x.VillainId,
                        principalTable: "Villains",
                        principalColumn: "VillainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillainEvilGroups",
                columns: table => new
                {
                    VillainEvilGroupId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    VillainId = table.Column<int>(nullable: false),
                    EvilGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillainEvilGroups", x => x.VillainEvilGroupId);
                    table.ForeignKey(
                        name: "FK_VillainEvilGroups_EvilGroups_EvilGroupId",
                        column: x => x.EvilGroupId,
                        principalTable: "EvilGroups",
                        principalColumn: "EvilGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VillainEvilGroups_Villains_VillainId",
                        column: x => x.VillainId,
                        principalTable: "Villains",
                        principalColumn: "VillainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_VillainId",
                table: "Plans",
                column: "VillainId");

            migrationBuilder.CreateIndex(
                name: "IX_VillainEvilGroups_EvilGroupId",
                table: "VillainEvilGroups",
                column: "EvilGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VillainEvilGroups_VillainId",
                table: "VillainEvilGroups",
                column: "VillainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "VillainEvilGroups");

            migrationBuilder.DropTable(
                name: "EvilGroups");
        }
    }
}
