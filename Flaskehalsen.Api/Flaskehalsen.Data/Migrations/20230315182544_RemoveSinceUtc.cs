using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flaskehalsen.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSinceUtc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetTogetherPersonRel");

            migrationBuilder.DropColumn(
                name: "SinceUtc",
                table: "ClubPersonRels");

            migrationBuilder.CreateTable(
                name: "GetTogetherAttendance",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GetTogetherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTogetherAttendance", x => new { x.GetTogetherId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_GetTogetherAttendance_GetTogethers_GetTogetherId",
                        column: x => x.GetTogetherId,
                        principalTable: "GetTogethers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GetTogetherAttendance_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetTogetherAttendance_PersonId",
                table: "GetTogetherAttendance",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetTogetherAttendance");

            migrationBuilder.AddColumn<DateTime>(
                name: "SinceUtc",
                table: "ClubPersonRels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "GetTogetherPersonRel",
                columns: table => new
                {
                    GetTogetherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTogetherPersonRel", x => new { x.GetTogetherId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_GetTogetherPersonRel_GetTogethers_GetTogetherId",
                        column: x => x.GetTogetherId,
                        principalTable: "GetTogethers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GetTogetherPersonRel_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetTogetherPersonRel_PersonId",
                table: "GetTogetherPersonRel",
                column: "PersonId");
        }
    }
}
