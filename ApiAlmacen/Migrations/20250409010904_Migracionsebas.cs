using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAlmacen.Migrations
{
    /// <inheritdoc />
    public partial class Migracionsebas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asignacionCliente",
                columns: table => new
                {
                    IdAsignacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Visitado = table.Column<bool>(type: "bit", nullable: false),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignacionCliente", x => x.IdAsignacion);
                    table.ForeignKey(
                        name: "FK_asignacionCliente_usuario_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asignacionCliente_usuario_IdVendedor",
                        column: x => x.IdVendedor,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asignacionCliente_IdCliente",
                table: "asignacionCliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_asignacionCliente_IdVendedor",
                table: "asignacionCliente",
                column: "IdVendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asignacionCliente");
        }
    }
}
