using Microsoft.EntityFrameworkCore.Migrations;

namespace DownWallet.DataAccess.Migrations
{
    public partial class fixedTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WalletNumber",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletNumber",
                table: "Transaction");
        }
    }
}
