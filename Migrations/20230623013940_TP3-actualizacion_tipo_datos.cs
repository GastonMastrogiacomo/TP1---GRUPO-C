using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP1___GRUPO_C.Migrations
{
    /// <inheritdoc />
    public partial class TP3actualizacion_tipo_datos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Usuarios",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Credito",
                table: "Usuarios",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Funciones",
                type: "decimal(38,17)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "DNI",
                value: 1111111L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 2,
                column: "DNI",
                value: 2222222L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 3,
                column: "DNI",
                value: 3333333L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 4,
                column: "DNI",
                value: 4444444L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 5,
                column: "DNI",
                value: 5555555L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 6,
                column: "DNI",
                value: 666666L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 7,
                column: "DNI",
                value: 77777777L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 8,
                column: "DNI",
                value: 88888888L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 9,
                column: "DNI",
                value: 999999L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 10,
                column: "DNI",
                value: 1000000L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 11,
                column: "DNI",
                value: 1112111L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 12,
                column: "DNI",
                value: 12321312L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 13,
                column: "DNI",
                value: 312312312L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 14,
                column: "DNI",
                value: 3123123L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 15,
                column: "DNI",
                value: 312312L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 16,
                column: "DNI",
                value: 2141241L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 17,
                column: "DNI",
                value: 321312L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 18,
                column: "DNI",
                value: 412123L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 19,
                column: "DNI",
                value: 421321L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 20,
                column: "DNI",
                value: 421412L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 21,
                column: "DNI",
                value: 412412L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Usuarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<decimal>(
                name: "Credito",
                table: "Usuarios",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Funciones",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,17)");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                column: "DNI",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 2,
                column: "DNI",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 3,
                column: "DNI",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 4,
                column: "DNI",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 5,
                column: "DNI",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 6,
                column: "DNI",
                value: 6L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 7,
                column: "DNI",
                value: 7L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 8,
                column: "DNI",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 9,
                column: "DNI",
                value: 9L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 10,
                column: "DNI",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 11,
                column: "DNI",
                value: 11L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 12,
                column: "DNI",
                value: 12L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 13,
                column: "DNI",
                value: 13L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 14,
                column: "DNI",
                value: 14L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 15,
                column: "DNI",
                value: 15L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 16,
                column: "DNI",
                value: 16L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 17,
                column: "DNI",
                value: 17L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 18,
                column: "DNI",
                value: 18L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 19,
                column: "DNI",
                value: 19L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 20,
                column: "DNI",
                value: 20L);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 21,
                column: "DNI",
                value: 21L);
        }
    }
}
