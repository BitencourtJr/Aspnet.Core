using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartSchool.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, "Marta", "Kent", "33225555" },
                    { 2, "Paula", "Isabela", "3354288" },
                    { 3, "Laura", "Antonia", "55668899" },
                    { 4, "Luiza", "Maria", "6565659" },
                    { 5, "Lucas", "Machado", "565685415" },
                    { 6, "Pedro", "Alvares", "456454545" },
                    { 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Lauro" },
                    { 2, "Roberto" },
                    { 3, "Ronaldo" },
                    { 4, "Rodrigo" },
                    { 5, "Alexandre" }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "Nome", "ProfessorId" },
                values: new object[,]
                {
                    { 1, "Matemática", 1 },
                    { 2, "Física", 2 },
                    { 3, "Português", 3 },
                    { 4, "Inglês", 4 },
                    { 5, "Programação", 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunoDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 4 },
                    { 5, 5 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplinas_DisciplinaId",
                table: "AlunoDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
