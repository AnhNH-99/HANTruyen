using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANTruyen.Migrations
{
    public partial class Content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONTENT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHAPTER_ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(maxLength: 256, nullable: true),
                    BASE_IMAGE = table.Column<string>(type: "text", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    DELETED_FLAG = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTENT_CHAPTER_CHAPTER_ID",
                        column: x => x.CHAPTER_ID,
                        principalTable: "CHAPTER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTENT_CHAPTER_ID",
                table: "CONTENT",
                column: "CHAPTER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTENT");
        }
    }
}
