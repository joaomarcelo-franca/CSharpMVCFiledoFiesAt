using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtCSharpWebMVC3._0.Migrations
{
    public partial class AdicionandoIdadeAoProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "ProfessorModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "ProfessorModel");
        }
    }
}
