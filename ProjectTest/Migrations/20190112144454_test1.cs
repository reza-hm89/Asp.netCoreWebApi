using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectTest.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "ClassRoom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_TeacherID",
                table: "ClassRoom",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoom_Teacher_TeacherID",
                table: "ClassRoom",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoom_Teacher_TeacherID",
                table: "ClassRoom");

            migrationBuilder.DropIndex(
                name: "IX_ClassRoom_TeacherID",
                table: "ClassRoom");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "ClassRoom");
        }
    }
}
