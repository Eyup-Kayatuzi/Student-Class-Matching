using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication8.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_ClassTypes_ClassTypeId",
                        column: x => x.ClassTypeId,
                        principalTable: "ClassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassTypes",
                columns: new[] { "Id", "Branch", "Level" },
                values: new object[] { 1, "Matematik", 1 });

            migrationBuilder.InsertData(
                table: "ClassTypes",
                columns: new[] { "Id", "Branch", "Level" },
                values: new object[] { 2, "Fizik", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "ClassTypeId", "FirstName", "LastName" },
                values: new object[] { 1, "İstanbul", 1, "Yaman", "Seven" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "ClassTypeId", "FirstName", "LastName" },
                values: new object[] { 2, "Tekirdağ", 2, "Hüseyin", "Şülen" });

            migrationBuilder.CreateIndex(
                name: "IX_ClassTypes_Level_Branch",
                table: "ClassTypes",
                columns: new[] { "Level", "Branch" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassTypeId",
                table: "Students",
                column: "ClassTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ClassTypes");
        }
    }
}
