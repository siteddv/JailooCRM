using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JailooCRM.DAL.Migrations
{
    public partial class setDeleteDepRestriction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Departments_DepartmentId",
                table: "Subcategories");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Subcategories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Departments_DepartmentId",
                table: "Subcategories",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategories_Departments_DepartmentId",
                table: "Subcategories");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Subcategories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategories_Departments_DepartmentId",
                table: "Subcategories",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
