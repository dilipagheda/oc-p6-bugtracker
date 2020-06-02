using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueStatusList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatusList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OSName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOSVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    OperatingSystemId = table.Column<int>(nullable: false),
                    VersionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOSVersions", x => x.Id);
                    table.UniqueConstraint("AK_ProductOSVersions_ProductId_OperatingSystemId_VersionId", x => new { x.ProductId, x.OperatingSystemId, x.VersionId });
                    table.ForeignKey(
                        name: "FK_ProductOSVersions_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalTable: "OperatingSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOSVersions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOSVersions_Versions_VersionId",
                        column: x => x.VersionId,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductOSVersionId = table.Column<int>(nullable: false),
                    IssueStatusId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Resolution = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ResolutionDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_IssueStatusList_IssueStatusId",
                        column: x => x.IssueStatusId,
                        principalTable: "IssueStatusList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issues_ProductOSVersions_ProductOSVersionId",
                        column: x => x.ProductOSVersionId,
                        principalTable: "ProductOSVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IssueStatusList",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "In Progress" },
                    { 3, "Resolved" },
                    { 4, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "OperatingSystems",
                columns: new[] { "Id", "OSName" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "Linux" },
                    { 3, "MacOS" },
                    { 4, "Android" },
                    { 5, "iOS" },
                    { 6, "Windows Mobile" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ProductName" },
                values: new object[,]
                {
                    { 36, "Licensed Fresh Cheese" },
                    { 35, "Generic Plastic Bacon" },
                    { 34, "Generic Steel Soap" },
                    { 33, "Licensed Granite Chips" },
                    { 28, "Tasty Frozen Ball" },
                    { 31, "Awesome Frozen Chicken" },
                    { 30, "Incredible Metal Gloves" },
                    { 29, "Awesome Wooden Keyboard" },
                    { 37, "Tasty Concrete Bike" },
                    { 32, "Gorgeous Concrete Keyboard" },
                    { 38, "Awesome Granite Mouse" },
                    { 43, "Sleek Fresh Fish" },
                    { 40, "Ergonomic Granite Mouse" },
                    { 41, "Incredible Concrete Ball" },
                    { 42, "Incredible Frozen Car" },
                    { 27, "Handcrafted Plastic Sausages" },
                    { 44, "Gorgeous Plastic Shoes" },
                    { 46, "Incredible Plastic Soap" },
                    { 47, "Practical Soft Gloves" },
                    { 48, "Fantastic Plastic Hat" },
                    { 49, "Ergonomic Frozen Shirt" },
                    { 50, "Sleek Fresh Mouse" },
                    { 39, "Fantastic Steel Pants" },
                    { 26, "Rustic Frozen Car" },
                    { 45, "Ergonomic Steel Ball" },
                    { 24, "Sleek Frozen Mouse" },
                    { 25, "Ergonomic Steel Shirt" },
                    { 2, "Incredible Fresh Ball" },
                    { 3, "Intelligent Cotton Tuna" },
                    { 4, "Fantastic Cotton Bike" },
                    { 5, "Ergonomic Wooden Tuna" },
                    { 6, "Ergonomic Cotton Chicken" },
                    { 7, "Incredible Fresh Gloves" },
                    { 8, "Awesome Plastic Cheese" },
                    { 9, "Refined Granite Bike" },
                    { 10, "Refined Steel Towels" },
                    { 11, "Small Frozen Chicken" },
                    { 1, "Handmade Frozen Sausages" },
                    { 13, "Ergonomic Concrete Soap" },
                    { 12, "Ergonomic Granite Computer" },
                    { 23, "Sleek Frozen Soap" },
                    { 21, "Small Plastic Pants" },
                    { 20, "Intelligent Granite Gloves" },
                    { 19, "Fantastic Concrete Soap" },
                    { 22, "Ergonomic Plastic Shoes" },
                    { 18, "Unbranded Soft Shirt" },
                    { 17, "Refined Soft Chips" },
                    { 16, "Awesome Rubber Bike" },
                    { 15, "Awesome Plastic Computer" },
                    { 14, "Incredible Granite Mouse" }
                });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "Id", "VersionName" },
                values: new object[,]
                {
                    { 28, "6.7.5.0" },
                    { 29, "0.3.9.7" },
                    { 30, "5.0.9.3" },
                    { 31, "9.9.3.7" },
                    { 32, "6.1.9.6" },
                    { 33, "0.7.6.6" },
                    { 34, "5.1.3.6" },
                    { 35, "8.5.9.1" },
                    { 27, "9.2.0.0" },
                    { 36, "7.3.4.3" },
                    { 42, "0.8.4.8" },
                    { 38, "3.6.7.9" },
                    { 39, "9.1.2.3" },
                    { 40, "5.5.8.8" },
                    { 41, "3.3.9.9" },
                    { 43, "0.3.8.9" },
                    { 44, "1.7.5.5" },
                    { 45, "4.0.8.0" },
                    { 46, "9.9.3.4" },
                    { 47, "9.7.7.3" },
                    { 26, "2.9.3.4" },
                    { 48, "8.9.0.3" },
                    { 37, "9.5.1.9" },
                    { 25, "9.8.5.1" },
                    { 13, "6.2.5.8" },
                    { 23, "1.4.5.1" },
                    { 49, "7.1.8.3" },
                    { 1, "7.7.0.8" },
                    { 2, "3.8.3.3" },
                    { 3, "3.7.3.0" },
                    { 4, "0.7.8.7" },
                    { 5, "4.5.9.0" },
                    { 6, "7.7.6.7" },
                    { 7, "8.9.8.7" },
                    { 8, "2.9.6.9" },
                    { 9, "9.5.4.6" },
                    { 24, "3.2.4.3" },
                    { 10, "4.2.6.4" },
                    { 12, "4.2.3.6" },
                    { 14, "5.7.4.0" },
                    { 15, "0.2.9.4" },
                    { 16, "9.6.0.3" },
                    { 17, "1.3.0.4" },
                    { 18, "2.2.3.2" },
                    { 19, "8.5.1.6" },
                    { 20, "5.0.2.5" },
                    { 21, "5.2.0.9" },
                    { 22, "4.7.4.1" },
                    { 11, "9.0.2.6" },
                    { 50, "3.5.2.0" }
                });

            migrationBuilder.InsertData(
                table: "ProductOSVersions",
                columns: new[] { "Id", "OperatingSystemId", "ProductId", "VersionId" },
                values: new object[,]
                {
                    { 8, 1, 9, 2 },
                    { 31, 2, 22, 31 },
                    { 3, 2, 39, 32 },
                    { 12, 6, 42, 35 },
                    { 33, 2, 12, 35 },
                    { 24, 2, 11, 37 },
                    { 34, 5, 8, 38 },
                    { 11, 6, 9, 39 },
                    { 36, 6, 29, 39 },
                    { 2, 5, 50, 41 },
                    { 46, 2, 10, 41 },
                    { 26, 3, 35, 42 },
                    { 48, 2, 29, 42 },
                    { 1, 2, 6, 45 },
                    { 41, 6, 32, 45 },
                    { 5, 5, 35, 46 },
                    { 16, 4, 25, 46 },
                    { 23, 6, 40, 46 },
                    { 27, 5, 47, 47 },
                    { 38, 6, 22, 47 },
                    { 18, 4, 41, 48 },
                    { 39, 2, 16, 48 },
                    { 13, 2, 5, 31 },
                    { 6, 1, 20, 29 },
                    { 47, 2, 21, 28 },
                    { 4, 6, 35, 28 },
                    { 42, 5, 46, 4 },
                    { 45, 5, 7, 5 },
                    { 15, 2, 35, 6 },
                    { 35, 6, 1, 6 },
                    { 40, 4, 38, 7 },
                    { 10, 6, 1, 9 },
                    { 7, 2, 48, 10 },
                    { 9, 4, 14, 12 },
                    { 43, 4, 6, 12 },
                    { 44, 3, 3, 12 },
                    { 22, 4, 23, 49 },
                    { 19, 6, 43, 13 },
                    { 32, 4, 18, 13 },
                    { 21, 5, 30, 14 },
                    { 49, 1, 27, 15 },
                    { 17, 3, 11, 16 },
                    { 25, 5, 49, 16 },
                    { 50, 1, 35, 16 },
                    { 29, 3, 44, 18 },
                    { 37, 1, 33, 24 },
                    { 14, 1, 8, 25 },
                    { 28, 5, 16, 27 },
                    { 20, 5, 44, 13 },
                    { 30, 6, 41, 50 }
                });

            migrationBuilder.InsertData(
                table: "Issues",
                columns: new[] { "Id", "CreationDate", "Description", "IssueStatusId", "ProductOSVersionId", "Resolution", "ResolutionDate" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 6, 2, 11, 49, 23, 162, DateTimeKind.Local).AddTicks(2499), "Nihil tempore ab ut. In dolor mollitia est. Et ea ea sit maiores. Asperiores totam impedit accusantium itaque architecto. Odio eum sapiente quia eius. Veritatis saepe voluptatibus cumque.", 3, 8, "Iure similique asperiores. Et pariatur dolore eum aut explicabo. Vel omnis soluta in.", new DateTime(2021, 8, 13, 13, 24, 35, 317, DateTimeKind.Local).AddTicks(9925) },
                    { 49, new DateTime(2020, 6, 1, 20, 18, 36, 842, DateTimeKind.Local).AddTicks(2568), "Sunt et molestias nostrum fugit recusandae aut. Non provident cum tenetur veritatis fugiat. Vitae velit consequuntur est est cumque explicabo. Quaerat molestiae dolorem voluptatum dolorum. Rerum alias perspiciatis.", 2, 14, "", null },
                    { 13, new DateTime(2020, 6, 2, 15, 10, 42, 338, DateTimeKind.Local).AddTicks(6220), "Est ad porro amet. Nulla velit accusantium iusto rerum facilis impedit necessitatibus sed. Sit aliquid et qui est consequatur aliquid.", 4, 47, "Ut doloremque aperiam et et maiores aliquam tempora. Molestiae esse voluptates expedita quibusdam iste doloremque fuga fugit. Et expedita fugiat reprehenderit iure. Aliquid accusamus eligendi eveniet qui. Ad eos nulla ducimus reiciendis error. Odit molestiae officia odio magnam totam.", new DateTime(2020, 8, 2, 0, 41, 28, 559, DateTimeKind.Local).AddTicks(2415) },
                    { 3, new DateTime(2020, 6, 2, 19, 10, 18, 590, DateTimeKind.Local).AddTicks(1493), "Nihil vero quidem in. Quas quos voluptatum ipsa blanditiis sequi natus. Itaque cumque veniam. Ea voluptas harum et nihil non laboriosam est molestiae odio.", 1, 6, "", null },
                    { 26, new DateTime(2020, 6, 2, 1, 23, 15, 70, DateTimeKind.Local).AddTicks(3326), "Veritatis nihil debitis eaque. Fugiat in vel aperiam voluptatem ab natus. Quas perspiciatis enim ducimus. Est voluptatum voluptates adipisci ex distinctio iure qui maxime illo.", 3, 31, "Necessitatibus vel et ut laudantium inventore ea dicta. Sint sed exercitationem iure et hic veritatis enim nesciunt dolor. Quaerat voluptatibus et architecto est beatae est expedita. Sequi eum consequatur.", new DateTime(2022, 3, 26, 4, 58, 9, 540, DateTimeKind.Local).AddTicks(5713) },
                    { 15, new DateTime(2020, 6, 2, 2, 47, 18, 795, DateTimeKind.Local).AddTicks(1855), "Non quaerat consequatur asperiores sequi aut sequi et. Aliquid dignissimos quo aut a qui beatae. Eius et doloremque qui. Sunt perferendis voluptas facere cumque dolor voluptas aut. Beatae velit quam eius dolorem. Porro saepe reiciendis.", 2, 3, "", null },
                    { 42, new DateTime(2020, 6, 2, 3, 58, 52, 122, DateTimeKind.Local).AddTicks(1308), "Unde sint quam perspiciatis in. Eum quia minus possimus ut aut voluptatem tempore aliquam. Eum esse ratione aliquam tempora quisquam explicabo animi sit iure. Deleniti ex labore expedita quisquam quia cupiditate autem vel. Natus molestiae quia cupiditate repudiandae nisi id nobis non vitae. Quam veritatis aut illum dolores minus explicabo eum nihil illum.", 1, 12, "", null },
                    { 37, new DateTime(2020, 6, 1, 21, 25, 51, 747, DateTimeKind.Local).AddTicks(4961), "Aut est a. Omnis libero aspernatur magnam corrupti nobis rem. Et magnam sit quia. Magnam repellat nisi. Quisquam quod non et eum.", 4, 33, "Possimus saepe dolores non. Est ut labore incidunt. Repudiandae autem culpa omnis quod recusandae sunt est. Laborum optio sit qui omnis quaerat.", new DateTime(2021, 4, 17, 3, 3, 14, 910, DateTimeKind.Local).AddTicks(5682) },
                    { 1, new DateTime(2020, 6, 2, 3, 35, 35, 911, DateTimeKind.Local).AddTicks(5443), "Quisquam accusamus explicabo tempora ipsa qui numquam. Deserunt eligendi ut exercitationem dolorem fugiat consequuntur. Magni laboriosam nostrum deserunt inventore aut veritatis qui voluptas temporibus. Culpa recusandae quod repellat similique qui. Consequatur voluptatem quia qui consequatur.", 2, 24, "", null },
                    { 14, new DateTime(2020, 6, 2, 15, 11, 35, 965, DateTimeKind.Local).AddTicks(1121), "Eius consequatur accusantium aut ut delectus earum ut. Quis optio magnam aut aut odio. Consequatur vero porro laboriosam iure est ut. Voluptatem vitae necessitatibus impedit. Doloribus laboriosam et. Odio temporibus animi illum odit cum tenetur.", 3, 24, "Nulla numquam culpa et nemo quia. Ratione quam dolor. Laborum et est qui aut.", new DateTime(2021, 2, 2, 9, 57, 25, 60, DateTimeKind.Local).AddTicks(9143) },
                    { 21, new DateTime(2020, 6, 1, 23, 58, 10, 294, DateTimeKind.Local).AddTicks(2692), "Sit in aspernatur non qui asperiores sunt. Vero numquam minima ut at. Fugit doloribus blanditiis. Perferendis sit vel aut nesciunt.", 2, 36, "", null },
                    { 30, new DateTime(2020, 6, 1, 23, 2, 10, 645, DateTimeKind.Local).AddTicks(3762), "Ut possimus dolor impedit omnis velit quod recusandae ipsam. Quo aperiam sed dolores debitis pariatur quia. Et sed esse quis voluptas et. Quo cupiditate voluptatem aut veniam est ea consequuntur sunt. Molestiae error voluptates error. Ipsa ea animi in.", 2, 36, "", null },
                    { 36, new DateTime(2020, 6, 2, 3, 44, 12, 808, DateTimeKind.Local).AddTicks(4971), "Nisi iusto sit saepe soluta omnis. Sit et illo facere occaecati laborum ducimus asperiores et at. Fuga non eligendi molestiae. Corrupti error vero maiores fuga culpa eveniet aperiam et.", 4, 48, "Accusamus aut et quo occaecati dolorum non ipsam. Voluptatum ipsam sed aliquid asperiores sapiente corporis sint quia. Quasi quaerat officiis enim. Sunt eveniet voluptate ut iure a doloribus facere. Commodi consequatur vel ea aut.", new DateTime(2021, 7, 12, 3, 57, 28, 496, DateTimeKind.Local).AddTicks(1953) },
                    { 39, new DateTime(2020, 6, 2, 18, 47, 7, 997, DateTimeKind.Local).AddTicks(7651), "Labore libero sit magni esse eligendi aut ipsa. Temporibus excepturi est. Sunt necessitatibus consequatur ad laboriosam soluta.", 2, 48, "", null },
                    { 44, new DateTime(2020, 6, 2, 0, 9, 55, 382, DateTimeKind.Local).AddTicks(9186), "Qui sint facere rem. Excepturi voluptas minima voluptatem at aut rerum quas. Vel velit architecto eaque nesciunt molestiae consequatur adipisci in.", 2, 48, "", null },
                    { 10, new DateTime(2020, 6, 2, 2, 48, 18, 488, DateTimeKind.Local).AddTicks(1133), "Explicabo voluptas ducimus iure tempore fugit dolorem omnis. Dolor sint delectus nobis a sit. Dolorem voluptatem dolor excepturi quibusdam aut nihil ut ut. Maxime doloribus impedit.", 1, 5, "", null },
                    { 19, new DateTime(2020, 6, 2, 11, 4, 20, 721, DateTimeKind.Local).AddTicks(5005), "Pariatur ratione dolorem recusandae dolore unde magnam. Numquam animi id consequuntur placeat eum alias ut. Enim vel dicta occaecati mollitia quam. Qui voluptatem nulla quam esse aut vel saepe in.", 3, 16, "Asperiores repudiandae voluptatem. Autem vitae fuga consectetur omnis voluptatem neque. In et sit aut. Aut placeat fugit. Dolore non ipsam quis rerum assumenda consequatur aut et omnis. Qui libero aut laboriosam eligendi harum consequuntur consequatur.", new DateTime(2020, 11, 9, 7, 35, 26, 426, DateTimeKind.Local).AddTicks(9788) },
                    { 45, new DateTime(2020, 6, 2, 6, 38, 34, 209, DateTimeKind.Local).AddTicks(8637), "Cumque soluta sed dolor harum qui numquam autem facere velit. Est cum nobis est repellendus amet repellat ex voluptatibus aut. Quae qui aliquid aut dicta fugiat unde illum.", 3, 23, "Nihil enim non enim quia. Est maxime ut eos distinctio voluptate. Deleniti totam ut rerum libero maxime id nisi. Sit et rerum. Et quaerat itaque sit. Fugit officia voluptatibus.", new DateTime(2022, 2, 16, 13, 13, 28, 655, DateTimeKind.Local).AddTicks(9676) },
                    { 7, new DateTime(2020, 6, 2, 19, 17, 45, 24, DateTimeKind.Local).AddTicks(8885), "Quae mollitia officiis accusantium sunt veritatis iusto ullam veniam. Aliquid non officiis laudantium. Dolorem vel consequatur aliquid nam. Recusandae quas est numquam sed vel. Cumque ea alias. Sed qui dolores inventore molestiae doloremque assumenda quod nostrum culpa.", 3, 27, "Accusamus tempora sequi. Voluptas autem voluptas voluptatem est quos. Officiis occaecati mollitia iusto. Ducimus et ut expedita. Inventore eos et qui debitis. Laboriosam libero iusto tenetur at fugiat illum consectetur et.", new DateTime(2020, 10, 28, 19, 39, 48, 232, DateTimeKind.Local).AddTicks(9202) },
                    { 35, new DateTime(2020, 6, 2, 17, 27, 36, 835, DateTimeKind.Local).AddTicks(6461), "Ratione dolorum impedit molestiae quisquam veritatis nihil incidunt blanditiis quia. Veniam illo esse sint dicta aut vero. Aut veniam eius corporis non. Voluptate earum architecto labore quos et mollitia architecto et nisi. Non distinctio non quibusdam fugit debitis voluptatibus sint.", 1, 18, "", null },
                    { 5, new DateTime(2020, 6, 2, 17, 7, 5, 354, DateTimeKind.Local).AddTicks(7196), "Maxime nisi ratione voluptatem repellat atque ut reiciendis enim optio. Et consequatur et. Iste distinctio sit est qui dolor consequatur magnam expedita. Iste iure recusandae minima sed qui.", 2, 22, "", null },
                    { 38, new DateTime(2020, 6, 2, 17, 46, 18, 207, DateTimeKind.Local).AddTicks(5752), "Dolor ab debitis dolores ut. Eum qui voluptates blanditiis corrupti dignissimos ea magnam. Est ducimus repellat et nihil. Iusto autem est.", 2, 22, "", null },
                    { 29, new DateTime(2020, 6, 2, 17, 53, 6, 974, DateTimeKind.Local).AddTicks(5012), "Dolor quibusdam ipsam facere sed voluptatibus nobis tenetur minima. Molestias maiores sunt atque. Sint itaque magni amet maxime. Laboriosam omnis dolor laboriosam sint qui illum. Odio est corrupti odit.", 1, 14, "", null },
                    { 47, new DateTime(2020, 6, 2, 8, 58, 51, 952, DateTimeKind.Local).AddTicks(8923), "Deserunt reprehenderit recusandae fugit et vel molestias ducimus. Distinctio doloremque aspernatur accusamus nostrum quos accusantium impedit esse aut. Laudantium ipsam rerum est omnis accusamus harum beatae perspiciatis.", 3, 17, "Voluptate sunt magni quod eum in sit perspiciatis aut qui. Illo est veritatis. Minima laborum voluptates.", new DateTime(2022, 1, 8, 2, 55, 8, 874, DateTimeKind.Local).AddTicks(1082) },
                    { 2, new DateTime(2020, 6, 2, 18, 33, 15, 739, DateTimeKind.Local).AddTicks(3604), "Deserunt similique et velit dolorum quibusdam qui excepturi. Quia fugit vel eligendi iusto est iusto. Consequatur non ea odit qui et neque sint. Odio nobis debitis animi esse officia rem delectus. Veniam eum laudantium.", 4, 17, "Nostrum porro sed et. Laboriosam quia dolores consequatur sapiente praesentium sint consequatur cumque laudantium. Doloremque quidem animi pariatur eligendi. Quo voluptates laudantium aut facere unde ut qui. Voluptatem incidunt non aut quae.", new DateTime(2021, 10, 3, 7, 23, 18, 135, DateTimeKind.Local).AddTicks(7703) },
                    { 50, new DateTime(2020, 6, 2, 8, 3, 3, 839, DateTimeKind.Local).AddTicks(9881), "Qui quia iure aspernatur. Laboriosam nisi dolorum iste aut nostrum repellat temporibus porro at. Est architecto deleniti id libero. Molestias voluptas ea quis impedit quam quas natus molestiae.", 3, 49, "Laborum et ullam officia autem facere rerum quidem officiis sit. Dolorum aliquam ipsum voluptatem. Sint saepe asperiores in magnam. Nostrum praesentium amet quam quae non dolores enim explicabo.", new DateTime(2021, 2, 20, 2, 54, 2, 539, DateTimeKind.Local).AddTicks(5828) },
                    { 33, new DateTime(2020, 6, 2, 4, 0, 12, 334, DateTimeKind.Local).AddTicks(4434), "Cum magni deserunt consequatur qui delectus voluptatem. Nemo beatae exercitationem et. Quia dolorum quo. Quia nihil aperiam.", 3, 8, "Aut quia in aut velit sint ab est iste. Quia et consequuntur accusantium. Quia impedit quae. Nesciunt qui velit maiores nobis consequuntur nostrum. Ipsa impedit assumenda a distinctio.", new DateTime(2021, 6, 24, 9, 59, 42, 307, DateTimeKind.Local).AddTicks(6197) },
                    { 12, new DateTime(2020, 6, 2, 7, 4, 2, 920, DateTimeKind.Local).AddTicks(990), "Non est quaerat ut qui voluptatibus. Porro consequatur mollitia excepturi aliquid repudiandae voluptas. Illo reprehenderit et rerum necessitatibus occaecati fugiat placeat.", 4, 42, "Nostrum fuga perspiciatis sed nam quis quo quasi eaque. Autem earum iure quam sed consequatur. Vel et quis atque. Dolor debitis veritatis enim accusamus necessitatibus. Sint error fuga dolores. Et ad quia necessitatibus repellendus necessitatibus.", new DateTime(2021, 1, 10, 19, 57, 18, 291, DateTimeKind.Local).AddTicks(7246) },
                    { 9, new DateTime(2020, 6, 2, 6, 11, 57, 999, DateTimeKind.Local).AddTicks(8536), "Expedita voluptate dignissimos iusto molestiae in odit aut molestiae rem. Quam molestiae harum tempora ipsam qui sed quis delectus. Pariatur cumque ut. Quam eum sed ea.", 4, 45, "Commodi mollitia animi totam et officiis. Facere minus necessitatibus dolorem aspernatur est non. Pariatur magnam aliquid eum est officia dolore consectetur natus eum.", new DateTime(2021, 7, 8, 2, 29, 13, 194, DateTimeKind.Local).AddTicks(1654) },
                    { 22, new DateTime(2020, 6, 2, 11, 0, 3, 711, DateTimeKind.Local).AddTicks(6425), "Totam minus id. Totam est tempore dolor vero voluptas est eum aut inventore. Provident dolor incidunt quia sapiente fugiat quo aperiam dolor.", 4, 45, "Ut iure dignissimos est atque. Numquam quas neque nisi enim adipisci et quidem accusamus quo. Inventore quidem incidunt. Odio doloribus autem quibusdam ut maxime sint.", new DateTime(2020, 11, 25, 20, 39, 22, 565, DateTimeKind.Local).AddTicks(8929) },
                    { 20, new DateTime(2020, 6, 2, 15, 19, 13, 428, DateTimeKind.Local).AddTicks(2819), "Sed modi nihil fugiat non labore. Voluptas unde ipsa cumque. Ratione esse temporibus omnis ut et quaerat enim sunt. Necessitatibus necessitatibus qui illo. Voluptas corrupti quis est et.", 3, 35, "Cupiditate quaerat at. Laboriosam ratione distinctio perspiciatis dolores tenetur est. Optio illo ea nostrum sit.", new DateTime(2020, 12, 2, 10, 17, 15, 664, DateTimeKind.Local).AddTicks(9077) },
                    { 24, new DateTime(2020, 6, 1, 21, 22, 35, 307, DateTimeKind.Local).AddTicks(6165), "Sapiente optio quia. Ex ipsa et et neque unde omnis. Velit esse odio soluta eius aut et voluptas nobis. Blanditiis tempora impedit aut omnis. Reprehenderit dignissimos illum aliquam et laborum voluptas vel vero. Laborum asperiores aliquid.", 1, 10, "", null },
                    { 34, new DateTime(2020, 6, 1, 22, 4, 42, 122, DateTimeKind.Local).AddTicks(4135), "Adipisci aut et temporibus tempora unde reprehenderit expedita molestiae esse. Fugit ipsa cumque adipisci. Voluptatem cum est eum quos ad et. Non vero sed. Iusto quia atque. Impedit aspernatur fuga a.", 2, 10, "", null },
                    { 43, new DateTime(2020, 6, 1, 19, 31, 31, 807, DateTimeKind.Local).AddTicks(7028), "Reiciendis quia voluptatibus. Rem alias dolor qui veritatis. Porro rerum fugit quis iste veritatis quaerat voluptatem sit nemo. Illo possimus temporibus facere eveniet iste magnam non quisquam deleniti.", 3, 10, "Dolores aspernatur dolore aut id aut dignissimos itaque dolorem. Accusantium minus enim autem ea sint. Corporis aut veritatis exercitationem et voluptas modi rem molestiae. Reprehenderit dolor aperiam id consequuntur quia veritatis pariatur quidem iusto.", new DateTime(2021, 3, 24, 17, 35, 2, 187, DateTimeKind.Local).AddTicks(9170) },
                    { 27, new DateTime(2020, 6, 2, 16, 48, 9, 117, DateTimeKind.Local).AddTicks(1149), "Possimus dolorem autem nemo est. Accusantium accusamus aut deserunt similique doloribus velit. Ipsum aut nisi. Aut quia totam. Est dolorem inventore. Expedita aut ut accusantium sed corporis molestiae id.", 4, 7, "Soluta rerum ea reprehenderit sed non eos nobis id qui. Quidem sint voluptatum sequi corrupti nulla recusandae eaque eius. Suscipit accusamus aliquid eius et sed sunt occaecati perspiciatis eveniet. Distinctio et qui et.", new DateTime(2020, 10, 14, 22, 49, 36, 318, DateTimeKind.Local).AddTicks(4223) },
                    { 40, new DateTime(2020, 6, 1, 19, 47, 20, 990, DateTimeKind.Local).AddTicks(470), "Et quaerat nisi cum voluptatem facere. Libero ut aspernatur tempore repellendus nemo ipsam. Iste nesciunt est sit quia odit sit qui ut corrupti. Odit est ut quibusdam qui aliquam et minus voluptatum nesciunt.", 1, 7, "", null },
                    { 41, new DateTime(2020, 6, 1, 22, 2, 53, 520, DateTimeKind.Local).AddTicks(8060), "Nulla nisi voluptas esse. Et sapiente aliquid. Beatae quos et. Nisi quidem cum asperiores.", 2, 22, "", null },
                    { 4, new DateTime(2020, 6, 1, 21, 29, 50, 599, DateTimeKind.Local).AddTicks(5518), "Sit ullam pariatur nesciunt veritatis rerum enim magni. Omnis placeat libero id in. Et quas qui. Repellendus suscipit qui sit.", 3, 9, "Vel laboriosam sed corporis minima quia. Sit iure quia quis magni voluptatem voluptate repellat nisi. Sit dolorem facere et.", new DateTime(2021, 9, 29, 0, 20, 7, 737, DateTimeKind.Local).AddTicks(9423) },
                    { 32, new DateTime(2020, 6, 2, 7, 23, 15, 818, DateTimeKind.Local).AddTicks(3739), "Fugit labore voluptatum at nihil. Sed suscipit perferendis molestiae nihil quos veniam. Non architecto numquam earum.", 3, 9, "Distinctio voluptatum molestias aliquam a fuga magnam quia aliquid. Repellendus autem aliquam exercitationem in nesciunt aut. Qui et possimus nihil repellat expedita unde ex nihil. Nemo molestiae et nostrum molestias aperiam consequatur quas earum doloremque. Magnam vero quia expedita fugit. Ut nisi modi qui aliquam et.", new DateTime(2021, 1, 15, 11, 18, 34, 729, DateTimeKind.Local).AddTicks(9702) },
                    { 18, new DateTime(2020, 6, 2, 4, 41, 48, 577, DateTimeKind.Local).AddTicks(4765), "Ut odio earum nesciunt est consequatur dolorem. Soluta sit aliquam reprehenderit ratione repellendus et quia. Animi velit a non. Non dolorum id ad et perspiciatis totam. Accusamus sunt dolore placeat debitis magnam aut amet et qui. Sunt ullam repellat nemo ipsam sit voluptatem minus commodi.", 4, 44, "Saepe dignissimos molestias sed quia beatae culpa facere expedita. Possimus non perspiciatis sit enim facere vero impedit tenetur eum. Rerum ab ea quam est tenetur ut voluptatem blanditiis. Incidunt voluptatibus sit. Impedit deleniti recusandae dolorem corrupti voluptates sint.", new DateTime(2021, 7, 7, 17, 13, 24, 146, DateTimeKind.Local).AddTicks(2140) },
                    { 11, new DateTime(2020, 6, 2, 16, 2, 25, 756, DateTimeKind.Local).AddTicks(1564), "Sed eveniet accusamus consequatur ducimus. Eos enim molestiae et voluptatem. Id officiis aspernatur non.", 2, 20, "", null },
                    { 23, new DateTime(2020, 6, 2, 17, 50, 26, 202, DateTimeKind.Local).AddTicks(7806), "Facilis illum eius sint maxime quo beatae est et nisi. Aut quae voluptas aut corrupti sit ex totam consequatur. Nulla et et beatae. Et ut aperiam. Expedita perspiciatis est qui illo eos itaque omnis sapiente.", 4, 20, "Magnam ullam voluptatem voluptatem nemo et laudantium. Est ea veritatis. Ad dolor iure delectus est. Voluptatem aut iusto error nobis sint quia quia facere optio. Nesciunt quasi impedit eos ut id ut ut aut et. Ea totam provident eum quaerat.", new DateTime(2021, 9, 6, 17, 5, 5, 322, DateTimeKind.Local).AddTicks(8684) },
                    { 25, new DateTime(2020, 6, 2, 16, 59, 56, 364, DateTimeKind.Local).AddTicks(8565), "Officia sunt inventore dolorem velit et distinctio velit recusandae et. Ipsum blanditiis aperiam accusantium nam. Quidem id doloribus. Nostrum sit dolores officiis dolores tempora quas et labore. Quis omnis vel ut hic illo blanditiis id.", 4, 20, "Itaque cupiditate fugit minima aut. Ut neque voluptatem. Et voluptatibus rerum eum quos est sint quisquam.", new DateTime(2021, 11, 17, 11, 1, 27, 249, DateTimeKind.Local).AddTicks(5275) },
                    { 28, new DateTime(2020, 6, 2, 15, 10, 14, 3, DateTimeKind.Local).AddTicks(8818), "Aut consectetur repellendus qui dolores. Omnis cumque vitae quos facilis odit animi quia quod eos. Illo fuga dolore et necessitatibus ab ut hic.", 2, 20, "", null },
                    { 16, new DateTime(2020, 6, 1, 20, 6, 12, 650, DateTimeKind.Local).AddTicks(1272), "Omnis recusandae ratione vero debitis. Quo quaerat quod enim. Est autem sequi in.", 1, 32, "", null },
                    { 46, new DateTime(2020, 6, 2, 8, 20, 35, 901, DateTimeKind.Local).AddTicks(9458), "Modi quam possimus consequuntur iusto veritatis nesciunt. Sunt qui aut eos minus. Hic molestias est enim similique alias laudantium dolorem. Optio veritatis nesciunt qui dolore omnis et aut quis. Et id occaecati optio eos dolorem.", 3, 32, "Maiores et iste impedit. Fugit perspiciatis necessitatibus sapiente repudiandae provident voluptatem et magnam voluptas. Maiores et accusantium repudiandae doloremque quidem. Eum eum inventore vel dolorem itaque blanditiis. Voluptatem optio dolores repellendus nesciunt. Quis iusto et laudantium dolor dicta libero illum.", new DateTime(2021, 7, 1, 20, 5, 28, 894, DateTimeKind.Local).AddTicks(5335) },
                    { 6, new DateTime(2020, 6, 2, 11, 30, 16, 78, DateTimeKind.Local).AddTicks(5417), "Deleniti vero facere. Inventore distinctio ex corporis sequi quo odio consectetur tempore qui. Nemo illum debitis et deleniti.", 4, 21, "Laborum animi libero. Molestiae voluptatem non consequatur totam. Aut sunt et laudantium expedita aspernatur corrupti placeat. Vel explicabo corrupti qui dignissimos aspernatur aperiam optio id.", new DateTime(2022, 5, 10, 0, 24, 30, 86, DateTimeKind.Local).AddTicks(4214) },
                    { 17, new DateTime(2020, 6, 1, 22, 55, 42, 587, DateTimeKind.Local).AddTicks(8532), "Commodi quidem laudantium. Asperiores repellat sint quia blanditiis nulla dolorem est. Libero beatae illum iste voluptatem rerum. Dolores qui blanditiis voluptatem maiores eos quis error quos. Quia est consequatur et voluptatibus quia rem ea.", 2, 49, "", null },
                    { 31, new DateTime(2020, 6, 2, 11, 42, 47, 921, DateTimeKind.Local).AddTicks(2302), "Aliquam sed enim id aliquam et nobis. Enim tenetur itaque rerum porro illo doloremque autem nemo et. Reiciendis qui veniam. Debitis odit dolores aut nobis. Voluptas mollitia sint aut velit.", 1, 9, "", null },
                    { 48, new DateTime(2020, 6, 2, 4, 12, 20, 414, DateTimeKind.Local).AddTicks(4579), "Vel dolor velit et. Voluptas excepturi aspernatur eaque et vitae. Dolor assumenda similique aliquam et dolores eum vel magnam minima. Dolore error error dolor et ut repudiandae. Qui aliquam nobis deleniti. Dolorem vitae sit quia suscipit.", 1, 22, "", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueStatusId",
                table: "Issues",
                column: "IssueStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProductOSVersionId",
                table: "Issues",
                column: "ProductOSVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOSVersions_OperatingSystemId",
                table: "ProductOSVersions",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOSVersions_VersionId",
                table: "ProductOSVersions",
                column: "VersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "IssueStatusList");

            migrationBuilder.DropTable(
                name: "ProductOSVersions");

            migrationBuilder.DropTable(
                name: "OperatingSystems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Versions");
        }
    }
}
