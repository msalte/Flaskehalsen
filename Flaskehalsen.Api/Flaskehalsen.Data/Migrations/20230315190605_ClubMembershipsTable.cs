using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flaskehalsen.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClubMembershipsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubPersonRels_Clubs_ClubId",
                table: "ClubPersonRels");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubPersonRels_Persons_PersonId",
                table: "ClubPersonRels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubPersonRels",
                table: "ClubPersonRels");

            migrationBuilder.RenameTable(
                name: "ClubPersonRels",
                newName: "ClubMemberships");

            migrationBuilder.RenameIndex(
                name: "IX_ClubPersonRels_PersonId",
                table: "ClubMemberships",
                newName: "IX_ClubMemberships_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubMemberships",
                table: "ClubMemberships",
                columns: new[] { "ClubId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMemberships_Clubs_ClubId",
                table: "ClubMemberships",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubMemberships_Persons_PersonId",
                table: "ClubMemberships",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClubMemberships_Clubs_ClubId",
                table: "ClubMemberships");

            migrationBuilder.DropForeignKey(
                name: "FK_ClubMemberships_Persons_PersonId",
                table: "ClubMemberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClubMemberships",
                table: "ClubMemberships");

            migrationBuilder.RenameTable(
                name: "ClubMemberships",
                newName: "ClubPersonRels");

            migrationBuilder.RenameIndex(
                name: "IX_ClubMemberships_PersonId",
                table: "ClubPersonRels",
                newName: "IX_ClubPersonRels_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClubPersonRels",
                table: "ClubPersonRels",
                columns: new[] { "ClubId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPersonRels_Clubs_ClubId",
                table: "ClubPersonRels",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClubPersonRels_Persons_PersonId",
                table: "ClubPersonRels",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
