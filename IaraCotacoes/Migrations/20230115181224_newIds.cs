using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IaraCotacoes.Migrations
{
    public partial class newIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CotacaoItem_Cotacao_CotacaoId",
                table: "CotacaoItem");

            migrationBuilder.AlterColumn<int>(
                name: "CotacaoId",
                table: "CotacaoItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CotacaoItem_Cotacao_CotacaoId",
                table: "CotacaoItem",
                column: "CotacaoId",
                principalTable: "Cotacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CotacaoItem_Cotacao_CotacaoId",
                table: "CotacaoItem");

            migrationBuilder.AlterColumn<int>(
                name: "CotacaoId",
                table: "CotacaoItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CotacaoItem_Cotacao_CotacaoId",
                table: "CotacaoItem",
                column: "CotacaoId",
                principalTable: "Cotacao",
                principalColumn: "Id");
        }
    }
}
