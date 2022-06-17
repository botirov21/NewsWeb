using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWeb.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfViewers = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), "IT" },
                    { new Guid("87a51b91-c4da-4f42-a7de-266765a13b10"), "Footbal" },
                    { new Guid("a181d36c-c369-4db4-ac35-6ced403c7e4b"), "Global" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Body", "CategoryId", "CreatedTime", "Images", "Links", "NumberOfViewers", "Title" },
                values: new object[,]
                {
                    { new Guid("0544054f-e86f-4f18-b44f-913dc1f5e83b"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6074), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("2899fca1-62e9-4763-a5d9-2be5837a0842"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6069), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("4dd93f72-fa88-48fa-bc36-0e065eef71a7"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6025), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("5da5a8a4-ba2a-4ce1-b3d5-fc112cc35bb4"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6072), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("77963a72-dae5-49d3-9f6b-6945e52a78e8"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6067), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("8b95e8a7-9387-40db-9d53-f0417116a474"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6065), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("dd47e1ff-a2ce-450e-bda0-fdd61ac6e0a6"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6042), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("df6bf6be-6d65-49c1-9be5-0caabcb7cd3b"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6063), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" },
                    { new Guid("f1acd81a-9d32-4a83-bd74-17aeb05cc802"), "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.", new Guid("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"), new DateTime(2022, 6, 16, 22, 27, 14, 949, DateTimeKind.Local).AddTicks(6076), "trending/trending_bottom1.jpg", "", 12, "Today is a good day!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
