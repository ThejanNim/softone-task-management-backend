using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace softone_task_management_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskIsCheckedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Tasks",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Tasks");
        }
    }
}
