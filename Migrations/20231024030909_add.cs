using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Tb_Despesas",
                newName: "NomeCategoria");

            migrationBuilder.AddColumn<string>(
                name: "CategoriaNomeCategoria",
                table: "Tb_Despesas",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    NomeCategoria = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.NomeCategoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Despesas_CategoriaNomeCategoria",
                table: "Tb_Despesas",
                column: "CategoriaNomeCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Despesas_Categorias_CategoriaNomeCategoria",
                table: "Tb_Despesas",
                column: "CategoriaNomeCategoria",
                principalTable: "Categorias",
                principalColumn: "NomeCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Despesas_Categorias_CategoriaNomeCategoria",
                table: "Tb_Despesas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Despesas_CategoriaNomeCategoria",
                table: "Tb_Despesas");

            migrationBuilder.DropColumn(
                name: "CategoriaNomeCategoria",
                table: "Tb_Despesas");

            migrationBuilder.RenameColumn(
                name: "NomeCategoria",
                table: "Tb_Despesas",
                newName: "Categoria");
        }
    }
}
