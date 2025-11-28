using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineReview.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentosFavorito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.DropIndex(
                name: "IX_Favoritos_UsuarioId",
                table: "Favoritos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Favoritos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                columns: new[] { "UsuarioId", "MidiaId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Favoritos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favoritos",
                table: "Favoritos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_UsuarioId",
                table: "Favoritos",
                column: "UsuarioId");
        }
    }
}
