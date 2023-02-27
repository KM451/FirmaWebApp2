using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Firma.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monterzy",
                columns: table => new
                {
                    IdMontera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monterzy", x => x.IdMontera);
                });

            migrationBuilder.CreateTable(
                name: "RodzajeTransportu",
                columns: table => new
                {
                    IdRodzajuTransportu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajeTransportu", x => x.IdRodzajuTransportu);
                });

            migrationBuilder.CreateTable(
                name: "SposobyDostawy",
                columns: table => new
                {
                    IdSposobuDostawy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SposobyDostawy", x => x.IdSposobuDostawy);
                });

            migrationBuilder.CreateTable(
                name: "SposobyPlatnosci",
                columns: table => new
                {
                    IdSposobuPlatnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SposobyPlatnosci", x => x.IdSposobuPlatnosci);
                });

            migrationBuilder.CreateTable(
                name: "TypyCen",
                columns: table => new
                {
                    IdTypuCeny = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyCen", x => x.IdTypuCeny);
                });

            migrationBuilder.CreateTable(
                name: "TypyProduktow",
                columns: table => new
                {
                    IdTypuProduktu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyProduktow", x => x.IdTypuProduktu);
                });

            migrationBuilder.CreateTable(
                name: "TypyTransakcji",
                columns: table => new
                {
                    IdTypuTransakcji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypyTransakcji", x => x.IdTypuTransakcji);
                });

            migrationBuilder.CreateTable(
                name: "Kontrahenci",
                columns: table => new
                {
                    IdKontrahenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Akronim = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Nip = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IdSposobuPlatnosci = table.Column<int>(type: "int", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontrahenci", x => x.IdKontrahenta);
                    table.ForeignKey(
                        name: "FK_Kontrahenci_SposobyPlatnosci_IdSposobuPlatnosci",
                        column: x => x.IdSposobuPlatnosci,
                        principalTable: "SposobyPlatnosci",
                        principalColumn: "IdSposobuPlatnosci",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresy",
                columns: table => new
                {
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Miejscowosc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NrDomu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NrLokalu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodPoczowy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Poczta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Siedziba = table.Column<bool>(type: "bit", nullable: false),
                    Glowny = table.Column<bool>(type: "bit", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false),
                    IdKontrahenta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresy", x => x.IdAdresu);
                    table.ForeignKey(
                        name: "FK_Adresy_Kontrahenci_IdKontrahenta",
                        column: x => x.IdKontrahenta,
                        principalTable: "Kontrahenci",
                        principalColumn: "IdKontrahenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    IdProduktu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DodatkowaNazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JednostkaMiary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SWWPKWiU = table.Column<string>(name: "SWW_PKWiU", type: "nvarchar(max)", nullable: true),
                    Producent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypu = table.Column<int>(type: "int", nullable: false),
                    FotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StawkaVatZakupu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StawkaVatSprzedazy = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OdwrotneObciazenie = table.Column<bool>(type: "bit", nullable: false),
                    PodzielonaPlatnosc = table.Column<bool>(type: "bit", nullable: false),
                    StawkaCla = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StwkaAkcyzy = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KodPcn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzasKompletacji = table.Column<int>(type: "int", nullable: true),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false),
                    IdDostawcy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.IdProduktu);
                    table.ForeignKey(
                        name: "FK_Produkty_Kontrahenci_IdDostawcy",
                        column: x => x.IdDostawcy,
                        principalTable: "Kontrahenci",
                        principalColumn: "IdKontrahenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkty_TypyProduktow_IdTypu",
                        column: x => x.IdTypu,
                        principalTable: "TypyProduktow",
                        principalColumn: "IdTypuProduktu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZleceniaZakupu",
                columns: table => new
                {
                    IdZleceniaZakupu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKontrahenta = table.Column<int>(type: "int", nullable: false),
                    IdTransakcji = table.Column<int>(type: "int", nullable: false),
                    IdSposobuDostawy = table.Column<int>(type: "int", nullable: false),
                    IdRodzajuTransportu = table.Column<int>(type: "int", nullable: false),
                    IdSposobuPlatnosci = table.Column<int>(type: "int", nullable: false),
                    NrOferty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyPotwierdzone = table.Column<bool>(type: "bit", nullable: false),
                    NrPotwierdzenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataWystawienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CzyAktywne = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZleceniaZakupu", x => x.IdZleceniaZakupu);
                    table.ForeignKey(
                        name: "FK_ZleceniaZakupu_Kontrahenci_IdKontrahenta",
                        column: x => x.IdKontrahenta,
                        principalTable: "Kontrahenci",
                        principalColumn: "IdKontrahenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZleceniaZakupu_RodzajeTransportu_IdRodzajuTransportu",
                        column: x => x.IdRodzajuTransportu,
                        principalTable: "RodzajeTransportu",
                        principalColumn: "IdRodzajuTransportu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZleceniaZakupu_SposobyDostawy_IdSposobuDostawy",
                        column: x => x.IdSposobuDostawy,
                        principalTable: "SposobyDostawy",
                        principalColumn: "IdSposobuDostawy",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZleceniaZakupu_SposobyPlatnosci_IdSposobuPlatnosci",
                        column: x => x.IdSposobuPlatnosci,
                        principalTable: "SposobyPlatnosci",
                        principalColumn: "IdSposobuPlatnosci",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ZleceniaZakupu_TypyTransakcji_IdTransakcji",
                        column: x => x.IdTransakcji,
                        principalTable: "TypyTransakcji",
                        principalColumn: "IdTypuTransakcji",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ceny",
                columns: table => new
                {
                    IdCeny = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduktu = table.Column<int>(type: "int", nullable: false),
                    IdTypuCeny = table.Column<int>(type: "int", nullable: false),
                    Wartosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Waluta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceny", x => x.IdCeny);
                    table.ForeignKey(
                        name: "FK_Ceny_Produkty_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkty",
                        principalColumn: "IdProduktu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ceny_TypyCen_IdTypuCeny",
                        column: x => x.IdTypuCeny,
                        principalTable: "TypyCen",
                        principalColumn: "IdTypuCeny",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZleceniaKompletacji",
                columns: table => new
                {
                    IdZleceniaKompletacji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKontrahenta = table.Column<int>(type: "int", nullable: false),
                    DataWystawienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OczekiwanaDataRealizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PotwierdzonaDataRealizacji = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdProduktu = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdMontera = table.Column<int>(type: "int", nullable: true),
                    Priorytet = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CzyAktywne = table.Column<bool>(type: "bit", nullable: false),
                    CzasZlecenia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZleceniaKompletacji", x => x.IdZleceniaKompletacji);
                    table.ForeignKey(
                        name: "FK_ZleceniaKompletacji_Kontrahenci_IdKontrahenta",
                        column: x => x.IdKontrahenta,
                        principalTable: "Kontrahenci",
                        principalColumn: "IdKontrahenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZleceniaKompletacji_Monterzy_IdMontera",
                        column: x => x.IdMontera,
                        principalTable: "Monterzy",
                        principalColumn: "IdMontera");
                    table.ForeignKey(
                        name: "FK_ZleceniaKompletacji_Produkty_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkty",
                        principalColumn: "IdProduktu",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PozycjeZleceniaZakupu",
                columns: table => new
                {
                    IdPozycjiZleceniaZakupu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZleceniaZakupu = table.Column<int>(type: "int", nullable: false),
                    IdProduktu = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rabat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataRealizacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjeZleceniaZakupu", x => x.IdPozycjiZleceniaZakupu);
                    table.ForeignKey(
                        name: "FK_PozycjeZleceniaZakupu_Produkty_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkty",
                        principalColumn: "IdProduktu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PozycjeZleceniaZakupu_ZleceniaZakupu_IdZleceniaZakupu",
                        column: x => x.IdZleceniaZakupu,
                        principalTable: "ZleceniaZakupu",
                        principalColumn: "IdZleceniaZakupu",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PrUboczneZleceniaKompletacji",
                columns: table => new
                {
                    IdPrUbocznego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZleceniaKompletacji = table.Column<int>(type: "int", nullable: false),
                    IdProduktu = table.Column<int>(type: "int", nullable: true),
                    Ilosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrUboczneZleceniaKompletacji", x => x.IdPrUbocznego);
                    table.ForeignKey(
                        name: "FK_PrUboczneZleceniaKompletacji_Produkty_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkty",
                        principalColumn: "IdProduktu");
                    table.ForeignKey(
                        name: "FK_PrUboczneZleceniaKompletacji_ZleceniaKompletacji_IdZleceniaKompletacji",
                        column: x => x.IdZleceniaKompletacji,
                        principalTable: "ZleceniaKompletacji",
                        principalColumn: "IdZleceniaKompletacji",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkładnikiZleceniaKompletacji",
                columns: table => new
                {
                    IdSkladnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdZleceniaKompletacji = table.Column<int>(type: "int", nullable: false),
                    IdProduktu = table.Column<int>(type: "int", nullable: true),
                    Ilosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CzyAktywny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkładnikiZleceniaKompletacji", x => x.IdSkladnika);
                    table.ForeignKey(
                        name: "FK_SkładnikiZleceniaKompletacji_Produkty_IdProduktu",
                        column: x => x.IdProduktu,
                        principalTable: "Produkty",
                        principalColumn: "IdProduktu");
                    table.ForeignKey(
                        name: "FK_SkładnikiZleceniaKompletacji_ZleceniaKompletacji_IdZleceniaKompletacji",
                        column: x => x.IdZleceniaKompletacji,
                        principalTable: "ZleceniaKompletacji",
                        principalColumn: "IdZleceniaKompletacji",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresy_IdKontrahenta",
                table: "Adresy",
                column: "IdKontrahenta");

            migrationBuilder.CreateIndex(
                name: "IX_Ceny_IdProduktu",
                table: "Ceny",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_Ceny_IdTypuCeny",
                table: "Ceny",
                column: "IdTypuCeny");

            migrationBuilder.CreateIndex(
                name: "IX_Kontrahenci_IdSposobuPlatnosci",
                table: "Kontrahenci",
                column: "IdSposobuPlatnosci");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZleceniaZakupu_IdProduktu",
                table: "PozycjeZleceniaZakupu",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeZleceniaZakupu_IdZleceniaZakupu",
                table: "PozycjeZleceniaZakupu",
                column: "IdZleceniaZakupu");

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdDostawcy",
                table: "Produkty",
                column: "IdDostawcy");

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdTypu",
                table: "Produkty",
                column: "IdTypu");

            migrationBuilder.CreateIndex(
                name: "IX_PrUboczneZleceniaKompletacji_IdProduktu",
                table: "PrUboczneZleceniaKompletacji",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_PrUboczneZleceniaKompletacji_IdZleceniaKompletacji",
                table: "PrUboczneZleceniaKompletacji",
                column: "IdZleceniaKompletacji");

            migrationBuilder.CreateIndex(
                name: "IX_SkładnikiZleceniaKompletacji_IdProduktu",
                table: "SkładnikiZleceniaKompletacji",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_SkładnikiZleceniaKompletacji_IdZleceniaKompletacji",
                table: "SkładnikiZleceniaKompletacji",
                column: "IdZleceniaKompletacji");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaKompletacji_IdKontrahenta",
                table: "ZleceniaKompletacji",
                column: "IdKontrahenta");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaKompletacji_IdMontera",
                table: "ZleceniaKompletacji",
                column: "IdMontera");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaKompletacji_IdProduktu",
                table: "ZleceniaKompletacji",
                column: "IdProduktu");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaZakupu_IdKontrahenta",
                table: "ZleceniaZakupu",
                column: "IdKontrahenta");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaZakupu_IdRodzajuTransportu",
                table: "ZleceniaZakupu",
                column: "IdRodzajuTransportu");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaZakupu_IdSposobuDostawy",
                table: "ZleceniaZakupu",
                column: "IdSposobuDostawy");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaZakupu_IdSposobuPlatnosci",
                table: "ZleceniaZakupu",
                column: "IdSposobuPlatnosci");

            migrationBuilder.CreateIndex(
                name: "IX_ZleceniaZakupu_IdTransakcji",
                table: "ZleceniaZakupu",
                column: "IdTransakcji");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresy");

            migrationBuilder.DropTable(
                name: "Ceny");

            migrationBuilder.DropTable(
                name: "PozycjeZleceniaZakupu");

            migrationBuilder.DropTable(
                name: "PrUboczneZleceniaKompletacji");

            migrationBuilder.DropTable(
                name: "SkładnikiZleceniaKompletacji");

            migrationBuilder.DropTable(
                name: "TypyCen");

            migrationBuilder.DropTable(
                name: "ZleceniaZakupu");

            migrationBuilder.DropTable(
                name: "ZleceniaKompletacji");

            migrationBuilder.DropTable(
                name: "RodzajeTransportu");

            migrationBuilder.DropTable(
                name: "SposobyDostawy");

            migrationBuilder.DropTable(
                name: "TypyTransakcji");

            migrationBuilder.DropTable(
                name: "Monterzy");

            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Kontrahenci");

            migrationBuilder.DropTable(
                name: "TypyProduktow");

            migrationBuilder.DropTable(
                name: "SposobyPlatnosci");
        }
    }
}
