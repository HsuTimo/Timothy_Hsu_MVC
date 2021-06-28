using Microsoft.EntityFrameworkCore.Migrations;

namespace Timothy_Hsu_MVC.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScrumStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrumStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScrumUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrumUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScrumTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScrumStatusId = table.Column<int>(type: "int", nullable: false),
                    ScrumUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrumTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScrumTasks_ScrumStatuses_ScrumStatusId",
                        column: x => x.ScrumStatusId,
                        principalTable: "ScrumStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrumTasks_ScrumUsers_ScrumUserId",
                        column: x => x.ScrumUserId,
                        principalTable: "ScrumUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ScrumStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Not Checked Out" },
                    { 2, "Checked Out" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "ScrumUsers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bill" },
                    { 2, "Tim" },
                    { 3, "Alex" }
                });

            migrationBuilder.InsertData(
                table: "ScrumTasks",
                columns: new[] { "Id", "Description", "ScrumStatusId", "ScrumUserId", "Title" },
                values: new object[,]
                {
                    { 1, "Fix bug that causes crash", 1, null, "Fix bug #1235" },
                    { 2, "Fix bug that causes wrong View to be shown", 1, null, "Fix bug #5425" },
                    { 4, "The toilets must be cleaned", 1, null, "Clean toilets" },
                    { 3, "Write new code for new feature", 2, 1, "Implement new feature" },
                    { 5, "Buy a new laptop for our new employee", 3, 3, "Buy a new laptop" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScrumTasks_ScrumStatusId",
                table: "ScrumTasks",
                column: "ScrumStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScrumTasks_ScrumUserId",
                table: "ScrumTasks",
                column: "ScrumUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScrumTasks");

            migrationBuilder.DropTable(
                name: "ScrumStatuses");

            migrationBuilder.DropTable(
                name: "ScrumUsers");
        }
    }
}
