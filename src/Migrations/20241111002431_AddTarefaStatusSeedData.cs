using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeTarefas.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTarefaStatusSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Pendente");

            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "Em Andamento");

            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Concluído");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_UsuarioId",
                table: "Projetos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Usuario_UsuarioId",
                table: "Projetos",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Usuario_UsuarioId",
                table: "Projetos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_UsuarioId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Projetos");

            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nome",
                value: "InProgress");

            migrationBuilder.UpdateData(
                table: "TarefasStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Completed");
        }
    }
}
