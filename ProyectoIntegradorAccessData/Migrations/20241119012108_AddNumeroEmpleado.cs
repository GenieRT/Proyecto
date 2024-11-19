using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIntegradorAccessData.Migrations
{
    /// <inheritdoc />
    public partial class AddNumeroEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LineaPedido",
                table: "LineaPedido");

            migrationBuilder.DropIndex(
                name: "IX_LineaPedido_ProductoId",
                table: "LineaPedido");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LineaPedido");

            migrationBuilder.AddColumn<string>(
                name: "EncriptedPassword",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumeroEmpleado",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineaPedido",
                table: "LineaPedido",
                columns: new[] { "ProductoId", "PresentacionId", "PedidoId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LineaPedido",
                table: "LineaPedido");

            migrationBuilder.DropColumn(
                name: "EncriptedPassword",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NumeroEmpleado",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LineaPedido",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineaPedido",
                table: "LineaPedido",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LineaPedido_ProductoId",
                table: "LineaPedido",
                column: "ProductoId");
        }
    }
}
