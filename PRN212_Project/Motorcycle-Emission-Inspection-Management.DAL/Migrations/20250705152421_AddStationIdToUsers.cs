using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorcycle_Emission_Inspection_Management.DAL.Migrations
{
    public partial class AddStationIdToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* 1. Thêm cột StationID (nullable) */
            migrationBuilder.AddColumn<int>(
                name: "StationID",
                table: "Users",
                type: "int",
                nullable: true);

            /* 2. Tạo chỉ mục cho cột mới */
            migrationBuilder.CreateIndex(
                name: "IX_Users_StationID",
                table: "Users",
                column: "StationID");

            /* 3. Tạo FK tới bảng InspectionStations */
            migrationBuilder.AddForeignKey(
                name: "FK_Users_StationID",
                table: "Users",
                column: "StationID",
                principalTable: "InspectionStations",
                principalColumn: "StationID",
                onDelete: ReferentialAction.Restrict);   // Giữ dữ liệu, không xoá cascade
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /* Hoàn tác thay đổi nếu rollback */
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StationID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StationID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StationID",
                table: "Users");
        }
    }
}
