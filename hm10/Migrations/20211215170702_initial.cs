using Microsoft.EntityFrameworkCore.Migrations;

namespace hm10.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expressions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Val1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Val2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Op = table.Column<byte>(type: "tinyint", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expressions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expressions");
        }
    }
}
