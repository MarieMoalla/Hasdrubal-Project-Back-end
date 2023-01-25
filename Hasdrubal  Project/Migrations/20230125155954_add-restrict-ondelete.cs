using Microsoft.EntityFrameworkCore.Migrations;

namespace Hasdrubal__Project.Migrations
{
    public partial class addrestrictondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisations_Oeuvres_Id",
                table: "Acquisations");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliographies_Oeuvres_Id",
                table: "Bibliographies");

            migrationBuilder.DropForeignKey(
                name: "FK_ConservationLocations_Oeuvres_Id",
                table: "ConservationLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Oeuvres_OeuvreId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Oeuvres_Artistes_ArtisteId",
                table: "Oeuvres");

            migrationBuilder.DropForeignKey(
                name: "FK_Prets_Expositions_ExpositionId",
                table: "Prets");

            migrationBuilder.DropForeignKey(
                name: "FK_Prets_Oeuvres_OeuvreId",
                table: "Prets");

            migrationBuilder.DropForeignKey(
                name: "FK_Redactions_Oeuvres_Id",
                table: "Redactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurations_Oeuvres_Id",
                table: "Restaurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Oeuvres_Id",
                table: "Signatures");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisations_Oeuvres_Id",
                table: "Acquisations",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliographies_Oeuvres_Id",
                table: "Bibliographies",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConservationLocations_Oeuvres_Id",
                table: "ConservationLocations",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Oeuvres_OeuvreId",
                table: "Images",
                column: "OeuvreId",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Oeuvres_Artistes_ArtisteId",
                table: "Oeuvres",
                column: "ArtisteId",
                principalTable: "Artistes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prets_Expositions_ExpositionId",
                table: "Prets",
                column: "ExpositionId",
                principalTable: "Expositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prets_Oeuvres_OeuvreId",
                table: "Prets",
                column: "OeuvreId",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Redactions_Oeuvres_Id",
                table: "Redactions",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurations_Oeuvres_Id",
                table: "Restaurations",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Oeuvres_Id",
                table: "Signatures",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acquisations_Oeuvres_Id",
                table: "Acquisations");

            migrationBuilder.DropForeignKey(
                name: "FK_Bibliographies_Oeuvres_Id",
                table: "Bibliographies");

            migrationBuilder.DropForeignKey(
                name: "FK_ConservationLocations_Oeuvres_Id",
                table: "ConservationLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Oeuvres_OeuvreId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Oeuvres_Artistes_ArtisteId",
                table: "Oeuvres");

            migrationBuilder.DropForeignKey(
                name: "FK_Prets_Expositions_ExpositionId",
                table: "Prets");

            migrationBuilder.DropForeignKey(
                name: "FK_Prets_Oeuvres_OeuvreId",
                table: "Prets");

            migrationBuilder.DropForeignKey(
                name: "FK_Redactions_Oeuvres_Id",
                table: "Redactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurations_Oeuvres_Id",
                table: "Restaurations");

            migrationBuilder.DropForeignKey(
                name: "FK_Signatures_Oeuvres_Id",
                table: "Signatures");

            migrationBuilder.AddForeignKey(
                name: "FK_Acquisations_Oeuvres_Id",
                table: "Acquisations",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bibliographies_Oeuvres_Id",
                table: "Bibliographies",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConservationLocations_Oeuvres_Id",
                table: "ConservationLocations",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Oeuvres_OeuvreId",
                table: "Images",
                column: "OeuvreId",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Oeuvres_Artistes_ArtisteId",
                table: "Oeuvres",
                column: "ArtisteId",
                principalTable: "Artistes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prets_Expositions_ExpositionId",
                table: "Prets",
                column: "ExpositionId",
                principalTable: "Expositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prets_Oeuvres_OeuvreId",
                table: "Prets",
                column: "OeuvreId",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Redactions_Oeuvres_Id",
                table: "Redactions",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurations_Oeuvres_Id",
                table: "Restaurations",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Signatures_Oeuvres_Id",
                table: "Signatures",
                column: "Id",
                principalTable: "Oeuvres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
