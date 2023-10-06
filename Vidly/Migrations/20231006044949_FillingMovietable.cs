using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class FillingMovietable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Hangover','02-06-2009','01-01-2019',4,2)");
            migrationBuilder.Sql("INSERT INTO Movies(Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES ('Taken','07-02-2008','01-05-2019',10,1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
