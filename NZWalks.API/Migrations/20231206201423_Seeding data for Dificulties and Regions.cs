using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDificultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegionImageUrl",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("976e8fcf-7b8b-4a4e-97a2-2da42f0a34cd"), "Midium" },
                    { new Guid("c1187031-e8e8-43cc-8efa-3baf1d0f47ff"), "Easy" },
                    { new Guid("ee88d05d-241a-4a53-9bea-22fd2748fb0b"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("41dab1dc-af20-4796-9102-0220042e1dfa"), "WGN", "Wellingtion", null },
                    { new Guid("46d53095-ee25-44f2-82ae-6bf7b4c8c92a"), "STL", "Southland", null },
                    { new Guid("48a12772-ff7a-4c80-9037-03d66152f83a"), "NTL", "Northland", null },
                    { new Guid("608edc91-d806-46d6-a3c5-52e068bfeff4"), "NSN", "Nelson", null },
                    { new Guid("c4b91091-ccf6-4734-a6c5-8d2317dd3647"), "AKL", "Auckland", null },
                    { new Guid("d7455aad-6419-4341-87b9-0855064af193"), "BOP", "Bay Of Plenty", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("976e8fcf-7b8b-4a4e-97a2-2da42f0a34cd"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c1187031-e8e8-43cc-8efa-3baf1d0f47ff"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ee88d05d-241a-4a53-9bea-22fd2748fb0b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("41dab1dc-af20-4796-9102-0220042e1dfa"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("46d53095-ee25-44f2-82ae-6bf7b4c8c92a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("48a12772-ff7a-4c80-9037-03d66152f83a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("608edc91-d806-46d6-a3c5-52e068bfeff4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c4b91091-ccf6-4734-a6c5-8d2317dd3647"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d7455aad-6419-4341-87b9-0855064af193"));

            migrationBuilder.AlterColumn<string>(
                name: "RegionImageUrl",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
