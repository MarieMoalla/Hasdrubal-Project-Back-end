using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hasdrubal__Project.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LieuNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationalite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biographie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contraintes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitreExpo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oeuvres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomArtiste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresnomArtiste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreation = table.Column<int>(type: "int", nullable: false),
                    Materiaux = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Support = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions2D = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions3D = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poid = table.Column<int>(type: "int", nullable: false),
                    NbElements = table.Column<int>(type: "int", nullable: false),
                    NumeroTitrage = table.Column<int>(type: "int", nullable: false),
                    TypeTitrage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtisteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oeuvres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oeuvres_Artistes_ArtisteId",
                        column: x => x.ArtisteId,
                        principalTable: "Artistes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acquisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PropriétaireActuel = table.Column<int>(type: "int", nullable: false),
                    DateAcq = table.Column<int>(type: "int", nullable: false),
                    LieuAcq = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<int>(type: "int", nullable: false),
                    MoyenAcq = table.Column<int>(type: "int", nullable: false),
                    PreuveAchat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificatAuthentication = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acquisations_Oeuvres_Id",
                        column: x => x.Id,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bibliographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Publications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitreOuvrage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomAuteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Page = table.Column<int>(type: "int", nullable: false),
                    Editeur = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bibliographies_Oeuvres_Id",
                        column: x => x.Id,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConservationLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceDepot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModeStockage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConservationLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConservationLocations_Oeuvres_Id",
                        column: x => x.Id,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Copyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DroitsPhotographiques = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OeuvreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Oeuvres_OeuvreId",
                        column: x => x.OeuvreId,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomExpo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDepart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OeuvreId = table.Column<int>(type: "int", nullable: false),
                    ExpositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prets_Expositions_ExpositionId",
                        column: x => x.ExpositionId,
                        principalTable: "Expositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prets_Oeuvres_OeuvreId",
                        column: x => x.OeuvreId,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Redactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomRedacteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRedaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Redactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Redactions_Oeuvres_Id",
                        column: x => x.Id,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Constat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRestauration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LieuRestauration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomRestauration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIntervention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Materiaux = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurations_Oeuvres_Id",
                        column: x => x.Id,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OeuvreLocalisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Signatures_Oeuvres_Id",
                        column: x => x.Id,
                        principalTable: "Oeuvres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_OeuvreId",
                table: "Images",
                column: "OeuvreId");

            migrationBuilder.CreateIndex(
                name: "IX_Oeuvres_ArtisteId",
                table: "Oeuvres",
                column: "ArtisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prets_ExpositionId",
                table: "Prets",
                column: "ExpositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prets_OeuvreId",
                table: "Prets",
                column: "OeuvreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acquisations");

            migrationBuilder.DropTable(
                name: "Bibliographies");

            migrationBuilder.DropTable(
                name: "ConservationLocations");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Prets");

            migrationBuilder.DropTable(
                name: "Redactions");

            migrationBuilder.DropTable(
                name: "Restaurations");

            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "Expositions");

            migrationBuilder.DropTable(
                name: "Oeuvres");

            migrationBuilder.DropTable(
                name: "Artistes");
        }
    }
}
