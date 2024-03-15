using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class dsad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Despesas_Categorias_CategoriaNomeCategoria",
                table: "Tb_Despesas");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNomeCategoria",
                table: "Tb_Despesas",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Despesas_Categorias_CategoriaNomeCategoria",
                table: "Tb_Despesas",
                column: "CategoriaNomeCategoria",
                principalTable: "Categorias",
                principalColumn: "NomeCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Despesas_Categorias_CategoriaNomeCategoria",
                table: "Tb_Despesas");

            migrationBuilder.UpdateData(
                table: "Tb_Despesas",
                keyColumn: "CategoriaNomeCategoria",
                keyValue: null,
                column: "CategoriaNomeCategoria",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaNomeCategoria",
                table: "Tb_Despesas",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Despesas_Categorias_CategoriaNomeCategoria",
                table: "Tb_Despesas",
                column: "CategoriaNomeCategoria",
                principalTable: "Categorias",
                principalColumn: "NomeCategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
