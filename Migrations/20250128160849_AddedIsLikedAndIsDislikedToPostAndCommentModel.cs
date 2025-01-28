using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_project.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsLikedAndIsDislikedToPostAndCommentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisliked",
                table: "Posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisliked",
                table: "Comments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Comments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisliked",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDisliked",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Comments");
        }
    }
}
