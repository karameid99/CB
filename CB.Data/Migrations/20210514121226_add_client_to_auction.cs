using Microsoft.EntityFrameworkCore.Migrations;

namespace CB.Data.Migrations
{
    public partial class add_client_to_auction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBidder",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BayerId",
                table: "Auctions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Auctions",
                type: "int",
                nullable: false,
                defaultValue: 0);

           

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_BayerId",
                table: "Auctions",
                column: "BayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_SellerId",
                table: "Auctions",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Clients_BayerId",
                table: "Auctions",
                column: "BayerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_Clients_SellerId",
                table: "Auctions",
                column: "SellerId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Clients_BayerId",
                table: "Auctions");

            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_Clients_SellerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_BayerId",
                table: "Auctions");

            migrationBuilder.DropIndex(
                name: "IX_Auctions_SellerId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "IsBidder",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "BayerId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Auctions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Auctions");

           
        }
    }
}
