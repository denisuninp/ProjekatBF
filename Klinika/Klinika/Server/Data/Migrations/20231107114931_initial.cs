using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Klinika.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odeljenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odeljenja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doktori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdeljenjeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doktori_Odeljenja_OdeljenjeId",
                        column: x => x.OdeljenjeId,
                        principalTable: "Odeljenja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregledi_Doktori_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregledi_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Odeljenja",
                columns: new[] { "Id", "Naziv", "Url" },
                values: new object[,]
                {
                    { 1, "Kardiologija", "Kardiologija" },
                    { 2, "Stomatolog", "Stomatolog" }
                });

            migrationBuilder.InsertData(
                table: "Pacijenti",
                columns: new[] { "Id", "Ime", "Prezime" },
                values: new object[,]
                {
                    { 1, "Denis", "Fijuljanin" },
                    { 2, "Merisa", "Curic" }
                });

            migrationBuilder.InsertData(
                table: "Doktori",
                columns: new[] { "Id", "BrojTelefona", "Ime", "OdeljenjeId", "Prezime" },
                values: new object[,]
                {
                    { 1, "066654825", "Bojana", 1, "Maksimovic" },
                    { 2, "063224433", "Nenad", 2, "Stojakovic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktori_OdeljenjeId",
                table: "Doktori",
                column: "OdeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_DoktorId",
                table: "Pregledi",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_PacijentId",
                table: "Pregledi",
                column: "PacijentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "Doktori");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Odeljenja");
        }
    }
}
