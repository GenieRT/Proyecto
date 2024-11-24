using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIntegradorAccessData.Migrations
{
    /// <inheritdoc />
    public partial class lineaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaPedido_Pedidos_PedidoId",
                table: "LineaPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaPedido_Productos_ProductoId",
                table: "LineaPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineaPedido",
                table: "LineaPedido");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationToken",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemporalPassword",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "LineaPedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LineaPedido_Pedidos_PedidoId",
                table: "LineaPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LineaPedido_Productos_ProductoId",
                table: "LineaPedido",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineaPedido_Pedidos_PedidoId",
                table: "LineaPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_LineaPedido_Productos_ProductoId",
                table: "LineaPedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineaPedido",
                table: "LineaPedido");

            migrationBuilder.DropIndex(
                name: "IX_LineaPedido_ProductoId",
                table: "LineaPedido");

            migrationBuilder.DropColumn(
                name: "ConfirmationToken",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TemporalPassword",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LineaPedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "LineaPedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineaPedido",
                table: "LineaPedido",
                columns: new[] { "ProductoId", "PresentacionId", "PedidoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LineaPedido_Pedidos_PedidoId",
                table: "LineaPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineaPedido_Productos_ProductoId",
                table: "LineaPedido",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
