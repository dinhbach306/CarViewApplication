using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class InittialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car_brand_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageLogo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_brand_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_equipment_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_equipment_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_specs_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Power = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaximumTorque = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Acceleration = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Speed = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    FuelConsumption = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Emissions = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_specs_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_type_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_type_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_model_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarTypeId = table.Column<int>(type: "int", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_model_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_model_tbl_car_brand_tbl_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "car_brand_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_car_model_tbl_car_type_tbl_CarTypeId",
                        column: x => x.CarTypeId,
                        principalTable: "car_type_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "car_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_tbl_car_model_tbl_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "car_model_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "car_detail_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(12,0)", precision: 12, scale: 0, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WheelBase = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    CarSpecsId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_detail_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_detail_tbl_car_specs_tbl_CarSpecsId",
                        column: x => x.CarSpecsId,
                        principalTable: "car_specs_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_car_detail_tbl_car_tbl_CarId",
                        column: x => x.CarId,
                        principalTable: "car_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "car_detail_equipment_tbl",
                columns: table => new
                {
                    CarDetailId = table.Column<int>(type: "int", nullable: false),
                    CarEquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_detail_equipment_tbl", x => new { x.CarDetailId, x.CarEquipmentId });
                    table.ForeignKey(
                        name: "FK_car_detail_equipment_tbl_car_detail_tbl_CarDetailId",
                        column: x => x.CarDetailId,
                        principalTable: "car_detail_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_car_detail_equipment_tbl_car_equipment_tbl_CarEquipmentId",
                        column: x => x.CarEquipmentId,
                        principalTable: "car_equipment_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "car_image_tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageCar1 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImageCar2 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImageCar3 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImageCar4 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImageCar5 = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CarDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_image_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_car_image_tbl_car_detail_tbl_CarDetailId",
                        column: x => x.CarDetailId,
                        principalTable: "car_detail_tbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_detail_equipment_tbl_CarEquipmentId",
                table: "car_detail_equipment_tbl",
                column: "CarEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_car_detail_tbl_CarId",
                table: "car_detail_tbl",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_car_detail_tbl_CarSpecsId",
                table: "car_detail_tbl",
                column: "CarSpecsId",
                unique: true,
                filter: "[CarSpecsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_car_image_tbl_CarDetailId",
                table: "car_image_tbl",
                column: "CarDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_car_model_tbl_CarBrandId",
                table: "car_model_tbl",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_car_model_tbl_CarTypeId",
                table: "car_model_tbl",
                column: "CarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_car_tbl_CarModelId",
                table: "car_tbl",
                column: "CarModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car_detail_equipment_tbl");

            migrationBuilder.DropTable(
                name: "car_image_tbl");

            migrationBuilder.DropTable(
                name: "car_equipment_tbl");

            migrationBuilder.DropTable(
                name: "car_detail_tbl");

            migrationBuilder.DropTable(
                name: "car_specs_tbl");

            migrationBuilder.DropTable(
                name: "car_tbl");

            migrationBuilder.DropTable(
                name: "car_model_tbl");

            migrationBuilder.DropTable(
                name: "car_brand_tbl");

            migrationBuilder.DropTable(
                name: "car_type_tbl");
        }
    }
}
