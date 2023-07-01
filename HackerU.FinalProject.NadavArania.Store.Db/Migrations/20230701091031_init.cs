using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackerU.FinalProject.NadavArania.Store.Db.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, 0, "Play advanced without wires or limits. logitech G305 LIGHTSPEED is a wireless gaming mouse designed for high-performance in your favorite PC games. G305 features the next-gen logitech G HERO optical sensor with 200 to 12,000 DPI sensitivity for competition-level accuracy. LIGHTSPEED wireless technology gives you super-fast 1 millisecond performance that’s as fast as wired. With incredible power-efficiency, G305 stays powered and ready to play for up to 250 hours on a single included AA battery.  Play anywhere with an ultra-portable, lightweight gaming mouse that weighs in at only 99 grams, is easy to take with you, and has built-in storage for the included USB wireless receiver. Use logitech Gaming Software to quickly program 6 buttons with instant multi-action commands, DPI settings and more. G305 is the LIGHTSPEED wireless mouse for all.", "https://m.media-amazon.com/images/I/51DYDLykzoL._AC_UY327_QL65_.jpg", "Logitech G305 LIGHTSPEED Wireless Gaming Mouse", 48.990000000000002, 1, 0 },
                    { 2, 0, "The Razer DeathAdder essential retains the classic ergonomic form that's been a hallmark of previous Razer DeathAdder generations. Its sleek and distinct body is designed for comfort, allowing you to maintain high levels of performance throughout long gaming marathons, so you'll never falter in the heat of battle.", "https://m.media-amazon.com/images/I/8189uwDnMkL._AC_UY327_QL65_.jpg", "Razer DeathAdder Essential Gaming Mouse", 29.989999999999998, 1, 0 },
                    { 3, 0, "Classic 6-button design to make the most of your playtime with game-grade sensors. Dazzling RGB lighting effects light up your game and table. ", "https://m.media-amazon.com/images/I/61DP9FeE6KL._AC_UY327_QL65_.jpg", "DIERYA X TMKB Wired Gaming Mouse", 16.989999999999998, 1, 0 },
                    { 4, 1, "The apex 3 is your first step into next level gaming. Built from the ground up with intuitive gaming-focused features like water resistance, 10-zone RGB, whisper quiet gaming switches, and gaming grade anti-ghosting, the apex 3 has just what you need to outshine, outperform, and outlast the competition.", "https://m.media-amazon.com/images/I/81L8fk7SGQL._AC_UY327_QL65_.jpg", "SteelSeries Apex 3 RGB Gaming Keyboard", 34.990000000000002, 1, 0 },
                    { 5, 1, "Logitech G PRO Mechanical Gaming Keyboard League of Legends Edition This Logitech G PRO backlit keyboard is designed to inspire League of Legends players. Built for pro gamers from the bottom up. A compact tenkeyless design frees up desk space for low-sens mousing. Durable GX Brown Tactile Switches deliver discernable feedback without being too loud or distracting. Programmable LIGHTSYNC RGB and onboard memory lets you customize and store a lighting pattern for gaming tournaments. The computer keyboard comes with a detachable USB cable, making for easy transport. Part of a collection forged by magic, tempered by science and wielded by champions. Product details: Weight (w/out cable): 34.6 oz (980 g) Dimensions: 6 x 14.2 x 1.4 in (153 x 361 x 34 mm) Cable length: 6 ft System requirements: USB 2.0 port Platform compatibility: Windows 10, 8.1, 8 or 7.", "https://m.media-amazon.com/images/I/71TyGobdfQL._AC_UY327_QL65_.jpg", "Logitech G PRO Mechanical Gaming Keyboard", 29.989999999999998, 1, 0 },
                    { 6, 1, "Empower your play with a centerpiece that elevates your entire setup. Enter the next phase of battlestation evolution with the ultimate mechanical gaming keyboard. Take full command with a set of features designed for advanced control, and enhance your immersion with full-blown Razer Chroma RGB.", "https://m.media-amazon.com/images/I/81L4FpeS3VL._AC_UY327_QL65_.jpg", "Razer BlackWidow V4 Pro Wired Mechanical Gaming Keyboard", 229.99000000000001, 1, 0 },
                    { 7, 2, "HyperX Cloud II features a newly designed USB sound card audio control box that amplifies audio and voice for an optimal Hi Fi gaming experience, so you can hear what you’ve been missing. Open up a world of detail other gamers will never know — the rustle of a camper’s boot, the scuttle in a distant vent. This next generation headset generates virtual 7.1 surround sound with distance and depth to enhance your gaming, movie or music experience. The headset must be selected as the default audio device in your sound settings. For Windows: 1. Open up Control Panel and select Hardware and Sound and then select Sound. 2. If the “HyperX 7.1 Audio” is not currently the default audio device, right click on the option and select “Set as Default Device.” 3. This should place a green check mark next to the default audio device. Repeat the same steps for the microphone portion of the headset, located under the “Recording” tab (also found in the Sound program in Control Panel.) For Mac: 1. Click the Apple menu and select “System Preferences” from the drop down menu. 2. In “System Preferences”, click on the ‘Sound’ icon. 3. Click on the Input tab and select “HyperX 7.1 Audio” for default sound input. 4. Click on the Output tab and select “HyperX 7.1 Audio” for default sound output. Note: The headset may appear as USB audio instead of HyperX 7.1 Audio. Hear the rich, impactful sounds of your games with clarity and precision.", "https://m.media-amazon.com/images/I/71M5l+O4OFL._AC_UY327_QL65_.jpg", "HyperX Cloud II - Gaming Headset", 62.990000000000002, 1, 0 },
                    { 8, 2, "Arctic challenges everything you know about gaming headsets with completely overhauled audio, a new mic design with unmatched clarity, and improved comfort with materials inspired by athletic clothing. Arctic 5 features RGB illumination, game/chat audio balance, and DTS headphone: x v2.0 7.1 surround. The arctic 5 can be connected both through USB to a pc, mac, or ps4 or with the included 3.5mm adapter for Xbox, switch, and mobile devices. Some features such as chat mix, surround sound, and illumination are only available when connected via USB.", "https://m.media-amazon.com/images/I/81Y9BnR2+hL._AC_UY327_QL65_.jpg", "SteelSeries Arctis 5 - RGB Illuminated Gaming Headset", 49.990000000000002, 1, 0 },
                    { 9, 2, "If esports is everything, give it your all with the Razer BlackShark V2. Introducing a triple threat of amazing audio, superior mic clarity and supreme sound isolation. Fitted with titanium-coated drivers, a USB sound card, softer ear cushions and THX Spatial Audio, your time to turn pro is now.Microphone Sensitivity: -42 dB V/Pa, 1 kHz.", "https://m.media-amazon.com/images/I/61wrOi+03FL._AC_UY327_QL65_.jpg", "Razer BlackShark V2 Gaming Headset", 99.989999999999995, 1, 0 },
                    { 10, 3, "27inch pc monitor HDMI 1.4 supports a 120HZ refresh rate, and DP 1.2 supports a 165HZ refresh rate. improving image clarity for all action-packed game sequences and graphic design projects. Comes with an AUDIO audio output interface, supports external headphones and external speaker audio output. ", "https://m.media-amazon.com/images/I/61sqwnf7fgL._AC_UY327_QL65_.jpg", "CRUA 27 144hz / 165HZ Curved Gaming Monitor", 159.99000000000001, 1, 0 },
                    { 11, 3, "24 Diagonal viewable curved screen HDMI, VGA & PC audio in ports Windows 10 compatible Contemporary sleek metal design with the C248W - 1920RN, a slender 1800R screen curvature yields wide - ranging images that seemingly surround you.Protection and comfort are the hallmarks of this design as the metal pattern brush finish is smooth and pleasing to the touch. 1080P resolution(1920 x 1080 pixels) provides stunning color and picture detail on a 24 inch screen.Enjoy HDMI or VGA input to connect all video and gaming devices.Contrast Ratio : 3000: 1", "https://m.media-amazon.com/images/I/71P0M7tKjYL._AC_UY327_QL65_.jpg", "Sceptre 24 Curved 75Hz Gaming LED Monitor", 109.98999999999999, 1, 0 },
                    { 12, 3, "Immerse yourself in your favorite games with this fast IPS monitor featuring a 1ms (GtG) response time, wide viewing angles, and high color accuracy with sRGB 99%. See moving objects on the screen more clearly with a high native 144 Hz refresh rate and 1ms Motion Blur Reduction. NVIDIA G-SYNC and AMD FreeSync Premium support virtually eliminates screen tearing and minimize stutter in high-resolution and fast-paced games for a fast and fluid gaming experience with supported video cards. Dynamic Action Sync reduces input lag and elevates your gameplay, allowing you to respond to your opponents quickly, while Black Stabilizer allows you to see them more clearly in the dark. Use the Crosshair feature for enhanced vision and precision in first-person shooters. Adjust the tilt, height, and pivot for the best ergonomics, ensuring that you have the most comfortable viewing position to play your games.", "https://m.media-amazon.com/images/I/81dAe2wXIqL._AC_UY327_QL65_.jpg", "LG UltraGear QHD 27-Inch Gaming Monitor", 246.99000000000001, 1, 0 },
                    { 13, 4, "Efomao Office has been focusing on providing the most cost - effective office chairs for 10 years.Our chairs are sold to many countries, including the U.S., Canada, Europe, Japan and other countries.They are popular with local consumers.The biggest special feature of this chair is its comfort. When you sit on it, you will feel the whole person is wrapped in the soft cushion, you will feel very comfortable.And it also looks very beautiful.", "https://m.media-amazon.com/images/I/71oTC9OzoFL._AC_UL600_QL65_.jpg", "Efomao Desk Office Chair", 111.98999999999999, 1, 1 },
                    { 14, 4, "Ergonomic office chair home office desk chairs study chair computer chair ", "https://m.media-amazon.com/images/I/81kRleg-keL._AC_UL600_QL65_.jpg", "Monhey Office Chair - Ergonomic Office Chair", 105.98999999999999, 1, 1 },
                    { 15, 4, "SIHOO focuses on the field of ergonomics, our ergonomic office chairs are designed with fashionable modern office chair to sit health life as design purposes, scientifically measure health and comfortable seats, provide you with a comfortable, reasonable, scientific Health sitting posture experience.", "https://m.media-amazon.com/images/I/61DJ4TR8FQL._AC_UL600_QL65_.jpg", "SIHOO M18 Ergonomic Office Chair", 169.99000000000001, 1, 1 },
                    { 16, 5, " The MONOMI height adjustable desk helps create a healthier work environment by allowing you to move throughout your day. Switching between sitting and standing throughout a long workday provides several health benefits for the body, such as increased blood flow and enhanced posture.Our electric standing desk is made of good quality and each has been tested more than ten inspection processes before assembling to the desk.The motor is uses an advanced motor with longer service life,each motor can be used more than 10,000 times and durable. ", "https://m.media-amazon.com/images/I/61eXhYo0p8L._AC_UL600_QL65_.jpg", "Monomi Electric Standing Desk, Height Adjustable Desk", 239.99000000000001, 1, 1 },
                    { 17, 5, "Enjoy the moment with your new computer desk, inject a bit of glam into everday life.", "https://m.media-amazon.com/images/I/81Fzr+gckSL._AC_UL600_QL65_.jpg", "CubiCubi 40 Inch Small L Shaped Computer Desk", 89.989999999999995, 1, 1 },
                    { 18, 5, "Our table is made of high-quality board and iron. The unique engineering design allows the table to have more storage space while being more stable and sturdy, meeting the requirements of daily use and being more durable.", "https://m.media-amazon.com/images/I/81i4FGL17CL._AC_UL600_QL65_.jpg", "JOISCOPE Home Office Computer", 79.989999999999995, 1, 1 },
                    { 19, 6, "This USB powered light, which stands at approximately 8 inches tall, is in the design of the iconic dinosaur Yoshi’s egg from the Super Mario game series. Fans will love the warming glow it will add to their nightstand, desk, man cave, nursery, or playroom!", "https://m.media-amazon.com/images/I/61fb4nCU6dL._AC_UL600_QL65_.jpg", "Paladone Yoshi Egg Light 8 in x 7", 29.989999999999998, 1, 2 },
                    { 20, 6, "202 built-in nostalgic games bring back the fun of an arcade in this handheld gaming cabinet. 5 inch color display. Joystick and button controls for realistic arcade machine play, Plus full color hires, 2.5” LCD screen makes all of the games come alive portable, play in your hands for convenience or on a table/desk for gaming stability. Authentic game sounds to enhance play, Plus a volume control to make mom Happy! Runs on 3 AA standard alkaline batteries for hours of – running, shooting, driving high speed, sports, and education games; data storage drive capacity: No built-in storage", "https://m.media-amazon.com/images/I/61iL+huvXrL._AC_UL600_QL65_.jpg", "My Arcade Retro Machine Playable Mini Arcade", 26.989999999999998, 1, 2 },
                    { 21, 6, "Young gamers can now join forces and game with their favorite characters from the Super Mario series.", "https://m.media-amazon.com/images/I/71fjY3yAy9L._AC_UL600_QL65_.jpg", "X Rocker Official Super Mario Video Rocker", 97.989999999999995, 1, 2 },
                    { 22, 6, "Your setup is your world. From broadcasting and editing to designing, developing, networking - everything you need one interface to control your myriad apps and tools.", "https://m.media-amazon.com/images/I/71AsjjEAwqL._AC_UY327_QL65_.jpg", "Elgato Stream Deck MK.2 – Studio Controller", 149.99000000000001, 1, 2 },
                    { 23, 6, "Pixel Frames bring iconic moments from your favorite video games out of the screen and into your living room! These officially licensed shadow boxes are snapshots that perfectly convey your love for retro gaming - bringing a bit of nostalgia to life! Available in 6x6 and 9x9 frames.", "https://m.media-amazon.com/images/I/81czjCT0zFL._AC_UL600_QL65_.jpg", "Pixel Frames: Sonic The Hedgehog Loop Scene", 29.989999999999998, 1, 2 },
                    { 24, 6, " These DNDND 100 sided metal dice, 50MM diameter, net weight of 420 grams, very good feel and balance very well.Packed with a metal case and a velvet bag.Great Gift idea for dnd player and dice collector! ", "https://m.media-amazon.com/images/I/811C83EEz7L._AC_UL600_QL65_.jpg", "DNDND Old Brass D100 Dice Metal Single", 39.990000000000002, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Password", "Phone", "Type" },
                values: new object[,]
                {
                    { 1, "Herzal 5", "Tel Aviv", "admin@email.com", "ya12!mmo", "0567811234", 0 },
                    { 2, "Yamim 18", "Netanya", "regUser@email.com", "4rt@4abc", "0538912341", 1 },
                    { 3, "Giborim 9", "Beersheva", "mike_north154@email.com", "i8per!mn", "0529088453", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Number", "Quantity", "UserId" },
                values: new object[] { 1, new DateTime(2023, 7, 1, 12, 10, 30, 831, DateTimeKind.Local).AddTicks(9486), "YA3451123", 2, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Number", "Quantity", "UserId" },
                values: new object[] { 2, new DateTime(2023, 7, 1, 12, 10, 30, 831, DateTimeKind.Local).AddTicks(9519), "GH223499", 2, 3 });

            migrationBuilder.InsertData(
                table: "OrdersProducts",
                columns: new[] { "OrderId", "ProductId", "Quantity", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 48.990000000000002 },
                    { 1, 2, 1, 29.989999999999998 },
                    { 2, 3, 1, 16.989999999999998 },
                    { 2, 4, 1, 34.990000000000002 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
