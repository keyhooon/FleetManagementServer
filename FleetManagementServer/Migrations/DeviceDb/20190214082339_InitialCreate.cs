using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FleetManagementServer.Migrations.DeviceDb
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Imei = table.Column<string>(nullable: true),
                    SecurityCode = table.Column<byte[]>(nullable: true),
                    SecurityCodeVerification = table.Column<bool>(nullable: false),
                    DeviceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceParameterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<Guid>(nullable: false),
                    ParameterTypeId = table.Column<int>(nullable: false),
                    DeviceTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceParameterTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceParameterTypes_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceParameterTypes_ParameterTypes_ParameterTypeId",
                        column: x => x.ParameterTypeId,
                        principalTable: "ParameterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametersPackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeviceId = table.Column<Guid>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametersPackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametersPackets_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvlPackets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParameterPacketId = table.Column<int>(nullable: false),
                    GpsLatitiude = table.Column<double>(nullable: true),
                    GpsLongitude = table.Column<double>(nullable: true),
                    GpsAltitude = table.Column<double>(nullable: true),
                    GpsAngle = table.Column<double>(nullable: true),
                    Satellites = table.Column<int>(nullable: true),
                    Speed = table.Column<double>(nullable: true),
                    EventIoId = table.Column<int>(nullable: true),
                    IsValid = table.Column<bool>(nullable: true),
                    ServerTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvlPackets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvlPackets_ParametersPackets_ParameterPacketId",
                        column: x => x.ParameterPacketId,
                        principalTable: "ParametersPackets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametersPacketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParameterPacketId = table.Column<int>(nullable: false),
                    DeviceParameterTypeId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    ParameterTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametersPacketDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametersPacketDetails_ParametersPackets_ParameterPacketId",
                        column: x => x.ParameterPacketId,
                        principalTable: "ParametersPackets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParametersPacketDetails_ParameterTypes_ParameterTypeId",
                        column: x => x.ParameterTypeId,
                        principalTable: "ParameterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvlPackets_ParameterPacketId",
                table: "AvlPackets",
                column: "ParameterPacketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameterTypes_DeviceTypeId",
                table: "DeviceParameterTypes",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceParameterTypes_ParameterTypeId",
                table: "DeviceParameterTypes",
                column: "ParameterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametersPacketDetails_ParameterPacketId",
                table: "ParametersPacketDetails",
                column: "ParameterPacketId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametersPacketDetails_ParameterTypeId",
                table: "ParametersPacketDetails",
                column: "ParameterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametersPackets_DeviceId",
                table: "ParametersPackets",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvlPackets");

            migrationBuilder.DropTable(
                name: "DeviceParameterTypes");

            migrationBuilder.DropTable(
                name: "ParametersPacketDetails");

            migrationBuilder.DropTable(
                name: "ParametersPackets");

            migrationBuilder.DropTable(
                name: "ParameterTypes");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceType");
        }
    }
}
