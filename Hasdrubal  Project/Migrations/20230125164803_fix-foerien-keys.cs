using Microsoft.EntityFrameworkCore.Migrations;

namespace Hasdrubal__Project.Migrations
{
    public partial class fixfoerienkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OeuvreId",
                table: "Signatures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OeuvreId",
                table: "Restaurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OeuvreId",
                table: "Redactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AcquisationId",
                table: "Oeuvres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BibliographieId",
                table: "Oeuvres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConservationLocationId",
                table: "Oeuvres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RedactionId",
                table: "Oeuvres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurationId",
                table: "Oeuvres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SignatureId",
                table: "Oeuvres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OeuvreId",
                table: "ConservationLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OeuvreId",
                table: "Bibliographies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OeuvreId",
                table: "Acquisations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OeuvreId",
                table: "Signatures");

            migrationBuilder.DropColumn(
                name: "OeuvreId",
                table: "Restaurations");

            migrationBuilder.DropColumn(
                name: "OeuvreId",
                table: "Redactions");

            migrationBuilder.DropColumn(
                name: "AcquisationId",
                table: "Oeuvres");

            migrationBuilder.DropColumn(
                name: "BibliographieId",
                table: "Oeuvres");

            migrationBuilder.DropColumn(
                name: "ConservationLocationId",
                table: "Oeuvres");

            migrationBuilder.DropColumn(
                name: "RedactionId",
                table: "Oeuvres");

            migrationBuilder.DropColumn(
                name: "RestaurationId",
                table: "Oeuvres");

            migrationBuilder.DropColumn(
                name: "SignatureId",
                table: "Oeuvres");

            migrationBuilder.DropColumn(
                name: "OeuvreId",
                table: "ConservationLocations");

            migrationBuilder.DropColumn(
                name: "OeuvreId",
                table: "Bibliographies");

            migrationBuilder.DropColumn(
                name: "OeuvreId",
                table: "Acquisations");
        }
    }
}
