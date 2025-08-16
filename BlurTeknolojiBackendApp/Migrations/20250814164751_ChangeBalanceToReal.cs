using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlurTeknolojiBackendApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBalanceToReal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "Enterprises",
                type: "decimal(18,2)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Balance",
                table: "Enterprises",
                type: "real",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldMaxLength: 12);
        }
    }
}
