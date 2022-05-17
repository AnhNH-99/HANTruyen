using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANTruyen.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STORY",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(nullable: false),
                    TITLE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(type: "text", nullable: true),
                    STATUS = table.Column<int>(nullable: false, defaultValue: 0),
                    AUTHOR = table.Column<int>(nullable: false),
                    VIEWS = table.Column<int>(nullable: false, defaultValue: 0),
                    FOLLOWS = table.Column<int>(nullable: false, defaultValue: 0),
                    LIKES = table.Column<int>(nullable: false, defaultValue: 0),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    DELETED_FLAG = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CHAPTER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STORY_ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TITLE = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    VIEWS = table.Column<int>(nullable: false, defaultValue: 0),
                    LIKES = table.Column<int>(nullable: false, defaultValue: 0),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    DELETED_FLAG = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHAPTER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CHAPTER_STORY_STORY_ID",
                        column: x => x.STORY_ID,
                        principalTable: "STORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHAPTER_STORY_ID",
                table: "CHAPTER",
                column: "STORY_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHAPTER");

            migrationBuilder.DropTable(
                name: "STORY");
        }
    }
}
