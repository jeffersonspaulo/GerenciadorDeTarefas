using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeTarefas.API.Migrations
{
    /// <inheritdoc />
    public partial class AlterTarefaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Concluída");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Concluído");
        }
    }
}
