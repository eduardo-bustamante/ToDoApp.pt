using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApp.pt.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_340 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    SituacaoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.SituacaoId);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SituacaoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDos_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "SituacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Nome" },
                values: new object[,]
                {
                    { "casa", "Casa" },
                    { "compra", "Compra" },
                    { "contato", "Contato" },
                    { "ex", "Exercicio" },
                    { "tarefa", "Tarefa" }
                });

            migrationBuilder.InsertData(
                table: "Situacoes",
                columns: new[] { "SituacaoId", "Nome" },
                values: new object[,]
                {
                    { "aberto", "Aberto" },
                    { "concluido", "Concluido" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_CategoriaId",
                table: "ToDos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_SituacaoId",
                table: "ToDos",
                column: "SituacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Situacoes");
        }
    }
}
