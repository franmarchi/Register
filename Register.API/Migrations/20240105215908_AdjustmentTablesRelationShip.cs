using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Register.API.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentTablesRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneId",
                table: "Phones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "People",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneId",
                table: "Phones",
                column: "PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_PhoneTypes_PhoneId",
                table: "Phones",
                column: "PhoneId",
                principalTable: "PhoneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_PhoneTypes_PhoneId",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_PhoneId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "People");
        }
    }
}
