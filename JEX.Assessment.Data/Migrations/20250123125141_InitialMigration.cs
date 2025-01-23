using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JEX.Assessment.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Street = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    StreetNumberSuffix = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Website = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPostings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    MinMonthlySalary = table.Column<int>(type: "int", nullable: true),
                    MaxMonthlySalary = table.Column<int>(type: "int", nullable: true),
                    MinHoursPerWeek = table.Column<byte>(type: "tinyint", nullable: true),
                    MaxHoursPerWeek = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPostings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Name",
                table: "Companies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_CompanyId",
                table: "JobPostings",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPostings");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
