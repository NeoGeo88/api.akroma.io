using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Akroma.Persistence.SQL.Migrations
{
    public partial class AddPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Usd = table.Column<string>(nullable: true),
                    UsdDayAgoRaw = table.Column<decimal>(nullable: false),
                    UsdRaw = table.Column<decimal>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prices_CreatedAt",
                table: "Prices",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_Symbol",
                table: "Prices",
                column: "Symbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");
        }
    }
}
