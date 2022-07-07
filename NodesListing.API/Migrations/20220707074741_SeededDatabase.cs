using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodesListing.API.Migrations
{
    public partial class SeededDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OnionServicePort",
                table: "HostConfigurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DirectoryServicePort",
                table: "HostConfigurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "Name" },
                values: new object[] { "RO", "Romania" });

            migrationBuilder.InsertData(
                table: "HostConfigurations",
                columns: new[] { "Id", "DirectoryServicePort", "Hostname", "OnionServicePort" },
                values: new object[] { 1, 8080, "localhost", 3000 });

            migrationBuilder.InsertData(
                table: "HostConfigurations",
                columns: new[] { "Id", "DirectoryServicePort", "Hostname", "OnionServicePort" },
                values: new object[] { 2, 8081, "localhost", 3001 });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Address", "CountryCode", "HostConfigurationId", "PublicKey" },
                values: new object[] { "node-1", "RO", 1, "public-key-1" });

            migrationBuilder.InsertData(
                table: "Nodes",
                columns: new[] { "Address", "CountryCode", "HostConfigurationId", "PublicKey" },
                values: new object[] { "node-2", "RO", 2, "public-key-2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Address",
                keyValue: "node-1");

            migrationBuilder.DeleteData(
                table: "Nodes",
                keyColumn: "Address",
                keyValue: "node-2");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "RO");

            migrationBuilder.DeleteData(
                table: "HostConfigurations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HostConfigurations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "OnionServicePort",
                table: "HostConfigurations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DirectoryServicePort",
                table: "HostConfigurations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
