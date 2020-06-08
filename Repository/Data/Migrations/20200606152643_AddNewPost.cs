using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreTodo.Repository.Data.Migrations
{
    public partial class AddNewPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDone = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DueAt = table.Column<DateTimeOffset>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ContentMarkdown = table.Column<string>(nullable: true),
                    CommentEnabled = table.Column<bool>(nullable: false),
                    CreateOnUtc = table.Column<DateTime>(nullable: false),
                    PubDateUtc = table.Column<DateTime>(nullable: true),
                    ContentAbstract = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    ExposedToSiteMap = table.Column<bool>(nullable: false),
                    FeedIncluded = table.Column<bool>(nullable: false),
                    ContentLanguageCode = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
