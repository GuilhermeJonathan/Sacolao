using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sacolao.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    QuantidadeEstoque = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Senha = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompraFruta",
                columns: table => new
                {
                    ComprasId = table.Column<int>(type: "INTEGER", nullable: false),
                    FrutasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraFruta", x => new { x.ComprasId, x.FrutasId });
                    table.ForeignKey(
                        name: "FK_CompraFruta_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraFruta_Frutas_FrutasId",
                        column: x => x.FrutasId,
                        principalTable: "Frutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FrutasCompras",
                columns: table => new
                {
                    FrutaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrutasCompras", x => new { x.FrutaId, x.CompraId });
                    table.ForeignKey(
                        name: "FK_FrutasCompras_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrutasCompras_Frutas_FrutaId",
                        column: x => x.FrutaId,
                        principalTable: "Frutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Frutas",
                columns: new[] { "Id", "Descricao", "Foto", "Nome", "QuantidadeEstoque", "Valor" },
                values: new object[] { 1, "Amarela", "banana.jpg", "Banana", 50, 5m });

            migrationBuilder.InsertData(
                table: "Frutas",
                columns: new[] { "Id", "Descricao", "Foto", "Nome", "QuantidadeEstoque", "Valor" },
                values: new object[] { 2, "Vermelha", "maca.jpg", "Maça", 150, 2m });

            migrationBuilder.InsertData(
                table: "Frutas",
                columns: new[] { "Id", "Descricao", "Foto", "Nome", "QuantidadeEstoque", "Valor" },
                values: new object[] { 3, "Verde", "melancia.jpg", "Melancia", 15, 9m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "Email", "Nome", "Senha" },
                values: new object[] { 1, true, "teste@teste.com.br", "Teste 1", "123456" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "Email", "Nome", "Senha" },
                values: new object[] { 2, true, "teste2@teste.com.br", "Teste 2", "123456" });

            migrationBuilder.CreateIndex(
                name: "IX_CompraFruta_FrutasId",
                table: "CompraFruta",
                column: "FrutasId");

            migrationBuilder.CreateIndex(
                name: "IX_FrutasCompras_CompraId",
                table: "FrutasCompras",
                column: "CompraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraFruta");

            migrationBuilder.DropTable(
                name: "FrutasCompras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Frutas");
        }
    }
}
