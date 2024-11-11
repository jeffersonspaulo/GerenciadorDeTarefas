using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GerenciadorDeTarefas.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_TarefasStatus_TarefaStatusId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "TarefasStatus");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_TarefaStatusId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "TarefaStatusId",
                table: "Tarefas",
                newName: "TarefaStatus");

            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "TarefaStatus",
                table: "Tarefas",
                newName: "TarefaStatusId");

            migrationBuilder.CreateTable(
                name: "TarefasStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarefasStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TarefasStatus",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Pendente" },
                    { 2, "Em Andamento" },
                    { 3, "Concluída" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_TarefaStatusId",
                table: "Tarefas",
                column: "TarefaStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_TarefasStatus_TarefaStatusId",
                table: "Tarefas",
                column: "TarefaStatusId",
                principalTable: "TarefasStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
