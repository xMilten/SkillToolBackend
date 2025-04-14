using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillToolBackend.Migrations
{
    public partial class SkillTool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => new { x.EmployeeId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Skills_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Location" },
                values: new object[] { 1, "Rolf", "Augustin", "Bremen" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Location" },
                values: new object[] { 2, "Mario", "Theuner", "Bielefeld" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Location" },
                values: new object[] { 3, "Timo", "Heil", "Cottbus" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Location" },
                values: new object[] { 4, "Lilly", "Steinkamp", "Berlin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Location" },
                values: new object[] { 5, "Irmgard", "Seifried", "Bremen" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName", "Location" },
                values: new object[] { 6, "Ilja", "Lohmann", "Berlin" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name" },
                values: new object[] { 1, "C" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name" },
                values: new object[] { 2, "C++" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name" },
                values: new object[] { 3, "C#" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name" },
                values: new object[] { 4, "PHP" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name" },
                values: new object[] { 5, "Java" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name" },
                values: new object[] { 6, "JavaScript" });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 1, 1, 8 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 1, 2, 7 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 2, 5, 8 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 3, 4, 9 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 3, 6, 5 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 4, 5, 9 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 5, 3, 7 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 5, 5, 8 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 6, 4, 6 });

            migrationBuilder.InsertData(
                table: "EmployeeSkills",
                columns: new[] { "EmployeeId", "SkillId", "Rating" },
                values: new object[] { 6, 6, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
