using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLDemo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixNamingAccountFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_statistics_StatisticsId",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "StatisticsId",
                table: "accounts",
                newName: "fk_statistics_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_StatisticsId",
                table: "accounts",
                newName: "IX_accounts_fk_statistics_id");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_statistics_fk_statistics_id",
                table: "accounts",
                column: "fk_statistics_id",
                principalTable: "statistics",
                principalColumn: "pk_statistics_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accounts_statistics_fk_statistics_id",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "fk_statistics_id",
                table: "accounts",
                newName: "StatisticsId");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_fk_statistics_id",
                table: "accounts",
                newName: "IX_accounts_StatisticsId");

            migrationBuilder.AddForeignKey(
                name: "FK_accounts_statistics_StatisticsId",
                table: "accounts",
                column: "StatisticsId",
                principalTable: "statistics",
                principalColumn: "pk_statistics_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
