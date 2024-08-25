using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "KidsVideos");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "KidsVideos");

            migrationBuilder.AddColumn<byte[]>(
                name: "ThumbnailData",
                table: "KidsVideos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "VideoData",
                table: "KidsVideos",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailData",
                table: "KidsVideos");

            migrationBuilder.DropColumn(
                name: "VideoData",
                table: "KidsVideos");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "KidsVideos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "KidsVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
