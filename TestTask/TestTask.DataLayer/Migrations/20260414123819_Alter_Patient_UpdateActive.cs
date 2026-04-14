using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Alter_Patient_UpdateActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveTemp",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.Sql(
                @"
                    UPDATE Persons 
                    SET ActiveTemp = CASE 
                        WHEN Active = 1 THEN 1 
                        ELSE 0 
                    END");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Persons");
            
            migrationBuilder.RenameColumn(
                name: "ActiveTemp",
                table: "Persons",
                newName: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveOld",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(
                @"
                    UPDATE Persons 
                    SET ActiveOld = CASE 
                        WHEN Active = 1 THEN 1 
                        ELSE 0 
                    END");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "ActiveOld",
                table: "Persons",
                newName: "Active");
        }
    }
}
