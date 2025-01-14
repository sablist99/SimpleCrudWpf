using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ChangePkForEmployeeOnProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeOnProjects",
                table: "EmployeeOnProjects");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EmployeeOnProjects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeOnProjects",
                table: "EmployeeOnProjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOnProjects_EmployeeId",
                table: "EmployeeOnProjects",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeOnProjects",
                table: "EmployeeOnProjects");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeOnProjects_EmployeeId",
                table: "EmployeeOnProjects");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EmployeeOnProjects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeOnProjects",
                table: "EmployeeOnProjects",
                columns: new[] { "EmployeeId", "ProjectId" });
        }
    }
}
