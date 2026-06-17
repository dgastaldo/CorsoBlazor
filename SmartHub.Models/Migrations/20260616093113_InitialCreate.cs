using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable


namespace SmartHub.Models.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IoTDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsOn = table.Column<bool>(type: "INTEGER", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IoTDevices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IoTDevices",
                columns: new[] { "Id", "Description", "IsOn", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "A smart light bulb.", true, "Smart Light", 75.0 },
                    { 2, "A smart thermostat for home heating.", false, "Smart Thermostat", 22.5 },
                    { 3, "A smart plug to control appliances.", true, "Smart Plug", 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IoTDevices");
        }
    }
}
