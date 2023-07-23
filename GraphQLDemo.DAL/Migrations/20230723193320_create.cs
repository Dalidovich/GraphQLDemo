using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLDemo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "statistics",
                columns: table => new
                {
                    pk_statistics_id = table.Column<Guid>(type: "uuid", nullable: false),
                    last_active = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rating = table.Column<double>(type: "float8", nullable: false),
                    age = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statistics", x => x.pk_statistics_id);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    pk_account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    login = table.Column<string>(type: "character varying", nullable: false),
                    StatisticsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.pk_account_id);
                    table.ForeignKey(
                        name: "FK_accounts_statistics_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "statistics",
                        principalColumn: "pk_statistics_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_login",
                table: "accounts",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_StatisticsId",
                table: "accounts",
                column: "StatisticsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "statistics");
        }
    }
}
