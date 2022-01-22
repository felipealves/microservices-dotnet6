using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FelipeShopping.ProdutoAPI.Migrations
{
    public partial class AdicionarProdutosNaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imagem_url",
                table: "produto",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "produto",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "categoria_nome",
                table: "produto",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "id", "categoria_nome", "descricao", "imagem_url", "nome", "valor" },
                values: new object[,]
                {
                    { 15L, "Camiseta", "Felipe Descricao_15", "http://felipeproduto.com/15", "Felipe_15", 899.85m },
                    { 16L, "Camiseta", "Felipe Descricao_16", "http://felipeproduto.com/16", "Felipe_16", 3199.84m },
                    { 17L, "Camiseta", "Felipe Descricao_17", "http://felipeproduto.com/17", "Felipe_17", 3399.83m },
                    { 18L, "Shorts", "Felipe Descricao_18", "http://felipeproduto.com/18", "Felipe_18", 3599.82m },
                    { 19L, "Shorts", "Felipe Descricao_19", "http://felipeproduto.com/19", "Felipe_19", 3799.81m },
                    { 20L, "Shorts", "Felipe Descricao_20", "http://felipeproduto.com/20", "Felipe_20", 3999.8m },
                    { 21L, "Bones", "Felipe Descricao_21", "http://felipeproduto.com/21", "Felipe_21", 4199.79m },
                    { 22L, "Bones", "Felipe Descricao_22", "http://felipeproduto.com/22", "Felipe_22", 4399.78m },
                    { 23L, "Bones", "Felipe Descricao_23", "http://felipeproduto.com/23", "Felipe_23", 4599.77m },
                    { 24L, "Livro", "Felipe Descricao_24", "http://felipeproduto.com/24", "Felipe_24", 4799.76m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "produto",
                keyColumn: "id",
                keyValue: 24L);

            migrationBuilder.UpdateData(
                table: "produto",
                keyColumn: "imagem_url",
                keyValue: null,
                column: "imagem_url",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "imagem_url",
                table: "produto",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "produto",
                keyColumn: "descricao",
                keyValue: null,
                column: "descricao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "produto",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "produto",
                keyColumn: "categoria_nome",
                keyValue: null,
                column: "categoria_nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "categoria_nome",
                table: "produto",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
