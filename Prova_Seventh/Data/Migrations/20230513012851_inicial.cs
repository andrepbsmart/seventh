using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prova.Data.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "servers",
                columns: table => new
                {
                    idserver = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    ip = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    port = table.Column<int>(type: "int", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servers", x => x.idserver);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    idvideo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    idserver = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.idvideo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "servers");

            migrationBuilder.DropTable(
                name: "videos");
        }
    }
}
