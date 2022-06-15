using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProblemNotififation.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProblemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "Id", "ApplicationName", "Description", "FirstName", "LastName", "ProblemName" },
                values: new object[] { 1, "Smartcare", "Login เข้าใช้งานไม่ได้", "Supitcha", "Jampathong", "App เปิดไม่ขึ้น" });

            migrationBuilder.InsertData(
                table: "Problems",
                columns: new[] { "Id", "ApplicationName", "Description", "FirstName", "LastName", "ProblemName" },
                values: new object[] { 2, "TidlorTidlen", "เมื่อวานใช้งานได้ปกติ แต่วันนี้ตอนเช้า login ด้วย password ใหม่แล้วขึ้น popup error", "Joonz", "OiOi", "App เปิดไม่ขึ้น" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problems");
        }
    }
}
