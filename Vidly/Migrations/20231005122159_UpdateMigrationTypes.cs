using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrationTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Membershiptype SET Name = 'PayAsYouGo' WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Membershiptype SET Name = 'Monthly' WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Membershiptype SET Name = 'Quaterly' WHERE Id = 3");
            migrationBuilder.Sql("UPDATE Membershiptype SET Name = 'Annual' WHERE Id = 4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
