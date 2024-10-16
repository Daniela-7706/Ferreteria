using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferreteria.Data.Migrations
{
    /// <inheritdoc />
    public partial class num5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreProducto",
                table: "Detalle_OrdenCompras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreProducto",
                table: "Detalle_OrdenCompras",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
