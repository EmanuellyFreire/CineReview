using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineReview.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentosMidia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Midias_Titulo",
                table: "Midias",
                column: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Midias_Titulo",
                table: "Midias");
        }
    }
}
