using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uye",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uye", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Yayinevi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yayinevi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Yazar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kitap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YayinTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SayfaSayisi = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    YayineviId = table.Column<int>(type: "int", nullable: false),
                    YazarId = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kitap_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitap_Yayinevi_YayineviId",
                        column: x => x.YayineviId,
                        principalTable: "Yayinevi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitap_Yazar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapKopya",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KopyaNo = table.Column<int>(type: "int", nullable: false),
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapKopya", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KitapKopya_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emanet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmanetTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimTarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SonTeslimTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KitapKopyaId = table.Column<int>(type: "int", nullable: false),
                    UyeId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emanet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Emanet_KitapKopya_KitapKopyaId",
                        column: x => x.KitapKopyaId,
                        principalTable: "KitapKopya",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emanet_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emanet_Uye_UyeId",
                        column: x => x.UyeId,
                        principalTable: "Uye",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emanet_KitapKopyaId",
                table: "Emanet",
                column: "KitapKopyaId");

            migrationBuilder.CreateIndex(
                name: "IX_Emanet_PersonelId",
                table: "Emanet",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Emanet_UyeId",
                table: "Emanet",
                column: "UyeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_KategoriId",
                table: "Kitap",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_YayineviId",
                table: "Kitap",
                column: "YayineviId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_YazarId",
                table: "Kitap",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKopya_KitapId",
                table: "KitapKopya",
                column: "KitapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emanet");

            migrationBuilder.DropTable(
                name: "KitapKopya");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Uye");

            migrationBuilder.DropTable(
                name: "Kitap");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Yayinevi");

            migrationBuilder.DropTable(
                name: "Yazar");
        }
    }
}
