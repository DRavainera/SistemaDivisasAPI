using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDivisasAPI.Migrations
{
    public partial class MiMigracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AliasCBU",
                table: "CuentaPeso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CBU",
                table: "CuentaPeso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AliasCBU",
                table: "CuentaDolar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CBU",
                table: "CuentaDolar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AliasCBU",
                table: "CuentaPeso");

            migrationBuilder.DropColumn(
                name: "CBU",
                table: "CuentaPeso");

            migrationBuilder.DropColumn(
                name: "AliasCBU",
                table: "CuentaDolar");

            migrationBuilder.DropColumn(
                name: "CBU",
                table: "CuentaDolar");
        }
    }
}
