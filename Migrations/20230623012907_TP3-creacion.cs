using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP1___GRUPO_C.Migrations
{
    /// <inheritdoc />
    public partial class TP3creacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: false),
                    Sinopsis = table.Column<string>(type: "varchar(255)", nullable: false),
                    Poster = table.Column<string>(type: "varchar(255)", nullable: false),
                    Duracion = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ubicacion = table.Column<string>(type: "varchar(50)", nullable: false),
                    Capacidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<long>(type: "bigint", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    Mail = table.Column<string>(type: "varchar(512)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    IntentosFallidos = table.Column<int>(type: "int", nullable: false),
                    Bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    Credito = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSala = table.Column<int>(type: "integer", nullable: false),
                    idPelicula = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    AsientosDisponibles = table.Column<int>(type: "integer", nullable: false),
                    CantidadClientes = table.Column<int>(type: "integer", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_idPelicula",
                        column: x => x.idPelicula,
                        principalTable: "Peliculas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_idSala",
                        column: x => x.idSala,
                        principalTable: "Salas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UF",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "integer", nullable: false),
                    idFuncion = table.Column<int>(type: "integer", nullable: false),
                    CantidadEntradasCompradas = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF", x => new { x.idUsuario, x.idFuncion });
                    table.ForeignKey(
                        name: "FK_UF_Funciones_idFuncion",
                        column: x => x.idFuncion,
                        principalTable: "Funciones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UF_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "ID", "Descripcion", "Duracion", "Nombre", "Poster", "Sinopsis" },
                values: new object[,]
                {
                    { 1, "Un juguete", 2, "Toy Story", "", "Uno" },
                    { 2, "Un juguete 2", 2, "Toy Story 2", "", "Dos" },
                    { 3, "Un juguete 3", 2, "Toy Story 3", "", "Tres" },
                    { 4, "Basta de la misma pelicula", 2, "Toy Story 4", "", "Cuatro" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "ID", "Capacidad", "Ubicacion" },
                values: new object[,]
                {
                    { 1, 100, "Olivos" },
                    { 2, 200, "San Isidro" },
                    { 3, 500, "Caballito" },
                    { 4, 300, "Palermo" },
                    { 5, 150, "Recoleta" },
                    { 6, 100, "Belgrano" },
                    { 7, 200, "La Plata" },
                    { 8, 150, "Mar del Plata" },
                    { 9, 120, "Córdoba" },
                    { 10, 200, "Rosario" },
                    { 11, 130, "Mendoza" },
                    { 12, 150, "Tigre" },
                    { 13, 200, "Quilmes" },
                    { 14, 170, "San Miguel" },
                    { 15, 180, "Lomas de Zamora" },
                    { 16, 200, "Morón" },
                    { 17, 120, "Avellaneda" },
                    { 18, 110, "Banfield" },
                    { 19, 1, "E.T. el Extraterrestre" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "Apellido", "Bloqueado", "Credito", "DNI", "EsAdmin", "FechaNacimiento", "IntentosFallidos", "Mail", "Nombre", "Password" },
                values: new object[,]
                {
                    { 1, "Perez", false, 100m, 1L, false, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "pepe@mail.com", "Pepe", "123" },
                    { 2, "Admin", false, 0m, 2L, true, new DateTime(1990, 6, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "admin@mail.com", "El", "123" },
                    { 3, "Rodriguez", false, 3000m, 3L, false, new DateTime(1995, 8, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "lucas@mail.com", "Lucas", "123" },
                    { 4, "González", false, 500m, 4L, false, new DateTime(1988, 5, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "ana@mail.com", "Ana", "123" },
                    { 5, "López", false, 200m, 5L, false, new DateTime(1993, 9, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "maria@mail.com", "María", "123" },
                    { 6, "Fernández", false, 800m, 6L, false, new DateTime(1994, 12, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "luis@mail.com", "Luis", "123" },
                    { 7, "Martínez", false, 1500m, 7L, false, new DateTime(1991, 7, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "laura@mail.com", "Laura", "123" },
                    { 8, "Gómez", false, 1200m, 8L, false, new DateTime(1996, 3, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "carlos@mail.com", "Carlos", "123" },
                    { 9, "Rodríguez", false, 2500m, 9L, false, new DateTime(1989, 9, 12, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "ana.rodriguez@mail.com", "Ana", "123" },
                    { 10, "López", false, 300m, 10L, false, new DateTime(1997, 11, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "marcelo@mail.com", "Marcelo", "123" },
                    { 11, "Torres", false, 1800m, 11L, false, new DateTime(1993, 2, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "julia@mail.com", "Julia", "123" },
                    { 12, "García", false, 5000m, 12L, false, new DateTime(1995, 6, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "mariano@mail.com", "Mariano", "123" },
                    { 13, "López", false, 700m, 13L, false, new DateTime(1990, 10, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "gabriela@mail.com", "Gabriela", "123" },
                    { 14, "Pérez", false, 1000m, 14L, false, new DateTime(1994, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "federico@mail.com", "Federico", "123" },
                    { 15, "Fernández", false, 250m, 15L, false, new DateTime(1991, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "carolina@mail.com", "Carolina", "123" },
                    { 16, "González", false, 3500m, 16L, false, new DateTime(1988, 12, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "luciana@mail.com", "Luciana", "123" },
                    { 17, "Martínez", false, 900m, 17L, false, new DateTime(1997, 3, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "martin@mail.com", "Martín", "123" },
                    { 18, "Gómez", false, 2000m, 18L, false, new DateTime(1992, 9, 24, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "paula@mail.com", "Paula", "123" },
                    { 19, "Rodríguez", false, 3000m, 19L, false, new DateTime(1996, 1, 11, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "diego.rodriguez@mail.com", "Diego", "123" },
                    { 20, "López", false, 600m, 20L, false, new DateTime(1993, 5, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "sofia@mail.com", "Sofía", "123" },
                    { 21, "Torres", false, 1400m, 21L, false, new DateTime(1989, 11, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, "agustin@mail.com", "Agustín", "123" }
                });

            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "ID", "AsientosDisponibles", "CantidadClientes", "Costo", "Fecha", "idPelicula", "idSala" },
                values: new object[,]
                {
                    { 1, 200, 0, 2000m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 150, 0, 2500m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 3, 250, 0, 1500m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 4, 175, 0, 1000m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 5, 300, 0, 2200m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 6, 300, 0, 2200m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 7, 200, 0, 1800m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 8, 180, 0, 1500m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 9, 250, 0, 1200m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 10, 175, 0, 1000m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 11, 300, 0, 2000m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 12, 280, 0, 2200m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 13, 220, 0, 1900m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 14, 190, 0, 1700m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 15, 230, 0, 1400m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 16, 200, 0, 1200m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 17, 250, 0, 1000m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 18, 300, 0, 2200m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 19, 270, 0, 1900m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 20, 230, 0, 1700m, new DateTime(1992, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 21, 190, 0, 1400m, new DateTime(2023, 11, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "UF",
                columns: new[] { "idFuncion", "idUsuario", "CantidadEntradasCompradas" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 },
                    { 3, 1, 1 },
                    { 4, 3, 3 },
                    { 5, 3, 2 },
                    { 9, 4, 2 },
                    { 10, 4, 4 },
                    { 11, 4, 2 },
                    { 12, 6, 3 },
                    { 13, 6, 1 },
                    { 14, 6, 4 },
                    { 15, 8, 2 },
                    { 16, 8, 3 },
                    { 17, 8, 1 },
                    { 18, 10, 4 },
                    { 19, 10, 2 },
                    { 20, 10, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_idPelicula",
                table: "Funciones",
                column: "idPelicula");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_idSala",
                table: "Funciones",
                column: "idSala");

            migrationBuilder.CreateIndex(
                name: "IX_UF_idFuncion",
                table: "UF",
                column: "idFuncion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UF");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
