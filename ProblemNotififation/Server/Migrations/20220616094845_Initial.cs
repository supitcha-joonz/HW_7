using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProblemNotififation.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Problems_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Oioi", "SmartCare" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "oioi", "Tidlor" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "Id", "ApplicationId", "Description", "FirstName", "LastName", "ProblemName" },
                values: new object[] { 1, 1, "Login เข้าใช้งานไม่ได้", "Supitcha", "Jampathong", "App เปิดไม่ขึ้น" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "Id", "ApplicationId", "Description", "FirstName", "LastName", "ProblemName" },
                values: new object[] { 2, 2, "เมื่อวานใช้งานได้ปกติ แต่วันนี้ตอนเช้า login ด้วย password ใหม่แล้วขึ้น popup error", "Joonz", "OiOi", "App เปิดไม่ขึ้น" });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ApplicationId",
                table: "Problems",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
