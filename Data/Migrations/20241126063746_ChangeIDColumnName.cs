using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetproject.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIDColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Books",
                newName: "Id");
        }
    }
}
