using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Email", "Name", "PhoneNumber", "Street", "StreetNumber", "StreetNumberSuffix", "Website" },
                values: new object[,]
                {
                    { 1, "Rotterdam", "recruitment@jex.nl", "JEX", "010 300 7869", "Nassaukade", 5, null, "http://www.jex.nl" },
                    { 2, "Amsterdam", "jobs@kpmg.nl", "KPMG", "020 431 6232", "Hoofdweg", 11, null, "http://www.kpmg.nl" },
                    { 3, "Utrecht", "werkenbij@coolblue.nl", "Coolblue", "030 227 5542", "Dorpslaan", 23, null, "http://www.coolblue.nl" },
                    { 4, "Den Haag", "careers@capgemini.nl", "Capgemini", "070 328 2234", "Noordplein", 47, null, "http://www.capgemini.nl" }
                });

            migrationBuilder.InsertData(
                table: "JobPostings",
                columns: new[] { "Id", "CompanyId", "Description", "IsActive", "MaxHoursPerWeek", "MaxMonthlySalary", "MinHoursPerWeek", "MinMonthlySalary", "Title" },
                values: new object[,]
                {
                    { 1, 1, "We zijn op zoek naar een ervaren backend developer die ervaring heeft met MassTransit.", true, null, null, null, null, "Backend Developer" },
                    { 2, 1, "We zoeken naar een gedreven frontend developer waar Angular geen geheimen voor heeft!", true, null, null, null, null, "Frontend Developer" },
                    { 3, 1, "Word jij onze nieuwe tester? Soliciteer maar gauw!", false, null, null, null, null, "Software Tester" },
                    { 4, 2, "Heb jij kwaliteit hoog in het vaandel staan? Dan zoeken we jou!", true, null, null, null, null, "QA inspecteur" },
                    { 5, 2, "We zoeken naar iemand met ruime ervaring als DB-beheerder", false, null, null, null, null, "Database beheerder" },
                    { 6, 3, "Kom werken in ons magazijn!", false, null, null, null, null, "Magazijnmedewerker" },
                    { 7, 3, "Adviseer onze klanten speakers en hifi", false, null, null, null, null, "Audiospecialist" }
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
