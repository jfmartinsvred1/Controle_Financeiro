using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class newDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Despesas",
                columns: table => new
                {
                    IdDespesa = table.Column<int>(name: "Id_Despesa", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescricaoDespesa = table.Column<string>(name: "Descricao_Despesa", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorDespesa = table.Column<double>(name: "Valor_Despesa", type: "double", nullable: false),
                    DataDespesa = table.Column<DateTime>(name: "Data_Despesa", type: "datetime(6)", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Despesas", x => x.IdDespesa);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tb_Receitas",
                columns: table => new
                {
                    IdReceita = table.Column<int>(name: "Id_Receita", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DescricaoReceita = table.Column<string>(name: "Descricao_Receita", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorReceita = table.Column<double>(name: "Valor_Receita", type: "double", nullable: false),
                    DataReceita = table.Column<DateTime>(name: "Data_Receita", type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Receitas", x => x.IdReceita);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Despesas");

            migrationBuilder.DropTable(
                name: "Tb_Receitas");
        }
    }
}
