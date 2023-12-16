using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtCSharpWebMVC3._0.Migrations
{
    public partial class AdicionandoColunaDateTimeProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCriacao",
                table: "ProfessorModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
       
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDeCriacao",
                table: "ProfessorModel");
        }
    }
}
