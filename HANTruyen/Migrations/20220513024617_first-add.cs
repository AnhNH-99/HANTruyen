using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HANTruyen.Migrations
{
    public partial class firstadd : Migration
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
                    CREATED_AT = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GetUtcDate()"),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "GetUtcDate()"),
                    CREATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    UPDATED_BY = table.Column<string>(maxLength: 256, nullable: true),
                    DELETED_FLAG = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STORY", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STORY");
        }
    }
}
