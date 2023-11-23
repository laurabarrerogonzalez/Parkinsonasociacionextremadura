using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gallery1",
                columns: table => new
                {
                    Id_gallery1 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery1", x => x.Id_gallery1);
                });

            migrationBuilder.CreateTable(
                name: "Gallery2",
                columns: table => new
                {
                    Id_gallery2 = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery2", x => x.Id_gallery2);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id_Members = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    holder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    members = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id_Members);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id_News = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id_News);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id_Resources = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id_Resources);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_Users = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_Users);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id_Volunteers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id_Volunteers);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id_Works = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    positions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    archive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    termsAccepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id_Works);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery1");

            migrationBuilder.DropTable(
                name: "Gallery2");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
