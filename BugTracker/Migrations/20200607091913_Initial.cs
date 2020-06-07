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
            { 4, "Social Anxiety Planner" },
            { 3, "Workout Planner" },
            { 1, "Day Trader Wannabe" },
            { 2, "Investment Overlord" }
                });

            migrationBuilder.InsertData(table: "Versions",
                                        columns: new[]
                { "Id", "VersionName" },
                                        values: new object[,]
                {
            { 7, "2.2" },
            { 1, "1.0" },
            { 2, "1.1" },
            { 3, "1.2" },
            { 4, "1.3" },
            { 5, "2.0" },
            { 6, "2.1" },
            { 8, "2.3" }
                });

            migrationBuilder.InsertData(table: "ProductOSVersions",
                                        columns: new[]
                { "Id", "OperatingSystemId", "ProductId", "VersionId" },
                                        values: new object[,]
                {
            { 3, 5, 4, 1 },
            { 24, 4, 2, 5 },
            { 30, 3, 3, 5 },
            { 36, 5, 3, 5 },
            { 45, 4, 4, 5 },
            { 49, 4, 3, 5 },
            { 5, 1, 1, 6 },
            { 18, 4, 4, 6 },
            { 26, 3, 3, 6 },
            { 38, 6, 4, 6 },
            { 44, 6, 1, 6 },
            { 13, 3, 4, 7 },
            { 21, 6, 2, 7 },
            { 33, 4, 3, 7 },
            { 39, 4, 2, 7 },
            { 1, 2, 3, 8 },
            { 4, 5, 1, 8 },
            { 11, 4, 1, 8 },
            { 14, 3, 2, 8 },
            { 19, 4, 4, 8 },
            { 27, 6, 3, 8 },
            { 28, 2, 4, 8 },
            { 9, 1, 3, 5 },
            { 7, 6, 4, 5 },
            { 2, 1, 1, 5 },
            { 48, 4, 2, 4 },
            { 15, 4, 3, 1 },
            { 23, 4, 1, 1 },
            { 29, 6, 3, 1 },
            { 46, 1, 2, 1 },
            { 47, 6, 2, 1 },
            { 50, 1, 3, 1 },
            { 6, 3, 2, 2 },
            { 8, 4, 1, 2 },
            { 12, 3, 1, 2 },
            { 17, 6, 1, 2 },
            { 31, 1, 2, 8 },
            { 32, 1, 4, 2 },
            { 37, 3, 3, 2 },
            { 41, 6, 2, 2 },
            { 10, 3, 4, 3 },
            { 16, 6, 3, 3 },
            { 22, 4, 3, 3 },
            { 40, 1, 3, 3 },
            { 42, 4, 2, 3 },
            { 43, 6, 1, 3 },
            { 20, 3, 3, 4 },
            { 25, 2, 4, 4 },
            { 35, 4, 4, 2 },
            { 34, 4, 2, 8 }
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
                18,
                new DateTime(2020, 6, 6, 22, 18, 31, 379, DateTimeKind.Local).AddTicks(4416),
                @"I'll back up the online SMS system, that should system the SMS system! System.BadImageFormatException: Internal
                File name: 'streamline'
                   at Bogus.DataSets.System.Exception() Eum quisquam veniam doloribus eos cumque ipsam neque. Accusamus sed voluptatem sed. Nesciunt quam ut quidem dolorem est non sint suscipit. Et sed sed. Ut autem dolor qui autem consequatur adipisci. Quaerat earum est exercitationem et fugiat iste animi libero.",
                3,
                3,
                "Perspiciatis modi odio consectetur inventore cupiditate vitae eos. Accusantium sit doloribus. Ipsa harum dolores cum voluptas nihil sapiente ut voluptatem. Rem cupiditate tempora aut. Accusamus labore quia nihil eum harum quia sint nisi. Voluptatem perspiciatis ut recusandae excepturi asperiores.",
                new DateTime(2021, 12, 3, 4, 48, 52, 55, DateTimeKind.Local).AddTicks(5557)
            },
            {
                32,
                new DateTime(2020, 6, 7, 12, 36, 13, 917, DateTimeKind.Local).AddTicks(4264),
                @"We need to synthesize the digital CSS alarm! System.DivideByZeroException: Attempted to divide by zero.
                   at Bogus.DataSets.System.Exception() Laudantium sit commodi aut rerum iusto excepturi aliquam ipsum. Et nemo repellendus. Consectetur maxime quia ut omnis aspernatur perspiciatis quas. Qui minima deserunt doloribus et nobis rerum impedit sit. Dolor laboriosam blanditiis deleniti voluptate.",
                2,
                45,
                string.Empty,
                null
            },
            {
                35,
                new DateTime(2020, 6, 7, 18, 55, 14, 571, DateTimeKind.Local).AddTicks(3334),
                @"If we synthesize the protocol, we can get to the SSL protocol through the multi-byte SSL protocol! System.BadImageFormatException: plum
                File name: 'Shoes, Games & Movies'
                   at Bogus.DataSets.System.Exception() Consectetur ut aliquid consequatur. Similique et et quam voluptatem voluptas porro eveniet repudiandae et. Aut consectetur amet libero. Non vel quia et rerum dolor aut.",
                3,
                45,
                "Expedita sunt eligendi consectetur modi consequatur quas. Itaque dolor reprehenderit officiis est inventore sit. Eum eum laboriosam quidem esse voluptatum molestias est in. Tempora velit ad quod doloribus quos. Et magni omnis aut voluptas velit voluptatem. Optio in deserunt necessitatibus quaerat.",
                new DateTime(2021, 8, 17, 19, 31, 3, 48, DateTimeKind.Local).AddTicks(8381)
            },
            {
                45,
                new DateTime(2020, 6, 7, 13, 10, 47, 621, DateTimeKind.Local).AddTicks(1415),
                @"Try to navigate the THX transmitter, maybe it will navigate the redundant transmitter! System.BadImageFormatException: Sports compress
                File name: 'auxiliary'
                   at Bogus.DataSets.System.Exception() Dolorum odio quia et praesentium. In enim ut at praesentium quisquam omnis qui ut. Blanditiis suscipit culpa omnis est.",
                2,
                45,
                string.Empty,
                null
            },
            {
                12,
                new DateTime(2020, 6, 6, 19, 57, 43, 341, DateTimeKind.Local).AddTicks(4542),
                @"You can't quantify the firewall without programming the bluetooth IB firewall! System.FormatException: Vista Money Market Account Belarussian Ruble
                   at Bogus.DataSets.System.Exception() Ut numquam explicabo alias consectetur. Eius officia sit minus ut ut aut et. Laudantium rerum placeat consequatur dolore culpa voluptate. Aperiam quas perferendis eveniet quisquam molestiae neque nihil.",
                2,
                5,
                string.Empty,
                null
            },
            {
                42,
                new DateTime(2020, 6, 7, 6, 26, 35, 926, DateTimeKind.Local).AddTicks(7847),
                @"You can't calculate the driver without generating the back-end THX driver! System.OutOfMemoryException: Developer IB Small
                   at Bogus.DataSets.System.Exception() Esse ullam et iure quo sit soluta velit enim. Ratione incidunt quasi eum ut eum eum. Pariatur est laborum voluptas eveniet voluptas inventore maiores odio sunt. Qui ut atque maxime veritatis distinctio laboriosam. Tenetur qui quam rerum impedit nemo iusto quos velit possimus. Dolorem ab praesentium nesciunt quia dicta qui.",
                1,
                18,
                string.Empty,
                null
            },
            {
                15,
                new DateTime(2020, 6, 6, 22, 8, 10, 246, DateTimeKind.Local).AddTicks(5878),
                @"The JSON program is down, navigate the neural program so we can navigate the JSON program! System.NotImplementedException: The method or operation is not implemented.
                   at Bogus.DataSets.System.Exception() Doloribus qui tempore maiores deserunt voluptatibus esse. Officia laboriosam quod eos necessitatibus possimus inventore quisquam adipisci. Distinctio harum eum. Reprehenderit beatae ea perspiciatis nam laudantium doloribus fugiat aut. Ad voluptatem facere temporibus aut sit et suscipit sapiente. Explicabo error dolor reprehenderit omnis ratione qui minima quae.",
                4,
                26,
                "Repellendus omnis libero maxime distinctio quisquam in. Deserunt dolores et velit sed ut reiciendis aut ea sint. Asperiores laborum consectetur similique aliquam. Architecto eum distinctio aperiam nihil quod autem deleniti consequatur modi. Autem non nobis et sint.",
                new DateTime(2020, 12, 8, 7, 15, 45, 373, DateTimeKind.Local).AddTicks(2433)
            },
            {
                6,
                new DateTime(2020, 6, 7, 0, 35, 18, 782, DateTimeKind.Local).AddTicks(8114),
                @"We need to parse the back-end SAS bandwidth! System.OutOfMemoryException: PCI Fresh
                   at Bogus.DataSets.System.Exception() Est occaecati et tempora eligendi ut. Voluptate suscipit rerum eum officiis. Ullam tempore omnis earum tenetur.",
                3,
                44,
                "Distinctio adipisci neque eligendi aut saepe. Nihil quia dolores adipisci quia dolorum itaque nam omnis. Magnam iste eveniet. Ullam repellendus dolorem placeat est voluptatem. Quia ducimus earum aliquam consequatur facere.",
                new DateTime(2022, 2, 27, 10, 1, 35, 628, DateTimeKind.Local).AddTicks(5089)
            },
            {
                16,
                new DateTime(2020, 6, 7, 16, 17, 54, 944, DateTimeKind.Local).AddTicks(231),
                @"The GB alarm is down, back up the digital alarm so we can back up the GB alarm! System.IndexOutOfRangeException: input rich Rue
                   at Bogus.DataSets.System.Exception() Repudiandae dolor quam quia tempore. Id eum ut. Dolor occaecati id impedit temporibus soluta molestias voluptatem molestiae mollitia.",
                2,
                13,
                string.Empty,
                null
            },
            {
                43,
                new DateTime(2020, 6, 7, 7, 50, 53, 211, DateTimeKind.Local).AddTicks(3394),
                @"You can't reboot the array without transmitting the primary THX array! System.IO.FileNotFoundException: File not found...
                File name: 'jcyqmhjh.owf'
                   at Bogus.DataSets.System.Exception() Impedit maxime necessitatibus ut quia doloremque doloremque omnis quaerat. Consectetur itaque sed totam. Facere libero et enim tempora iure eum.",
                3,
                21,
                "In deserunt et ut laboriosam nam corrupti aut. Velit molestiae molestiae consequuntur et eum et praesentium. Ad eos incidunt dolorem et natus. Aut ad expedita sint aut.",
                new DateTime(2022, 4, 24, 13, 35, 6, 166, DateTimeKind.Local).AddTicks(6367)
            },
            {
                7,
                new DateTime(2020, 6, 7, 6, 35, 22, 755, DateTimeKind.Local).AddTicks(625),
                @"generating the firewall won't do anything, we need to program the optical PNG firewall! System.IndexOutOfRangeException: Gorgeous Soft Fish Universal
                   at Bogus.DataSets.System.Exception() Sunt aut veniam. Molestias consectetur ut non vero error ab ducimus. Eligendi sed expedita voluptas ut labore eveniet alias debitis. Mollitia necessitatibus dolores consectetur.",
                4,
                4,
                "Amet iusto repudiandae illo quod eveniet totam dolorum voluptas qui. Sint non voluptas. Cum at et. Laudantium non soluta dolore facilis quia rerum suscipit. Quia sit consequuntur pariatur eos animi.",
                new DateTime(2021, 4, 15, 5, 38, 25, 86, DateTimeKind.Local).AddTicks(8554)
            },
            {
                10,
                new DateTime(2020, 6, 7, 0, 45, 5, 98, DateTimeKind.Local).AddTicks(455),
                @"We need to connect the haptic EXE bandwidth! System.FormatException: Exclusive
                   at Bogus.DataSets.System.Exception() Excepturi minus alias deserunt modi beatae at mollitia nulla consequatur. Rerum non in. Expedita fugit enim aut perspiciatis autem.",
                4,
                4,
                "Quas id sit dolorem id ducimus quibusdam cupiditate. Ad sed aut. Qui iusto earum rerum ab. Similique nostrum aspernatur hic numquam at et ut alias.",
                new DateTime(2020, 11, 3, 14, 42, 49, 689, DateTimeKind.Local).AddTicks(5229)
            },
            {
                22,
                new DateTime(2020, 6, 6, 21, 55, 45, 7, DateTimeKind.Local).AddTicks(6150),
                @"Try to parse the AI firewall, maybe it will parse the neural firewall! System.IndexOutOfRangeException: Falkland Islands (Malvinas)
                   at Bogus.DataSets.System.Exception() Aut occaecati accusantium et dolorem. Ut ipsa veritatis ullam eum temporibus provident molestiae. Dignissimos exercitationem facere numquam mollitia similique facilis quibusdam placeat natus. Distinctio ea sunt commodi et. Voluptatibus tempore iure quia dolore natus aperiam suscipit nobis. Eveniet doloremque natus voluptatem ratione qui voluptatibus eos qui voluptas.",
                3,
                4,
                "Neque alias qui repudiandae nisi et ducimus ipsam. Deserunt natus veniam porro quo corrupti tenetur exercitationem dolore sed. Consequuntur eos quis aut dolorem autem debitis. Perferendis sunt et doloremque ea qui. Consectetur sed vitae et ut.",
                new DateTime(2022, 5, 7, 2, 20, 52, 519, DateTimeKind.Local).AddTicks(6897)
            },
            {
                17,
                new DateTime(2020, 6, 7, 9, 56, 25, 882, DateTimeKind.Local).AddTicks(2201),
                @"Try to program the AI application, maybe it will program the wireless application! System.IndexOutOfRangeException: Fantastic Rubber Chicken Handmade Cotton Ball
                   at Bogus.DataSets.System.Exception() Est qui optio voluptas dolor ut excepturi qui ipsam modi. Hic quis culpa porro quis porro quod repellendus nam. Quasi dolorum autem. Sit voluptas doloribus et molestias nihil recusandae.",
                3,
                11,
                "Perferendis consequatur laboriosam. Consectetur consequatur voluptatem ratione. Consequatur et et molestiae qui nam. Commodi optio distinctio ut quibusdam non. Ut est voluptatum.",
                new DateTime(2021, 4, 21, 22, 0, 20, 463, DateTimeKind.Local).AddTicks(5469)
            },
            {
                29,
                new DateTime(2020, 6, 7, 5, 6, 28, 658, DateTimeKind.Local).AddTicks(4714),
                @"We need to copy the optical JBOD alarm! System.IndexOutOfRangeException: Intelligent Fresh Hat application
                   at Bogus.DataSets.System.Exception() Et dolores sit eum. Recusandae ducimus cupiditate vel doloremque omnis qui eos quos. Magni ea sint. Eum impedit impedit.",
                4,
                11,
                "Ut et deserunt. Ullam vel delectus aperiam. Dolores sit aut deserunt quaerat saepe. Ut autem distinctio fugit in cupiditate. Fugiat iste iusto voluptatem eos ut architecto.",
                new DateTime(2020, 11, 12, 11, 5, 4, 335, DateTimeKind.Local).AddTicks(1408)
            },
            {
                50,
                new DateTime(2020, 6, 7, 0, 6, 15, 717, DateTimeKind.Local).AddTicks(9766),
                @"We need to hack the digital XML sensor! System.IO.EndOfStreamException: Tasty Agent Future
                   at Bogus.DataSets.System.Exception() Vel magnam vel libero. Porro sed et dignissimos nostrum tempore temporibus ut. Veritatis provident ipsam repudiandae minima autem dolorum. Et impedit tempore omnis. Ut qui consequatur excepturi ipsam vel. Dolor necessitatibus ipsa ut eos blanditiis nemo natus velit adipisci.",
                2,
                11,
                string.Empty,
                null
            },
            {
                13,
                new DateTime(2020, 6, 6, 20, 32, 1, 291, DateTimeKind.Local).AddTicks(5901),
                @"Try to input the PCI sensor, maybe it will input the cross-platform sensor! System.OutOfMemoryException: Streamlined
                   at Bogus.DataSets.System.Exception() Culpa est rerum fugit iure. Assumenda itaque veniam et nesciunt laborum veritatis magni. Modi qui sit sed occaecati autem ut pariatur qui qui. Perspiciatis magnam repudiandae id qui ut consequatur consequatur voluptatibus ea.",
                4,
                14,
                "Ex beatae dolor nihil laborum ab placeat quibusdam aliquid. Est provident commodi ipsum est. Voluptas doloremque quo eos totam inventore et quia illum et. Sit accusantium velit maiores inventore quis placeat odit. Delectus odit quidem non distinctio rerum nobis.",
                new DateTime(2020, 11, 23, 13, 0, 30, 126, DateTimeKind.Local).AddTicks(9141)
            },
            {
                25,
                new DateTime(2020, 6, 7, 15, 26, 42, 281, DateTimeKind.Local).AddTicks(7174),
                @"Try to connect the COM monitor, maybe it will connect the solid state monitor! System.FormatException: Supervisor content
                   at Bogus.DataSets.System.Exception() Doloribus et porro velit vel quo id labore maiores. Suscipit veniam aut reprehenderit dolorem deleniti ea eum quis. Ut ducimus quia animi.",
                1,
                14,
                string.Empty,
                null
            },
            {
                14,
                new DateTime(2020, 6, 7, 15, 54, 51, 298, DateTimeKind.Local).AddTicks(612),
                @"I'll override the 1080p CSS feed, that should feed the CSS feed! System.IO.EndOfStreamException: wireless systematic Generic Fresh Sausages
                   at Bogus.DataSets.System.Exception() Iusto ut voluptatum amet sint voluptatem perspiciatis aut et. Aliquam ratione id consequatur. Ipsa enim nisi et voluptatem ratione et in modi. Dignissimos rerum rerum assumenda.",
                1,
                27,
                string.Empty,
                null
            },
            {
                49,
                new DateTime(2020, 6, 7, 16, 16, 17, 538, DateTimeKind.Local).AddTicks(9494),
                @"The SMTP system is down, back up the open-source system so we can back up the SMTP system! System.ArithmeticException: grey programming digital
                   at Bogus.DataSets.System.Exception() Quidem soluta magnam sit quaerat sed. Ab nemo aliquam non amet. Quisquam eius quia quae. Sed tenetur cupiditate quo ducimus ullam vel aut. Officiis vel est ut voluptas. Impedit et unde sit qui neque eos.",
                4,
                27,
                "Natus quia praesentium. Officia quia itaque aperiam sint quaerat officiis. Ipsa cum quis autem ducimus nihil non. Debitis harum dolor dolorem. Suscipit amet cum dolores voluptatem quia error ut excepturi corrupti. Quasi tempora qui neque.",
                new DateTime(2021, 4, 11, 15, 44, 2, 116, DateTimeKind.Local).AddTicks(929)
            },
            {
                9,
                new DateTime(2020, 6, 7, 4, 51, 9, 196, DateTimeKind.Local).AddTicks(3383),
                @"Use the auxiliary FTP port, then you can copy the auxiliary port! System.NotImplementedException: The method or operation is not implemented.
                   at Bogus.DataSets.System.Exception() Quae voluptatibus laboriosam eaque asperiores et qui voluptas repudiandae et. Dolorem et vel repellat nam impedit aperiam vel ad quo. Ex odio aperiam temporibus.",
                1,
                28,
                string.Empty,
                null
            },
            {
                31,
                new DateTime(2020, 6, 7, 3, 24, 31, 620, DateTimeKind.Local).AddTicks(8972),
                @"Use the open-source XML transmitter, then you can back up the open-source transmitter! System.NotImplementedException: The method or operation is not implemented.
                   at Bogus.DataSets.System.Exception() Natus quod dolorem eos asperiores. Nihil est repellat natus et voluptatum voluptas. Aut veritatis est totam in.",
                2,
                28,
                string.Empty,
                null
            },
            {
                44,
                new DateTime(2020, 6, 7, 13, 7, 36, 787, DateTimeKind.Local).AddTicks(2308),
                @"Use the auxiliary SAS sensor, then you can parse the auxiliary sensor! System.IO.EndOfStreamException: Dale Cambridgeshire
                   at Bogus.DataSets.System.Exception() Labore beatae et in cum illum. Eius sequi deserunt. Nobis distinctio quos. Odio aut est quia impedit dolorum tempora repellat amet. Labore dolores sunt omnis ipsam perferendis illum quo consequatur. Voluptatem necessitatibus molestiae.",
                1,
                36,
                string.Empty,
                null
            },
            {
                47,
                new DateTime(2020, 6, 7, 18, 52, 13, 316, DateTimeKind.Local).AddTicks(1213),
                @"Try to override the HDD sensor, maybe it will override the virtual sensor! System.ArithmeticException: Tasty Metal Pizza Practical Wooden Shoes Fantastic Rubber Bacon
                   at Bogus.DataSets.System.Exception() Aliquid voluptas fugit accusantium rem illum neque nesciunt in. Modi odio voluptas quibusdam dolore dolor dolorem inventore ut. Occaecati unde recusandae optio dolor impedit quia et esse. Blanditiis est iure quas ut laudantium consequatur qui. Non laborum alias error et et qui fuga.",
                1,
                24,
                string.Empty,
                null
            },
            {
                34,
                new DateTime(2020, 6, 7, 8, 50, 23, 24, DateTimeKind.Local).AddTicks(3488),
                @"The SMS sensor is down, copy the solid state sensor so we can copy the SMS sensor! System.IndexOutOfRangeException: Dynamic
                   at Bogus.DataSets.System.Exception() Sit sint laboriosam laudantium accusantium qui cumque doloribus minima. Provident nobis quia delectus eligendi ex debitis molestias aliquid fugiat. At nihil a quidem nobis vel quis sint est. Magni quia aspernatur omnis quam.",
                3,
                7,
                "Soluta ut autem veniam similique. Eum dolor ex est rerum id itaque tenetur ex. Veniam nostrum est.",
                new DateTime(2021, 3, 5, 6, 41, 12, 878, DateTimeKind.Local).AddTicks(6133)
            },
            {
                30,
                new DateTime(2020, 6, 7, 13, 50, 48, 636, DateTimeKind.Local).AddTicks(3709),
                @"I'll reboot the solid state XML driver, that should driver the XML driver! System.ArgumentException: Team-oriented (Parameter 'circuit')
                   at Bogus.DataSets.System.Exception() Quia non ea ipsum animi sed. Quidem nam explicabo quo aut quibusdam est qui. Quisquam accusamus saepe sequi a et. Quibusdam consequatur consequuntur optio odio et id. Dolore impedit ut voluptas corporis.",
                2,
                7,
                string.Empty,
                null
            },
            {
                1,
                new DateTime(2020, 6, 6, 19, 48, 6, 396, DateTimeKind.Local).AddTicks(2010),
                @"Use the virtual SSL firewall, then you can program the virtual firewall! System.FormatException: Chief turquoise Isle
                   at Bogus.DataSets.System.Exception() Cupiditate ipsum qui quasi quia odit accusantium. Ut minima quo occaecati at qui enim labore maxime vero. Quis id repudiandae. Qui enim sunt voluptate in velit repellat. Eius eveniet molestias.",
                1,
                29,
                string.Empty,
                null
            },
            {
                2,
                new DateTime(2020, 6, 7, 9, 41, 1, 671, DateTimeKind.Local).AddTicks(5289),
                @"Use the redundant SAS interface, then you can override the redundant interface! System.BadImageFormatException: Rustic Concrete Tuna
                File name: 'Assurance'
                   at Bogus.DataSets.System.Exception() Ullam maiores est facilis consequatur. Vitae optio qui cumque aut dolor quos dolorum nisi. Quo quo ut illo tempore. Consectetur est ullam enim. Ut non sint dolore veniam.",
                2,
                29,
                string.Empty,
                null
            },
            {
                40,
                new DateTime(2020, 6, 7, 11, 55, 25, 477, DateTimeKind.Local).AddTicks(725),
                @"compressing the feed won't do anything, we need to hack the haptic XSS feed! System.ArgumentException: Cambridgeshire override (Parameter 'Checking Account')
                   at Bogus.DataSets.System.Exception() Quod et dolores hic autem. Molestiae placeat perferendis quia molestiae quidem porro dignissimos. Fuga aut et odit quam et unde ea. Dolor pariatur sed. Aliquam voluptatem voluptate delectus. Sapiente repudiandae placeat rerum et excepturi eos provident facere labore.",
                1,
                29,
                string.Empty,
                null
            },
            {
                11,
                new DateTime(2020, 6, 7, 1, 16, 16, 52, DateTimeKind.Local).AddTicks(9680),
                @"Use the back-end COM circuit, then you can calculate the back-end circuit! System.IO.EndOfStreamException: Credit Card Account navigate Web
                   at Bogus.DataSets.System.Exception() Ab ea ea ex excepturi est corrupti. Quae ut quia ut voluptatem cum quia adipisci. Magnam accusantium libero repudiandae quisquam quisquam modi beatae eius. Ad dolorum quae quo quos. Natus quos iure a iste labore sapiente et.",
                2,
                46,
                string.Empty,
                null
            },
            {
                46,
                new DateTime(2020, 6, 7, 12, 16, 12, 638, DateTimeKind.Local).AddTicks(8080),
                @"The THX array is down, synthesize the haptic array so we can synthesize the THX array! System.IO.FileNotFoundException: File not found...
                File name: '4wdgqdmx.fpw'
                   at Bogus.DataSets.System.Exception() Et et iusto et. Facilis quaerat nihil et sint est est blanditiis dolorem quam. Ullam ullam incidunt culpa culpa soluta excepturi. Sed hic quia odio perspiciatis rem fugit.",
                4,
                46,
                "Quae dolor inventore rem doloribus voluptatem et in consequatur. Sunt dolorem qui consequatur et incidunt qui atque quod omnis. Illum animi deleniti temporibus deleniti molestiae.",
                new DateTime(2021, 6, 28, 7, 35, 52, 233, DateTimeKind.Local).AddTicks(8772)
            },
            {
                5,
                new DateTime(2020, 6, 7, 6, 2, 59, 347, DateTimeKind.Local).AddTicks(8770),
                @"calculating the port won't do anything, we need to quantify the neural SMS port! System.ArgumentException: Finland 24/7 Pakistan Rupee (Parameter 'deliver')
                   at Bogus.DataSets.System.Exception() Illo ut impedit neque nemo. Veniam placeat laudantium doloribus. Et nihil similique et voluptatem reiciendis ipsum. Velit tempora nesciunt totam veniam ipsa. Aperiam sapiente magni cupiditate voluptas delectus pariatur ipsum perferendis. Nulla soluta eum omnis qui quas eos ipsa nesciunt.",
                1,
                50,
                string.Empty,
                null
            },
            {
                24,
                new DateTime(2020, 6, 7, 8, 19, 8, 799, DateTimeKind.Local).AddTicks(3349),
                @"We need to back up the haptic SSL port! System.BadImageFormatException: Associate orange
                File name: 'Awesome Frozen Car'
                   at Bogus.DataSets.System.Exception() Perferendis ratione possimus inventore quasi enim ab aut. Ullam tempora et iste et quibusdam. Unde ut facilis quia. Accusantium modi ipsa facilis est iste ducimus minus corrupti. Necessitatibus sapiente dignissimos ut aut cumque qui.",
                1,
                6,
                string.Empty,
                null
            },
            {
                38,
                new DateTime(2020, 6, 7, 8, 28, 44, 969, DateTimeKind.Local).AddTicks(692),
                @"I'll quantify the optical PCI feed, that should feed the PCI feed! System.NotImplementedException: The method or operation is not implemented.
                   at Bogus.DataSets.System.Exception() Non enim minus et molestiae consequatur. Exercitationem voluptatem sed ad quaerat consequatur alias velit. Reiciendis quaerat facere non numquam ut cupiditate. Facilis voluptatibus enim impedit. Aut velit est exercitationem.",
                3,
                6,
                "Quas tenetur facilis unde ad. Consequatur fuga vel officia omnis animi rem dolor maiores. Aperiam saepe sit est eaque.",
                new DateTime(2022, 2, 24, 8, 55, 25, 213, DateTimeKind.Local).AddTicks(958)
            },
            {
                23,
                new DateTime(2020, 6, 7, 0, 21, 29, 90, DateTimeKind.Local).AddTicks(8195),
                @"Try to bypass the USB bus, maybe it will bypass the open-source bus! System.FormatException: Turkish Lira Sports, Beauty & Jewelery
                   at Bogus.DataSets.System.Exception() Porro debitis repudiandae rerum placeat assumenda consectetur ut. Architecto quam impedit quidem. Maxime possimus aut veritatis atque ut quos neque.",
                1,
                12,
                string.Empty,
                null
            },
            {
                48,
                new DateTime(2020, 6, 6, 22, 14, 29, 307, DateTimeKind.Local).AddTicks(5572),
                @"Use the multi-byte XML card, then you can transmit the multi-byte card! System.NotImplementedException: The method or operation is not implemented.
                   at Bogus.DataSets.System.Exception() Omnis dolores explicabo maxime. Ullam in ab suscipit non repellendus ipsum quis. Impedit adipisci sint voluptatibus doloremque. Illo dicta repellat.",
                2,
                12,
                string.Empty,
                null
            },
            {
                27,
                new DateTime(2020, 6, 7, 17, 12, 6, 558, DateTimeKind.Local).AddTicks(3654),
                @"Try to quantify the SCSI feed, maybe it will quantify the redundant feed! System.FormatException: grid-enabled extensible Branch
                   at Bogus.DataSets.System.Exception() Et temporibus id minima corrupti ut quibusdam suscipit. Aut rerum consequuntur ad ea. Ab aliquam consequuntur. Hic laudantium qui autem. Porro sed sunt deserunt officia consequatur et quam nostrum. Maiores saepe nam laboriosam animi ea explicabo dicta.",
                2,
                31,
                string.Empty,
                null
            },
            {
                8,
                new DateTime(2020, 6, 7, 16, 0, 20, 937, DateTimeKind.Local).AddTicks(2298),
                @"If we back up the hard drive, we can get to the XML hard drive through the solid state XML hard drive! System.FormatException: Investor Turks and Caicos Islands parse
                   at Bogus.DataSets.System.Exception() Quisquam ea sunt consequuntur esse quia tempore vel aut optio. Est illum quis repellat repudiandae deserunt porro. Perspiciatis omnis vel dolores nesciunt vitae. Voluptatibus quidem iure dicta aut ut. Perferendis esse eum voluptatem non quisquam repellendus fugiat sint. Eos ducimus rerum.",
                2,
                17,
                string.Empty,
                null
            },
            {
                33,
                new DateTime(2020, 6, 7, 14, 12, 57, 436, DateTimeKind.Local).AddTicks(5215),
                @"We need to navigate the back-end SSL matrix! System.OutOfMemoryException: Minnesota
                   at Bogus.DataSets.System.Exception() Est labore sapiente ipsum voluptates animi nostrum ducimus vero. Veniam voluptate aut sit consequatur in minus. Quibusdam aut voluptatem rerum sit. Cumque et nemo ut unde.",
                1,
                32,
                string.Empty,
                null
            },
            {
                39,
                new DateTime(2020, 6, 7, 12, 20, 12, 378, DateTimeKind.Local).AddTicks(5526),
                @"The JSON array is down, quantify the primary array so we can quantify the JSON array! System.ArgumentException: quantify Coordinator (Parameter 'Mountains')
                   at Bogus.DataSets.System.Exception() Ratione maiores veniam nam repellendus. Eius earum sed doloribus aspernatur ipsa. Unde sapiente repudiandae vel sed quibusdam inventore velit. Adipisci et ut aperiam. Quae sit eveniet ad expedita in.",
                1,
                32,
                string.Empty,
                null
            },
            {
                28,
                new DateTime(2020, 6, 6, 20, 28, 29, 4, DateTimeKind.Local).AddTicks(4930),
                @"You can't synthesize the hard drive without copying the solid state COM hard drive! System.BadImageFormatException: Officer
                File name: 'Money Market Account'
                   at Bogus.DataSets.System.Exception() Voluptatum autem omnis incidunt consequatur necessitatibus laboriosam. Molestiae qui sed maiores ducimus veniam necessitatibus qui quibusdam ut. Aut doloribus at a. Autem est accusantium iusto.",
                4,
                41,
                "Accusamus velit ad quis voluptas temporibus perferendis. Rem esse officiis natus consequatur. Quia placeat sint eum modi quo. Quam magni iure sint non qui at.",
                new DateTime(2021, 3, 7, 18, 28, 2, 286, DateTimeKind.Local).AddTicks(5765)
            },
            {
                26,
                new DateTime(2020, 6, 6, 19, 25, 49, 776, DateTimeKind.Local).AddTicks(9216),
                @"You can't compress the program without transmitting the neural ADP program! System.NotImplementedException: The method or operation is not implemented.
                   at Bogus.DataSets.System.Exception() Impedit quaerat impedit qui accusamus numquam. Nulla rerum animi et praesentium eius itaque. Accusantium repudiandae doloribus tenetur et aliquam iusto at nobis.",
                4,
                10,
                "Praesentium odit qui facere culpa dolore ab maiores minus. Natus iste architecto deserunt consequuntur odit totam vel ipsum. Corrupti fuga aperiam et ipsa voluptatem ut animi. Sint amet porro. Voluptatum non nam rerum non provident qui omnis. Tempore id consequatur est totam vero.",
                new DateTime(2020, 10, 29, 7, 25, 55, 481, DateTimeKind.Local).AddTicks(5175)
            },
            {
                41,
                new DateTime(2020, 6, 7, 10, 8, 59, 735, DateTimeKind.Local).AddTicks(9207),
                @"If we program the system, we can get to the FTP system through the open-source FTP system! System.NotImplementedException: The method or operation is not implemented.
                   at Bogus.DataSets.System.Exception() Ut quaerat corrupti omnis labore est debitis. Blanditiis voluptatum eveniet nulla reiciendis est quo. Blanditiis dolor reiciendis est atque nostrum qui minus nisi itaque. Corrupti vel odio autem corrupti sunt. Ut id illum architecto rerum.",
                3,
                10,
                "Aliquid sequi et. Rerum in optio adipisci nostrum inventore est rerum unde sit. Placeat voluptas a minus facere non. Soluta nisi eos delectus necessitatibus eos nemo fugiat debitis quibusdam. Veritatis saepe aspernatur sit.",
                new DateTime(2021, 4, 11, 17, 31, 8, 167, DateTimeKind.Local).AddTicks(1370)
            },
            {
                4,
                new DateTime(2020, 6, 7, 10, 24, 10, 188, DateTimeKind.Local).AddTicks(9360),
                @"quantifying the monitor won't do anything, we need to index the 1080p SAS monitor! System.DivideByZeroException: Attempted to divide by zero.
                   at Bogus.DataSets.System.Exception() Et nobis accusantium distinctio non quidem rerum. Dolorem eos neque non deleniti omnis et sapiente iste. Eum sed eum. Optio molestias quod molestias.",
                3,
                16,
                "Harum molestiae numquam natus voluptas rerum. Modi similique aspernatur qui eius eum tempora porro. Dolor eius maiores rerum similique laudantium incidunt impedit.",
                new DateTime(2022, 1, 28, 18, 46, 24, 198, DateTimeKind.Local).AddTicks(5050)
            },
            {
                21,
                new DateTime(2020, 6, 7, 15, 29, 56, 37, DateTimeKind.Local).AddTicks(5103),
                @"We need to quantify the optical PNG card! System.OutOfMemoryException: navigate AI
                   at Bogus.DataSets.System.Exception() Aut qui laudantium deleniti modi. Qui soluta ullam. Et nihil aut est dignissimos. Numquam a veritatis saepe eveniet corrupti nam accusamus et. Autem et consectetur nisi asperiores asperiores necessitatibus voluptate est nemo. Labore autem est sit excepturi rem.",
                1,
                40,
                string.Empty,
                null
            },
            {
                19,
                new DateTime(2020, 6, 7, 10, 3, 18, 649, DateTimeKind.Local).AddTicks(2047),
                @"If we compress the circuit, we can get to the XML circuit through the optical XML circuit! System.ArgumentNullException: North Dakota (Parameter 'function')
                   at Bogus.DataSets.System.Exception() Voluptatem commodi dicta libero omnis reprehenderit fuga suscipit neque. Maiores officiis nostrum. A id suscipit ratione quis minus cupiditate qui. Accusantium iste magni cum aut dignissimos voluptatibus vel doloribus quo. Similique consectetur excepturi alias molestias odio omnis cum.",
                2,
                42,
                string.Empty,
                null
            },
            {
                20,
                new DateTime(2020, 6, 7, 0, 53, 3, 12, DateTimeKind.Local).AddTicks(6470),
                @"If we reboot the alarm, we can get to the XSS alarm through the redundant XSS alarm! System.ArithmeticException: compressing
                   at Bogus.DataSets.System.Exception() Veritatis fugit facilis porro maxime necessitatibus. Est repellat nesciunt rerum. Voluptas modi suscipit quidem. Aut pariatur illo sunt quaerat provident sit ut cupiditate quibusdam. Ut cumque accusamus. Cumque possimus qui necessitatibus et quisquam.",
                2,
                42,
                string.Empty,
                null
            },
            {
                3,
                new DateTime(2020, 6, 7, 4, 59, 19, 55, DateTimeKind.Local).AddTicks(8019),
                @"You can't program the alarm without compressing the haptic RSS alarm! System.BadImageFormatException: Liaison
                File name: 'mobile'
                   at Bogus.DataSets.System.Exception() Est maiores in aut quaerat laborum. Modi quaerat cupiditate consequatur. Reprehenderit a natus. Enim doloribus eius nam.",
                3,
                48,
                "Sint aperiam placeat est qui possimus quo numquam quae. Esse dolor rerum rerum sed voluptatum unde est. Quibusdam aut nisi inventore. Fugit atque sed blanditiis est soluta. Accusantium qui eum autem aut corrupti voluptas.",
                new DateTime(2022, 4, 27, 21, 56, 26, 291, DateTimeKind.Local).AddTicks(3815)
            },
            {
                37,
                new DateTime(2020, 6, 6, 22, 20, 4, 476, DateTimeKind.Local).AddTicks(6233),
                @"transmitting the program won't do anything, we need to index the multi-byte COM program! System.FormatException: portals static
                   at Bogus.DataSets.System.Exception() Adipisci recusandae quae atque voluptatem et qui veniam laudantium eos. Itaque non error molestiae at sunt ducimus quo. Beatae id eum. Perferendis quis debitis blanditiis dolore sunt. Consequuntur eveniet quasi mollitia omnis perferendis aut omnis dolore sed.",
                3,
                17,
                "Hic laborum temporibus deserunt vel. Et ex quisquam a quaerat. Recusandae in nisi cumque voluptatum necessitatibus ex velit repudiandae. Commodi rerum tenetur et quia ut enim. Aut qui accusantium et. Sed delectus sed a temporibus corrupti inventore dolores repudiandae aut.",
                new DateTime(2022, 4, 22, 3, 45, 9, 52, DateTimeKind.Local).AddTicks(8743)
            },
            {
                36,
                new DateTime(2020, 6, 7, 15, 0, 53, 341, DateTimeKind.Local).AddTicks(7832),
                @"The AGP card is down, parse the primary card so we can parse the AGP card! System.ArithmeticException: Auto Loan Account bypassing sexy
                   at Bogus.DataSets.System.Exception() Ut est vitae provident eos ut nostrum sequi praesentium. Distinctio excepturi aut voluptas et incidunt voluptatem. Cumque qui ut debitis non consequuntur enim perferendis. Necessitatibus vel possimus magni est nesciunt qui esse numquam accusamus. Repellendus omnis ut non similique.",
                4,
                34,
                "Eum ea doloribus et incidunt odit. Aut laborum rerum expedita et praesentium quis libero. Est et hic ut.",
                new DateTime(2021, 9, 22, 18, 0, 11, 451, DateTimeKind.Local).AddTicks(478)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Issues");

            migrationBuilder.DropTable(name: "IssueStatusList");

            migrationBuilder.DropTable(name: "ProductOSVersions");

            migrationBuilder.DropTable(name: "OperatingSystems");

            migrationBuilder.DropTable(name: "Products");

            migrationBuilder.DropTable(name: "Versions");
        }
    }
}
