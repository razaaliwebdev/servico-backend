using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class servico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

          
         

       

            migrationBuilder.CreateTable(
                name: "servicess",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emirates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    opentime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    closetime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expiry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    catid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    catname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicess", x => x.id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             
           

           

            migrationBuilder.DropTable(
                name: "servicess");

          
        }
    }
}
