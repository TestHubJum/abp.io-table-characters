using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RickandMorty.Migrations
{
    /// <inheritdoc />
    public partial class Add_EntiteCharacterId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SelfId",
                table: "Characters",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelfId",
                table: "Characters");
        }
    }
}
