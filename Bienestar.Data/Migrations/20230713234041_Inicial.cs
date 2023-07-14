using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bienestar.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TL_Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroIdentificacion = table.Column<long>(type: "bigint", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TL_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TL_Hijos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Estudia = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    EstaturaCms = table.Column<short>(type: "smallint", nullable: false),
                    DescripcionFisica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TL_Hijos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TL_Hijos_TL_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TL_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TL_Padres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TipoEmpleo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ExperienciaLaboral = table.Column<short>(type: "smallint", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TL_Padres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TL_Padres_TL_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "TL_Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TL_RelacionPadresHijos",
                columns: table => new
                {
                    PadreId = table.Column<int>(type: "int", nullable: false),
                    HijoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TL_RelacionPadresHijos", x => new { x.PadreId, x.HijoId });
                    table.ForeignKey(
                        name: "FK_TL_RelacionPadresHijos_TL_Hijos_HijoId",
                        column: x => x.HijoId,
                        principalTable: "TL_Hijos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TL_RelacionPadresHijos_TL_Padres_PadreId",
                        column: x => x.PadreId,
                        principalTable: "TL_Padres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TL_Hijos_UsuarioId",
                table: "TL_Hijos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TL_Padres_UsuarioId",
                table: "TL_Padres",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TL_RelacionPadresHijos_HijoId",
                table: "TL_RelacionPadresHijos",
                column: "HijoId");

            migrationBuilder.CreateIndex(
                name: "IX_TL_Usuarios_NumeroIdentificacion",
                table: "TL_Usuarios",
                column: "NumeroIdentificacion",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TL_RelacionPadresHijos");

            migrationBuilder.DropTable(
                name: "TL_Hijos");

            migrationBuilder.DropTable(
                name: "TL_Padres");

            migrationBuilder.DropTable(
                name: "TL_Usuarios");
        }
    }
}
