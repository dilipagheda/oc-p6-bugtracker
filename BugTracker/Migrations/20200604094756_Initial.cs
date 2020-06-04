using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BugTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "IssueStatusList",
                                         columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Status = table.Column<string>(nullable: true)
            },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_IssueStatusList", x => x.Id);
                                         });

            migrationBuilder.CreateTable(name: "OperatingSystems",
                                         columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                OSName = table.Column<string>(nullable: true)
            },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_OperatingSystems", x => x.Id);
                                         });

            migrationBuilder.CreateTable(name: "Products",
                                         columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                ProductName = table.Column<string>(nullable: true)
            },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Products", x => x.Id);
                                         });

            migrationBuilder.CreateTable(name: "Versions",
                                         columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                VersionName = table.Column<string>(nullable: true)
            },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_Versions", x => x.Id);
                                         });

            migrationBuilder.CreateTable(name: "ProductOSVersions",
                                         columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                ProductId = table.Column<int>(nullable: false),
                OperatingSystemId = table.Column<int>(nullable: false),
                VersionId = table.Column<int>(nullable: false)
            },
                                         constraints: table =>
                                         {
                                             table.PrimaryKey("PK_ProductOSVersions", x => x.Id);
                                             table.UniqueConstraint("AK_ProductOSVersions_ProductId_OperatingSystemId_VersionId",
                                                                    x => new
                                             {
                                                 x.ProductId,
                                                 x.OperatingSystemId,
                                                 x.VersionId
                                             });
                                             table.ForeignKey(name: "FK_ProductOSVersions_OperatingSystems_OperatingSystemId",
                                                              column: x => x.OperatingSystemId,
                                                              principalTable: "OperatingSystems",
                                                              principalColumn: "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(name: "FK_ProductOSVersions_Products_ProductId",
                                                              column: x => x.ProductId,
                                                              principalTable: "Products",
                                                              principalColumn: "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(name: "FK_ProductOSVersions_Versions_VersionId",
                                                              column: x => x.VersionId,
                                                              principalTable: "Versions",
                                                              principalColumn: "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            migrationBuilder.CreateTable(name: "Issues",
                                         columns: table => new
            {
                Id = table.Column<int>(nullable: false).Annotation("SqlServer:Identity", "1, 1"),
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
                                             table.ForeignKey(name: "FK_Issues_IssueStatusList_IssueStatusId",
                                                              column: x => x.IssueStatusId,
                                                              principalTable: "IssueStatusList",
                                                              principalColumn: "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                             table.ForeignKey(name: "FK_Issues_ProductOSVersions_ProductOSVersionId",
                                                              column: x => x.ProductOSVersionId,
                                                              principalTable: "ProductOSVersions",
                                                              principalColumn: "Id",
                                                              onDelete: ReferentialAction.Cascade);
                                         });

            //Create Stored Procedures
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames =
                        assembly.GetManifestResourceNames().Where(str => str.EndsWith(".sql"));
            foreach(string resourceName in resourceNames)
            {
                Console.WriteLine(resourceName);
                using(Stream stream = assembly.GetManifestResourceStream(resourceName))
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        string sql = reader.ReadToEnd();
                        migrationBuilder.Sql(sql);
                    }
            }

            migrationBuilder.InsertData(table: "IssueStatusList",
                                        columns: new[]
                { "Id", "Status" },
                                        values: new object[,]
                { { 1, "Created" }, { 2, "In Progress" }, { 3, "Resolved" }, { 4, "Closed" } });

            migrationBuilder.InsertData(table: "OperatingSystems",
                                        columns: new[]
                { "Id", "OSName" },
                                        values: new object[,]
                {
            { 1, "Windows" },
            { 2, "Linux" },
            { 3, "MacOS" },
            { 4, "Android" },
            { 5, "iOS" },
            { 6, "Windows Mobile" }
                });

            migrationBuilder.InsertData(table: "Products",
                                        columns: new[]
                { "Id", "ProductName" },
                                        values: new object[,]
                {
            { 36, "Gorgeous Cotton Tuna" },
            { 35, "Rustic Plastic Hat" },
            { 34, "Incredible Concrete Bike" },
            { 33, "Ergonomic Fresh Pizza" },
            { 28, "Handcrafted Frozen Shirt" },
            { 31, "Sleek Frozen Shoes" },
            { 30, "Intelligent Granite Fish" },
            { 29, "Practical Metal Hat" },
            { 37, "Handmade Plastic Ball" },
            { 32, "Generic Rubber Table" },
            { 38, "Gorgeous Concrete Mouse" },
            { 43, "Handcrafted Wooden Chair" },
            { 40, "Ergonomic Fresh Gloves" },
            { 41, "Small Steel Soap" },
            { 42, "Ergonomic Frozen Sausages" },
            { 27, "Gorgeous Soft Pizza" },
            { 44, "Small Soft Tuna" },
            { 46, "Generic Granite Tuna" },
            { 47, "Refined Concrete Gloves" },
            { 48, "Unbranded Granite Mouse" },
            { 49, "Sleek Plastic Tuna" },
            { 50, "Incredible Granite Bacon" },
            { 39, "Rustic Soft Car" },
            { 26, "Unbranded Granite Hat" },
            { 45, "Handcrafted Frozen Shoes" },
            { 24, "Practical Fresh Mouse" },
            { 25, "Handmade Rubber Shoes" },
            { 2, "Rustic Plastic Chips" },
            { 3, "Handmade Plastic Mouse" },
            { 4, "Unbranded Plastic Soap" },
            { 5, "Unbranded Plastic Fish" },
            { 6, "Incredible Rubber Table" },
            { 7, "Awesome Frozen Shoes" },
            { 8, "Licensed Cotton Keyboard" },
            { 9, "Intelligent Concrete Soap" },
            { 10, "Handmade Soft Salad" },
            { 11, "Refined Soft Pants" },
            { 1, "Awesome Concrete Chicken" },
            { 13, "Practical Cotton Chicken" },
            { 12, "Licensed Granite Ball" },
            { 23, "Intelligent Wooden Cheese" },
            { 21, "Fantastic Steel Hat" },
            { 20, "Awesome Frozen Car" },
            { 19, "Gorgeous Soft Cheese" },
            { 22, "Incredible Steel Hat" },
            { 18, "Rustic Concrete Mouse" },
            { 17, "Licensed Cotton Table" },
            { 16, "Sleek Plastic Sausages" },
            { 15, "Intelligent Fresh Pizza" },
            { 14, "Tasty Cotton Soap" }
                });

            migrationBuilder.InsertData(table: "Versions",
                                        columns: new[]
                { "Id", "VersionName" },
                                        values: new object[,]
                {
            { 28, "3.7.7.8" },
            { 29, "4.5.3.8" },
            { 30, "4.7.7.3" },
            { 31, "3.9.7.3" },
            { 32, "7.9.9.1" },
            { 33, "9.8.8.7" },
            { 34, "9.4.6.9" },
            { 35, "0.9.9.7" },
            { 27, "8.1.7.0" },
            { 36, "2.7.3.8" },
            { 42, "8.0.9.9" },
            { 38, "1.6.2.1" },
            { 39, "7.6.0.4" },
            { 40, "0.3.1.9" },
            { 41, "2.5.1.5" },
            { 43, "9.3.8.5" },
            { 44, "8.9.1.6" },
            { 45, "6.9.4.5" },
            { 46, "2.9.9.2" },
            { 47, "5.7.9.2" },
            { 26, "3.8.7.8" },
            { 48, "3.2.8.6" },
            { 37, "8.1.6.0" },
            { 25, "9.4.0.4" },
            { 13, "6.8.6.3" },
            { 23, "6.6.0.1" },
            { 49, "8.0.5.6" },
            { 1, "3.9.0.5" },
            { 2, "3.2.6.0" },
            { 3, "4.5.5.2" },
            { 4, "6.6.5.6" },
            { 5, "5.2.7.5" },
            { 6, "2.4.2.6" },
            { 7, "0.1.5.4" },
            { 8, "5.6.2.3" },
            { 9, "6.2.6.7" },
            { 24, "5.4.5.7" },
            { 10, "5.1.6.2" },
            { 12, "6.0.2.7" },
            { 14, "5.9.6.9" },
            { 15, "7.4.5.1" },
            { 16, "6.2.4.7" },
            { 17, "2.1.6.3" },
            { 18, "0.7.0.4" },
            { 19, "6.5.5.8" },
            { 20, "1.9.9.9" },
            { 21, "8.7.7.7" },
            { 22, "9.9.8.7" },
            { 11, "9.4.2.2" },
            { 50, "6.7.9.7" }
                });

            migrationBuilder.InsertData(table: "ProductOSVersions",
                                        columns: new[]
                { "Id", "OperatingSystemId", "ProductId", "VersionId" },
                                        values: new object[,]
                {
            { 45, 6, 14, 2 },
            { 38, 1, 19, 29 },
            { 43, 4, 27, 29 },
            { 12, 2, 36, 30 },
            { 37, 6, 44, 30 },
            { 20, 2, 18, 31 },
            { 34, 5, 22, 31 },
            { 5, 4, 44, 33 },
            { 9, 2, 25, 33 },
            { 30, 1, 16, 33 },
            { 26, 1, 42, 35 },
            { 8, 4, 35, 37 },
            { 18, 5, 40, 37 },
            { 35, 2, 50, 37 },
            { 2, 5, 40, 39 },
            { 32, 5, 44, 39 },
            { 47, 6, 26, 39 },
            { 6, 4, 17, 43 },
            { 25, 2, 19, 43 },
            { 31, 3, 27, 45 },
            { 50, 5, 16, 47 },
            { 22, 3, 4, 49 },
            { 3, 5, 19, 29 },
            { 36, 3, 29, 27 },
            { 10, 3, 40, 26 },
            { 49, 1, 3, 24 },
            { 11, 6, 50, 3 },
            { 1, 4, 15, 4 },
            { 19, 4, 35, 4 },
            { 7, 2, 1, 5 },
            { 29, 2, 26, 5 },
            { 46, 3, 42, 5 },
            { 4, 5, 24, 6 },
            { 39, 5, 9, 8 },
            { 41, 5, 45, 8 },
            { 48, 3, 28, 8 },
            { 17, 2, 19, 50 },
            { 28, 3, 19, 13 },
            { 16, 5, 39, 15 },
            { 21, 4, 6, 15 },
            { 23, 1, 4, 16 },
            { 40, 4, 3, 16 },
            { 15, 6, 34, 20 },
            { 44, 6, 5, 20 },
            { 33, 4, 50, 21 },
            { 24, 3, 3, 22 },
            { 27, 5, 17, 22 },
            { 13, 2, 43, 24 },
            { 14, 3, 39, 14 },
            { 42, 4, 33, 50 }
                });

            migrationBuilder.InsertData(table: "Issues",
                                        columns: new[]
                {
                    "Id",
                    "CreationDate",
                    "Description",
                    "IssueStatusId",
                    "ProductOSVersionId",
                    "Resolution",
                    "ResolutionDate"
                },
                                        values: new object[,]
                {
            {
                7,
                new DateTime(2020, 6, 3, 19, 53, 26, 70, DateTimeKind.Local).AddTicks(2773),
                "Libero autem sed quia. Est et sit odio officiis quis. Autem minus praesentium animi sed asperiores maiores est qui aspernatur. Laboriosam consequatur sequi et corporis dolorem soluta. Sit porro enim architecto optio voluptas dolorum. Aspernatur fugiat non minus.",
                4,
                45,
                "Ullam non fuga vel. Hic voluptatibus repellat sunt consequatur non. Enim officiis architecto laborum odio neque architecto harum. Nihil sequi quidem iusto maxime corrupti vel quibusdam. Dolorem facere fugit quia ad minus aut. Qui est consequatur aperiam eum.",
                new DateTime(2020, 9, 10, 8, 43, 3, 695, DateTimeKind.Local).AddTicks(6688)
            },
            {
                27,
                new DateTime(2020, 6, 4, 5, 16, 42, 444, DateTimeKind.Local).AddTicks(4842),
                "Earum tempore natus. Id occaecati temporibus. Excepturi et aut occaecati fugit est aut esse sit. Reiciendis consequuntur rem. Beatae velit et et ea officiis dicta. Est in et dolorem nihil cupiditate qui qui.",
                4,
                37,
                "Eos consequatur velit nostrum error in. Et eos et qui optio est vitae consequatur. Maxime illo fugiat.",
                new DateTime(2021, 4, 15, 19, 3, 6, 387, DateTimeKind.Local).AddTicks(3900)
            },
            {
                34,
                new DateTime(2020, 6, 4, 9, 54, 55, 27, DateTimeKind.Local).AddTicks(3083),
                "Sunt unde in inventore. Et ipsam in excepturi in dolor et labore provident magni. Quod mollitia nesciunt eveniet blanditiis velit optio.",
                1,
                20,
                string.Empty,
                null
            },
            {
                47,
                new DateTime(2020, 6, 4, 9, 31, 19, 464, DateTimeKind.Local).AddTicks(5304),
                "Nostrum aut impedit soluta. A nihil excepturi beatae suscipit reiciendis est odit voluptatum. Occaecati cupiditate architecto autem eos occaecati quia. Veritatis reiciendis eligendi iure perferendis. Repudiandae ducimus natus et voluptas et explicabo ut hic.",
                2,
                20,
                string.Empty,
                null
            },
            {
                15,
                new DateTime(2020, 6, 4, 12, 14, 10, 509, DateTimeKind.Local).AddTicks(3856),
                "Exercitationem sapiente dolor sit hic. Quam ea ipsam sed asperiores qui id consequatur. Eaque ea et tempora dignissimos in vel maiores. Rerum sint voluptates incidunt voluptas minima. Ullam iste libero. Delectus minus aut fuga.",
                3,
                34,
                "Quo occaecati expedita unde sunt vel voluptatem tempore placeat ut. Consequatur cumque quaerat consequatur vel fugit. Fugit cumque quia reiciendis excepturi. Excepturi numquam in sunt tempora ipsum at totam sint facere. Ut ratione temporibus vitae quae.",
                new DateTime(2021, 3, 24, 6, 49, 1, 237, DateTimeKind.Local).AddTicks(5656)
            },
            {
                19,
                new DateTime(2020, 6, 4, 3, 49, 20, 652, DateTimeKind.Local).AddTicks(8598),
                "Tempore amet reiciendis rerum debitis incidunt autem ipsum. Dolor dolore aspernatur et doloremque placeat aspernatur. Qui dolor earum voluptatem possimus aut nostrum ex. Magnam unde ipsa quis impedit. Ut excepturi et non et non et consequatur consequatur pariatur. Voluptatum aspernatur voluptatem eum et.",
                2,
                5,
                string.Empty,
                null
            },
            {
                29,
                new DateTime(2020, 6, 3, 22, 54, 17, 573, DateTimeKind.Local).AddTicks(5717),
                "Iste quisquam aliquam rem aut et. Sed sequi ut non nemo autem. Sunt occaecati dolor est. Aut est at porro earum autem est. Repellendus quia ipsam fuga quisquam maxime. Modi sed deserunt.",
                1,
                5,
                string.Empty,
                null
            },
            {
                6,
                new DateTime(2020, 6, 4, 17, 15, 26, 811, DateTimeKind.Local).AddTicks(8307),
                "Reiciendis cupiditate ad et animi dignissimos sit. Sed quis quibusdam. Placeat qui aspernatur vitae quaerat nobis. Doloribus qui voluptate quo. Non voluptas sunt quaerat molestiae aspernatur non quisquam. Aperiam in rerum dignissimos qui earum nam est temporibus.",
                1,
                9,
                string.Empty,
                null
            },
            {
                17,
                new DateTime(2020, 6, 3, 23, 37, 51, 121, DateTimeKind.Local).AddTicks(4323),
                "Nulla quisquam delectus omnis ipsam perferendis consequatur in iste. Quia ut earum nemo asperiores odio dolores deserunt officia. Est et dolores eum eos ut odit. Dignissimos dolore veritatis suscipit nobis sint quasi aliquam. Laborum porro repellendus vel quas.",
                2,
                9,
                string.Empty,
                null
            },
            {
                20,
                new DateTime(2020, 6, 4, 1, 29, 22, 574, DateTimeKind.Local).AddTicks(9502),
                "Quisquam aperiam ea minus blanditiis est ut aut reiciendis reiciendis. Aut porro itaque. Ut corrupti unde optio deserunt aut.",
                4,
                9,
                "Pariatur voluptate repudiandae nemo nobis officia mollitia reiciendis dolorem magni. Architecto commodi et minus sapiente. Consectetur repellendus non est magni totam totam ea adipisci. Ut eum quisquam. Cupiditate beatae repellat eum aut voluptatem fuga modi laboriosam.",
                new DateTime(2021, 1, 28, 11, 49, 51, 841, DateTimeKind.Local).AddTicks(7124)
            },
            {
                45,
                new DateTime(2020, 6, 4, 7, 36, 28, 477, DateTimeKind.Local).AddTicks(8632),
                "Rerum omnis voluptatibus est et nostrum quia ut. Fugit harum fuga velit. Occaecati et cupiditate molestiae.",
                1,
                9,
                string.Empty,
                null
            },
            {
                31,
                new DateTime(2020, 6, 4, 12, 39, 40, 503, DateTimeKind.Local).AddTicks(3347),
                "Facilis possimus dolore aliquid quas sapiente sunt enim amet. Voluptates est est est est voluptatem quia. Omnis laborum dolor magni veniam quia id sunt. Quo itaque provident quas quia iure est incidunt. Repudiandae eveniet repellendus optio suscipit veritatis delectus omnis consequatur.",
                2,
                30,
                string.Empty,
                null
            },
            {
                10,
                new DateTime(2020, 6, 4, 13, 39, 28, 246, DateTimeKind.Local).AddTicks(1095),
                "Eos vitae est vitae reprehenderit. Reiciendis iusto voluptate. Ducimus neque officia.",
                2,
                8,
                string.Empty,
                null
            },
            {
                8,
                new DateTime(2020, 6, 4, 0, 8, 1, 717, DateTimeKind.Local).AddTicks(6574),
                "Enim non fugiat fugiat voluptatem ratione ut similique consectetur velit. Ut nostrum et ea omnis. Ex ut et expedita omnis. Culpa consequatur necessitatibus earum expedita consequatur sed voluptatibus doloribus. Iusto asperiores et nulla. Accusamus sunt assumenda molestias molestias facilis aliquam hic aut.",
                2,
                18,
                string.Empty,
                null
            },
            {
                14,
                new DateTime(2020, 6, 4, 19, 45, 23, 696, DateTimeKind.Local).AddTicks(3701),
                "Neque molestiae cumque iusto assumenda labore eius commodi ipsam. Dolor qui perferendis sed. Omnis aperiam ipsa ut ullam dolore. Est accusantium est provident repellendus non distinctio illo quam. Suscipit et nihil quisquam odio illo non esse temporibus. Non sint et.",
                3,
                18,
                "Enim aliquid consequatur expedita tempora quidem voluptas sit. Voluptatibus et amet rem qui facilis eos quos ullam. Consequatur qui cupiditate maxime reiciendis ut eligendi pariatur. Libero maxime natus.",
                new DateTime(2020, 6, 5, 1, 54, 20, 183, DateTimeKind.Local).AddTicks(8346)
            },
            {
                4,
                new DateTime(2020, 6, 4, 1, 51, 55, 777, DateTimeKind.Local).AddTicks(4764),
                "Accusantium porro laudantium ipsam et est reprehenderit odio. Quisquam sint dolore veniam incidunt rerum minus pariatur quod. Rerum doloribus esse deserunt quos dolor ea voluptatem ratione quis.",
                2,
                35,
                string.Empty,
                null
            },
            {
                25,
                new DateTime(2020, 6, 4, 4, 14, 50, 392, DateTimeKind.Local).AddTicks(1122),
                "Ipsa vel perferendis itaque quia voluptas id voluptatem et. Accusamus ut mollitia architecto et qui tenetur in et. Iste eligendi quasi et inventore in adipisci officiis mollitia minus. Nesciunt atque aliquam.",
                1,
                32,
                string.Empty,
                null
            },
            {
                2,
                new DateTime(2020, 6, 4, 2, 18, 13, 155, DateTimeKind.Local).AddTicks(2966),
                "Soluta nobis repudiandae praesentium sapiente iste voluptatem aspernatur illo. Et minima commodi tempore hic sit. Asperiores ab sit officiis ipsum est officiis. Nemo itaque id consectetur provident eos.",
                4,
                47,
                "Nemo omnis quod maxime distinctio minus distinctio eveniet qui voluptatem. Dignissimos blanditiis quae itaque. Voluptates mollitia consectetur totam sint nostrum. Similique illo repellendus ad ex a asperiores magni et nemo.",
                new DateTime(2021, 3, 17, 17, 56, 47, 605, DateTimeKind.Local).AddTicks(7746)
            },
            {
                28,
                new DateTime(2020, 6, 4, 17, 58, 8, 69, DateTimeKind.Local).AddTicks(7109),
                "Eos possimus et voluptatibus quia itaque quaerat voluptatem. Consequatur voluptate voluptatibus asperiores neque optio quasi doloremque aliquam nisi. In iusto rerum rem quo deserunt harum laudantium. Voluptas pariatur incidunt suscipit voluptatum ab et eius ipsam. Ut doloremque neque est voluptatem.",
                4,
                6,
                "Voluptas est magnam delectus omnis perferendis voluptas eaque temporibus blanditiis. Error in deserunt ea quae maiores sed repudiandae. Nulla exercitationem et et nostrum sit culpa est. Architecto et ab aspernatur fuga facere excepturi.",
                new DateTime(2022, 1, 21, 9, 25, 23, 130, DateTimeKind.Local).AddTicks(4719)
            },
            {
                46,
                new DateTime(2020, 6, 3, 20, 44, 30, 352, DateTimeKind.Local).AddTicks(6349),
                "Voluptatem rerum nostrum numquam quo doloribus quam consequatur sequi odit. Et ducimus accusamus nam voluptate quae nulla ut. Minima quidem non laudantium.",
                1,
                6,
                string.Empty,
                null
            },
            {
                11,
                new DateTime(2020, 6, 4, 10, 55, 10, 681, DateTimeKind.Local).AddTicks(8760),
                "Nesciunt illum expedita in molestiae saepe beatae quos est adipisci. Eum adipisci nihil et qui aut quidem non quia suscipit. Nam corrupti voluptatem quae ut perspiciatis rem. Est ea quo voluptas perferendis omnis. Non qui et laboriosam ea magni atque quas. Itaque nihil perferendis est nobis dolorem ab.",
                3,
                31,
                "Sint et debitis sapiente hic. Dolorem illo deserunt sint vero ut amet. Nisi recusandae neque dolor voluptatum. Consequatur et ut itaque culpa possimus ipsum culpa voluptas. Debitis voluptas esse pariatur quod cum dignissimos ut magni. Quaerat laboriosam quos laudantium.",
                new DateTime(2021, 8, 3, 8, 6, 57, 859, DateTimeKind.Local).AddTicks(3270)
            },
            {
                35,
                new DateTime(2020, 6, 4, 13, 0, 46, 448, DateTimeKind.Local).AddTicks(4748),
                "Nostrum eligendi consequuntur rerum perspiciatis nobis aut deleniti. Ut iste suscipit iusto ab. Rerum voluptate a non et temporibus error qui. Aliquid voluptate sed et et in voluptates.",
                3,
                31,
                "Libero consequatur omnis dolor id. Et iusto vel autem ab voluptatum. Aut aspernatur est illo veniam pariatur blanditiis harum accusantium ea. Magnam ipsum impedit cum pariatur temporibus dignissimos facilis ea. Voluptates cumque illum.",
                new DateTime(2021, 3, 19, 12, 23, 48, 232, DateTimeKind.Local).AddTicks(1410)
            },
            {
                21,
                new DateTime(2020, 6, 3, 19, 57, 47, 987, DateTimeKind.Local).AddTicks(3634),
                "Et vel velit ut ducimus sed. Ratione placeat iusto alias laudantium qui magnam deleniti. Eveniet unde reiciendis rerum libero dolorem nihil quisquam. Temporibus et iusto aut laudantium nemo velit commodi.",
                2,
                37,
                string.Empty,
                null
            },
            {
                49,
                new DateTime(2020, 6, 4, 17, 19, 7, 825, DateTimeKind.Local).AddTicks(8535),
                "Deserunt cumque cupiditate nobis eveniet ipsum accusamus voluptatibus totam. Est sint eveniet officiis. Eveniet libero totam voluptatem vitae. Asperiores eligendi quis doloremque voluptas voluptate corporis. Magni odio aut laborum dolore ipsa sed ipsum asperiores porro. Quasi voluptatem qui tenetur et.",
                3,
                43,
                "Molestias modi deserunt. Dicta aut voluptatem possimus voluptates. Nemo et sunt tempora voluptas et quia et velit in. Quidem ut eligendi. Et atque earum dolore sint amet recusandae fugiat. Illum accusantium itaque asperiores amet.",
                new DateTime(2021, 3, 26, 19, 33, 34, 933, DateTimeKind.Local).AddTicks(7806)
            },
            {
                43,
                new DateTime(2020, 6, 4, 13, 53, 0, 690, DateTimeKind.Local).AddTicks(287),
                "Nostrum iure et. Numquam ullam aspernatur. Et voluptas nam ab at necessitatibus nesciunt autem in. Ut atque est qui nulla maiores. Quia laudantium delectus ullam earum. Vitae nobis natus reprehenderit quia quia.",
                2,
                3,
                string.Empty,
                null
            },
            {
                36,
                new DateTime(2020, 6, 4, 17, 13, 4, 329, DateTimeKind.Local).AddTicks(2233),
                "Veritatis eveniet quis voluptas rerum quod id hic nihil sapiente. Natus sed nihil ea. Velit consequatur animi quibusdam. Illo autem beatae.",
                3,
                49,
                "Ut blanditiis aliquam similique velit tempora commodi aut incidunt aut. Nemo quia enim nostrum. Et rerum hic qui odit sed deserunt eos similique.",
                new DateTime(2020, 7, 11, 21, 44, 28, 320, DateTimeKind.Local).AddTicks(2056)
            },
            {
                33,
                new DateTime(2020, 6, 4, 15, 44, 34, 517, DateTimeKind.Local).AddTicks(2467),
                "Tenetur sequi adipisci tempore. Sit maiores omnis at aut laboriosam et omnis. Corporis incidunt sed dicta doloribus omnis provident.",
                4,
                11,
                "Et debitis exercitationem commodi iure est laudantium. Quis mollitia ut et fugit veniam deserunt sunt. Eos consequatur voluptatem repellat voluptas illum consequatur.",
                new DateTime(2021, 6, 2, 20, 59, 5, 637, DateTimeKind.Local).AddTicks(1466)
            },
            {
                22,
                new DateTime(2020, 6, 4, 17, 38, 36, 688, DateTimeKind.Local).AddTicks(9999),
                "Reiciendis eligendi qui. Dolorem amet quia quos aut consequuntur qui rerum. Iste reiciendis suscipit assumenda. Quia inventore nemo ut rerum nemo non ex numquam. Corrupti rem dolorem non a porro atque quam.",
                4,
                1,
                "Provident eveniet consequatur. Amet perferendis ut accusantium delectus dignissimos aut. Ea sit perferendis deleniti consequatur laudantium. Voluptatum labore expedita. Enim voluptatem quis magni deserunt aspernatur est. Reprehenderit ut necessitatibus perferendis.",
                new DateTime(2020, 8, 3, 21, 2, 45, 636, DateTimeKind.Local).AddTicks(8495)
            },
            {
                41,
                new DateTime(2020, 6, 3, 21, 48, 34, 429, DateTimeKind.Local).AddTicks(2414),
                "Aut iure et. Enim voluptate quia natus nulla eveniet enim totam. Commodi dolore dolore aut sed omnis. Id consequatur reprehenderit quia labore minus.",
                3,
                1,
                "Culpa sint quia incidunt molestiae beatae qui aperiam. Sapiente recusandae consequuntur molestiae quam. Et ut et.",
                new DateTime(2021, 6, 26, 17, 49, 48, 703, DateTimeKind.Local).AddTicks(4379)
            },
            {
                30,
                new DateTime(2020, 6, 4, 9, 57, 24, 554, DateTimeKind.Local).AddTicks(3768),
                "Et incidunt cupiditate suscipit sit consequatur. Iusto occaecati fugit minima nam eaque possimus voluptatibus aut eius. Aut aspernatur quas necessitatibus qui officiis. Nesciunt dolore nostrum expedita voluptates sit voluptatem. Repudiandae sequi velit enim molestias laudantium.",
                4,
                19,
                "Veritatis quae dolor distinctio ut repudiandae iste quibusdam voluptatibus. Ex omnis et cumque consequatur enim. Voluptas et rerum. Voluptas facilis consequatur error minus accusantium aut molestiae quam. Odit corrupti ut autem tempore.",
                new DateTime(2020, 9, 29, 16, 11, 43, 579, DateTimeKind.Local).AddTicks(2591)
            },
            {
                9,
                new DateTime(2020, 6, 3, 20, 27, 46, 501, DateTimeKind.Local).AddTicks(8029),
                "Omnis voluptas laboriosam. Qui aliquam voluptatem voluptatem sed rerum sed. Numquam autem maiores at dolorum maxime sint cupiditate corrupti optio.",
                1,
                29,
                string.Empty,
                null
            },
            {
                12,
                new DateTime(2020, 6, 4, 5, 16, 27, 11, DateTimeKind.Local).AddTicks(3330),
                "Maiores maxime aut rerum. Eos minus hic nemo delectus quaerat velit. Molestias ut quasi rerum aut laboriosam recusandae. Et nulla qui.",
                3,
                29,
                "Enim vel perspiciatis sed. Adipisci nihil culpa. Ex voluptate atque illo deserunt amet aspernatur repellendus.",
                new DateTime(2022, 5, 17, 14, 46, 26, 321, DateTimeKind.Local).AddTicks(9676)
            },
            {
                38,
                new DateTime(2020, 6, 4, 10, 51, 39, 567, DateTimeKind.Local).AddTicks(354),
                "Sapiente dicta placeat facere rerum accusantium quas. Eum voluptatem voluptatem voluptas ut. Molestiae assumenda repudiandae et consectetur excepturi dolor labore optio adipisci.",
                2,
                46,
                string.Empty,
                null
            },
            {
                48,
                new DateTime(2020, 6, 3, 20, 44, 49, 875, DateTimeKind.Local).AddTicks(735),
                "Placeat suscipit quia. Non laboriosam enim non. Fuga quas in eum unde maiores qui velit rerum.",
                3,
                46,
                "Excepturi et et ipsum nesciunt velit rerum omnis voluptatem illo. Est sed possimus est cumque fugit sunt est nobis. Rerum esse molestiae nisi. Nihil unde in et laudantium eveniet fuga. Quod eos voluptatum occaecati. Id aut eos magni.",
                new DateTime(2021, 6, 9, 4, 50, 29, 225, DateTimeKind.Local).AddTicks(7845)
            },
            {
                3,
                new DateTime(2020, 6, 4, 16, 4, 28, 139, DateTimeKind.Local).AddTicks(1314),
                "Soluta minus quas ea. Temporibus excepturi nam nesciunt asperiores. Veniam quae quibusdam sunt enim nisi aliquam voluptates excepturi asperiores. Alias expedita et. Et cupiditate magnam error quas. Aut est et aut.",
                1,
                39,
                string.Empty,
                null
            },
            {
                32,
                new DateTime(2020, 6, 4, 4, 51, 28, 93, DateTimeKind.Local).AddTicks(1313),
                "At voluptatum voluptatum minus. Est corporis quia voluptas sed. Sit aspernatur aperiam dignissimos et ex aliquid rerum aut. Quia odit aut eum dignissimos provident sit qui. Nihil et quia architecto aperiam. Quibusdam maiores at officiis vel id delectus.",
                3,
                39,
                "Voluptatem et occaecati saepe architecto sint. Consequuntur maxime recusandae modi eos sit. Fugit nihil modi et quam delectus aut modi. Beatae ad quisquam neque cupiditate fugit inventore consequatur fugit reiciendis. Non culpa nobis quos et porro.",
                new DateTime(2021, 2, 4, 14, 44, 28, 665, DateTimeKind.Local).AddTicks(9989)
            },
            {
                37,
                new DateTime(2020, 6, 3, 23, 49, 25, 832, DateTimeKind.Local).AddTicks(866),
                "Sed repellat ratione vel ducimus illum sit quod aut. Culpa provident laboriosam voluptatem ut et. Non in quia aliquid itaque omnis. Dolorum aut consequatur aut nostrum ipsum.",
                1,
                22,
                string.Empty,
                null
            },
            {
                44,
                new DateTime(2020, 6, 3, 20, 18, 59, 891, DateTimeKind.Local).AddTicks(3425),
                "Tenetur libero placeat distinctio natus dolor. Eius ut sint modi pariatur ipsam non suscipit. Accusamus autem reprehenderit. Omnis distinctio blanditiis voluptates tempore.",
                3,
                39,
                "Ut dolores totam. Enim ratione possimus sapiente. Et impedit nostrum exercitationem voluptas perspiciatis libero quod explicabo quo. Iste quia eum qui.",
                new DateTime(2021, 2, 24, 11, 18, 33, 797, DateTimeKind.Local).AddTicks(1620)
            },
            {
                39,
                new DateTime(2020, 6, 4, 14, 18, 56, 848, DateTimeKind.Local).AddTicks(905),
                "Quibusdam inventore est. Aliquid odit excepturi laboriosam tenetur eos. Eos sint ipsa nam.",
                3,
                41,
                "Reiciendis libero nesciunt aliquam error itaque error rerum. Excepturi voluptatem nulla dolorum autem et ex eaque aut. Et in sed deleniti. In voluptate est iure.",
                new DateTime(2021, 7, 14, 12, 57, 55, 44, DateTimeKind.Local).AddTicks(4448)
            },
            {
                1,
                new DateTime(2020, 6, 4, 18, 27, 37, 940, DateTimeKind.Local).AddTicks(4944),
                "Saepe laboriosam ipsum eum sunt quis. Corporis repellendus rerum. Animi expedita odit vero inventore ea assumenda ea qui. Quam molestiae in consectetur dolorum blanditiis facere. Numquam fugiat dicta voluptas corporis ratione.",
                3,
                48,
                "Itaque praesentium laboriosam autem minus ipsa ut. Repellendus eaque sed aspernatur fugit omnis laboriosam aliquid veritatis cupiditate. Provident suscipit ipsam alias officia autem occaecati non.",
                new DateTime(2022, 1, 21, 16, 43, 51, 558, DateTimeKind.Local).AddTicks(9750)
            },
            {
                42,
                new DateTime(2020, 6, 4, 9, 58, 10, 390, DateTimeKind.Local).AddTicks(1085),
                "Voluptas officiis asperiores molestias et in possimus sunt voluptatem ea. Rerum rerum facere libero sed omnis dolore et aut. Voluptatem unde voluptas. Culpa nobis mollitia omnis facere reiciendis. Ea sint ullam qui dolores. Consequuntur eaque repudiandae possimus.",
                3,
                28,
                "Eum dolorem et. Consequuntur optio iste et tempore voluptas rem blanditiis. Distinctio distinctio quae. Est expedita laudantium.",
                new DateTime(2022, 1, 10, 17, 20, 30, 819, DateTimeKind.Local).AddTicks(2883)
            },
            {
                18,
                new DateTime(2020, 6, 4, 6, 6, 3, 688, DateTimeKind.Local).AddTicks(1800),
                "Deleniti voluptas et. Officia aliquam sit consequuntur nisi qui eos quidem est et. Magni nemo voluptas temporibus. Accusantium labore id fugit aut officiis et. Sit voluptatem eum quaerat. Esse fuga eveniet culpa ut.",
                2,
                16,
                string.Empty,
                null
            },
            {
                26,
                new DateTime(2020, 6, 4, 17, 33, 15, 517, DateTimeKind.Local).AddTicks(8657),
                "Quasi porro quo inventore laboriosam quam qui quidem. Ipsa autem est repudiandae voluptatem blanditiis. Corporis nostrum dolor deserunt ut tempore sit earum aut aut. Nihil culpa dolorum est doloribus. Aut voluptatum eveniet quo cumque assumenda doloribus.",
                3,
                23,
                "Quidem nisi rerum perspiciatis laborum omnis possimus. Velit minima ea. Ab numquam molestias. Ut maxime excepturi debitis et.",
                new DateTime(2021, 9, 20, 2, 9, 37, 439, DateTimeKind.Local).AddTicks(7943)
            },
            {
                40,
                new DateTime(2020, 6, 4, 13, 24, 0, 142, DateTimeKind.Local).AddTicks(7542),
                "Deleniti eligendi officiis omnis eveniet amet. Architecto rerum omnis sunt aperiam quae harum. Assumenda corporis ex illo consequatur neque architecto similique ipsam.",
                3,
                44,
                "Impedit sit culpa nemo dignissimos consectetur reiciendis. Sequi numquam dolor dicta nam odio aliquid temporibus. Delectus beatae magnam. Voluptas aliquam consequatur ad qui natus qui. Pariatur eos quia porro quas consequatur dolor voluptatum corporis delectus. Magni fugiat amet quod.",
                new DateTime(2021, 10, 15, 20, 9, 6, 369, DateTimeKind.Local).AddTicks(5674)
            },
            {
                5,
                new DateTime(2020, 6, 4, 7, 35, 41, 132, DateTimeKind.Local).AddTicks(7010),
                "Non dolor nihil maxime. Amet ea velit similique et impedit tempora ut. Esse est reiciendis perspiciatis ipsum incidunt eligendi aut dolores dolorem. Eum omnis laborum autem totam. Qui ut aut earum eum consequatur voluptatem autem. Ut sed fuga nihil.",
                4,
                33,
                "Ut quia ut laboriosam sapiente mollitia excepturi dicta quam. Maiores sapiente animi quos aut architecto facilis rerum omnis. Libero est consequuntur aut. Magnam quis dolore sequi consequatur quasi aut. Molestiae voluptatem voluptatem consectetur molestias dolor. Quis et asperiores placeat quas illum.",
                new DateTime(2022, 1, 10, 3, 12, 37, 622, DateTimeKind.Local).AddTicks(459)
            },
            {
                13,
                new DateTime(2020, 6, 4, 6, 28, 4, 281, DateTimeKind.Local).AddTicks(9899),
                "Tenetur sapiente id sit aut dolor similique enim. Alias sequi laudantium rem ad nihil explicabo repellat officiis unde. Fugit non voluptatibus quidem corrupti quia et ut.",
                2,
                27,
                string.Empty,
                null
            },
            {
                23,
                new DateTime(2020, 6, 3, 23, 48, 21, 166, DateTimeKind.Local).AddTicks(1732),
                "Voluptates ut nemo et aliquid voluptatem quia dolores. Velit laborum eos possimus commodi esse eum est unde ipsa. Quis repellat id pariatur rerum aut aspernatur illum.",
                3,
                27,
                "Est sit alias adipisci non ducimus cum velit similique sed. Possimus laudantium repellendus architecto. Excepturi omnis totam ut animi alias harum sapiente totam. Ducimus quasi natus soluta labore ipsa itaque quasi sed quisquam.",
                new DateTime(2022, 3, 8, 16, 0, 1, 813, DateTimeKind.Local).AddTicks(4025)
            },
            {
                24,
                new DateTime(2020, 6, 4, 11, 17, 23, 52, DateTimeKind.Local).AddTicks(3764),
                "Inventore natus et exercitationem beatae veniam. Nostrum molestiae occaecati distinctio hic ut atque cum cupiditate nobis. Ipsum quo iure et voluptates recusandae blanditiis eaque totam. Ex odit cum inventore nobis quod optio aut voluptatibus sunt. Ut odit iusto vero deleniti rerum ut nisi. Nihil exercitationem nihil atque sit sunt.",
                2,
                13,
                string.Empty,
                null
            },
            {
                16,
                new DateTime(2020, 6, 4, 1, 25, 31, 32, DateTimeKind.Local).AddTicks(7117),
                "Cupiditate ipsum id saepe quam. Est et quia quia qui repudiandae aut nostrum iure. Quibusdam consectetur beatae. Dolores optio doloremque. Temporibus possimus nemo.",
                2,
                41,
                string.Empty,
                null
            },
            {
                50,
                new DateTime(2020, 6, 3, 21, 7, 0, 521, DateTimeKind.Local).AddTicks(7055),
                "Voluptas porro dicta. Ea animi consequatur voluptatem et magni omnis similique. Suscipit autem soluta. Et eum quia qui tempore facere consequatur aut et ut. Consequuntur impedit nisi laudantium animi non et quisquam.",
                2,
                22,
                string.Empty,
                null
            }
                });

            migrationBuilder.CreateIndex(name: "IX_Issues_IssueStatusId", table: "Issues", column: "IssueStatusId");

            migrationBuilder.CreateIndex(name: "IX_Issues_ProductOSVersionId",
                                         table: "Issues",
                                         column: "ProductOSVersionId");

            migrationBuilder.CreateIndex(name: "IX_ProductOSVersions_OperatingSystemId",
                                         table: "ProductOSVersions",
                                         column: "OperatingSystemId");

            migrationBuilder.CreateIndex(name: "IX_ProductOSVersions_VersionId",
                                         table: "ProductOSVersions",
                                         column: "VersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Issues");

            migrationBuilder.DropTable(name: "IssueStatusList");

            migrationBuilder.DropTable(name: "ProductOSVersions");

            migrationBuilder.DropTable(name: "OperatingSystems");

            migrationBuilder.DropTable(name: "Products");

            migrationBuilder.DropTable(name: "Versions");

            //Remove Stored Procedure
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames =
                        assembly.GetManifestResourceNames().Where(str => str.EndsWith(".sql"));
            foreach(string resourceName in resourceNames)
            {
                var name = resourceName.Split('.')[3];
                Console.WriteLine(name);
                migrationBuilder.Sql($"DROP PROCEDURE IF EXISTS {name}");
            }
        }
    }
}
