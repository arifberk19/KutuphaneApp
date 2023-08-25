using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.DAL.Migrations
{
    public partial class Uyelik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EMail",
                table: "Uye",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Uye",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnSonRezerveEdenUyeId",
                table: "KitapKopya",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RezerveBitisTarihi",
                table: "KitapKopya",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KitapKopya_EnSonRezerveEdenUyeId",
                table: "KitapKopya",
                column: "EnSonRezerveEdenUyeId");

            migrationBuilder.AddForeignKey(
                name: "FK_KitapKopya_Uye_EnSonRezerveEdenUyeId",
                table: "KitapKopya",
                column: "EnSonRezerveEdenUyeId",
                principalTable: "Uye",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitapKopya_Uye_EnSonRezerveEdenUyeId",
                table: "KitapKopya");

            migrationBuilder.DropIndex(
                name: "IX_KitapKopya_EnSonRezerveEdenUyeId",
                table: "KitapKopya");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Uye");

            migrationBuilder.DropColumn(
                name: "EnSonRezerveEdenUyeId",
                table: "KitapKopya");

            migrationBuilder.DropColumn(
                name: "RezerveBitisTarihi",
                table: "KitapKopya");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Uye",
                newName: "EMail");
        }
    }
}
