﻿// <auto-generated />
using System;
using HackerU.FinalProject.NadavArania.Store.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HackerU.FinalProject.NadavArania.Store.Db.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230701091031_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HackerU.FinalProject.NadavArania.Store.Db.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 7, 1, 12, 10, 30, 831, DateTimeKind.Local).AddTicks(9486),
                            Number = "YA3451123",
                            Quantity = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 7, 1, 12, 10, 30, 831, DateTimeKind.Local).AddTicks(9519),
                            Number = "GH223499",
                            Quantity = 2,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("HackerU.FinalProject.NadavArania.Store.Db.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 1,
                            TotalPrice = 48.990000000000002
                        },
                        new
                        {
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 1,
                            TotalPrice = 29.989999999999998
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 3,
                            Quantity = 1,
                            TotalPrice = 16.989999999999998
                        },
                        new
                        {
                            OrderId = 2,
                            ProductId = 4,
                            Quantity = 1,
                            TotalPrice = 34.990000000000002
                        });
                });

            modelBuilder.Entity("HackerU.FinalProject.NadavArania.Store.Db.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 0,
                            Description = "Play advanced without wires or limits. logitech G305 LIGHTSPEED is a wireless gaming mouse designed for high-performance in your favorite PC games. G305 features the next-gen logitech G HERO optical sensor with 200 to 12,000 DPI sensitivity for competition-level accuracy. LIGHTSPEED wireless technology gives you super-fast 1 millisecond performance that’s as fast as wired. With incredible power-efficiency, G305 stays powered and ready to play for up to 250 hours on a single included AA battery.  Play anywhere with an ultra-portable, lightweight gaming mouse that weighs in at only 99 grams, is easy to take with you, and has built-in storage for the included USB wireless receiver. Use logitech Gaming Software to quickly program 6 buttons with instant multi-action commands, DPI settings and more. G305 is the LIGHTSPEED wireless mouse for all.",
                            Image = "https://m.media-amazon.com/images/I/51DYDLykzoL._AC_UY327_QL65_.jpg",
                            Name = "Logitech G305 LIGHTSPEED Wireless Gaming Mouse",
                            Price = 48.990000000000002,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Category = 0,
                            Description = "The Razer DeathAdder essential retains the classic ergonomic form that's been a hallmark of previous Razer DeathAdder generations. Its sleek and distinct body is designed for comfort, allowing you to maintain high levels of performance throughout long gaming marathons, so you'll never falter in the heat of battle.",
                            Image = "https://m.media-amazon.com/images/I/8189uwDnMkL._AC_UY327_QL65_.jpg",
                            Name = "Razer DeathAdder Essential Gaming Mouse",
                            Price = 29.989999999999998,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Category = 0,
                            Description = "Classic 6-button design to make the most of your playtime with game-grade sensors. Dazzling RGB lighting effects light up your game and table. ",
                            Image = "https://m.media-amazon.com/images/I/61DP9FeE6KL._AC_UY327_QL65_.jpg",
                            Name = "DIERYA X TMKB Wired Gaming Mouse",
                            Price = 16.989999999999998,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Category = 1,
                            Description = "The apex 3 is your first step into next level gaming. Built from the ground up with intuitive gaming-focused features like water resistance, 10-zone RGB, whisper quiet gaming switches, and gaming grade anti-ghosting, the apex 3 has just what you need to outshine, outperform, and outlast the competition.",
                            Image = "https://m.media-amazon.com/images/I/81L8fk7SGQL._AC_UY327_QL65_.jpg",
                            Name = "SteelSeries Apex 3 RGB Gaming Keyboard",
                            Price = 34.990000000000002,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            Category = 1,
                            Description = "Logitech G PRO Mechanical Gaming Keyboard League of Legends Edition This Logitech G PRO backlit keyboard is designed to inspire League of Legends players. Built for pro gamers from the bottom up. A compact tenkeyless design frees up desk space for low-sens mousing. Durable GX Brown Tactile Switches deliver discernable feedback without being too loud or distracting. Programmable LIGHTSYNC RGB and onboard memory lets you customize and store a lighting pattern for gaming tournaments. The computer keyboard comes with a detachable USB cable, making for easy transport. Part of a collection forged by magic, tempered by science and wielded by champions. Product details: Weight (w/out cable): 34.6 oz (980 g) Dimensions: 6 x 14.2 x 1.4 in (153 x 361 x 34 mm) Cable length: 6 ft System requirements: USB 2.0 port Platform compatibility: Windows 10, 8.1, 8 or 7.",
                            Image = "https://m.media-amazon.com/images/I/71TyGobdfQL._AC_UY327_QL65_.jpg",
                            Name = "Logitech G PRO Mechanical Gaming Keyboard",
                            Price = 29.989999999999998,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 6,
                            Category = 1,
                            Description = "Empower your play with a centerpiece that elevates your entire setup. Enter the next phase of battlestation evolution with the ultimate mechanical gaming keyboard. Take full command with a set of features designed for advanced control, and enhance your immersion with full-blown Razer Chroma RGB.",
                            Image = "https://m.media-amazon.com/images/I/81L4FpeS3VL._AC_UY327_QL65_.jpg",
                            Name = "Razer BlackWidow V4 Pro Wired Mechanical Gaming Keyboard",
                            Price = 229.99000000000001,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 7,
                            Category = 2,
                            Description = "HyperX Cloud II features a newly designed USB sound card audio control box that amplifies audio and voice for an optimal Hi Fi gaming experience, so you can hear what you’ve been missing. Open up a world of detail other gamers will never know — the rustle of a camper’s boot, the scuttle in a distant vent. This next generation headset generates virtual 7.1 surround sound with distance and depth to enhance your gaming, movie or music experience. The headset must be selected as the default audio device in your sound settings. For Windows: 1. Open up Control Panel and select Hardware and Sound and then select Sound. 2. If the “HyperX 7.1 Audio” is not currently the default audio device, right click on the option and select “Set as Default Device.” 3. This should place a green check mark next to the default audio device. Repeat the same steps for the microphone portion of the headset, located under the “Recording” tab (also found in the Sound program in Control Panel.) For Mac: 1. Click the Apple menu and select “System Preferences” from the drop down menu. 2. In “System Preferences”, click on the ‘Sound’ icon. 3. Click on the Input tab and select “HyperX 7.1 Audio” for default sound input. 4. Click on the Output tab and select “HyperX 7.1 Audio” for default sound output. Note: The headset may appear as USB audio instead of HyperX 7.1 Audio. Hear the rich, impactful sounds of your games with clarity and precision.",
                            Image = "https://m.media-amazon.com/images/I/71M5l+O4OFL._AC_UY327_QL65_.jpg",
                            Name = "HyperX Cloud II - Gaming Headset",
                            Price = 62.990000000000002,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 8,
                            Category = 2,
                            Description = "Arctic challenges everything you know about gaming headsets with completely overhauled audio, a new mic design with unmatched clarity, and improved comfort with materials inspired by athletic clothing. Arctic 5 features RGB illumination, game/chat audio balance, and DTS headphone: x v2.0 7.1 surround. The arctic 5 can be connected both through USB to a pc, mac, or ps4 or with the included 3.5mm adapter for Xbox, switch, and mobile devices. Some features such as chat mix, surround sound, and illumination are only available when connected via USB.",
                            Image = "https://m.media-amazon.com/images/I/81Y9BnR2+hL._AC_UY327_QL65_.jpg",
                            Name = "SteelSeries Arctis 5 - RGB Illuminated Gaming Headset",
                            Price = 49.990000000000002,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 9,
                            Category = 2,
                            Description = "If esports is everything, give it your all with the Razer BlackShark V2. Introducing a triple threat of amazing audio, superior mic clarity and supreme sound isolation. Fitted with titanium-coated drivers, a USB sound card, softer ear cushions and THX Spatial Audio, your time to turn pro is now.Microphone Sensitivity: -42 dB V/Pa, 1 kHz.",
                            Image = "https://m.media-amazon.com/images/I/61wrOi+03FL._AC_UY327_QL65_.jpg",
                            Name = "Razer BlackShark V2 Gaming Headset",
                            Price = 99.989999999999995,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 10,
                            Category = 3,
                            Description = "27inch pc monitor HDMI 1.4 supports a 120HZ refresh rate, and DP 1.2 supports a 165HZ refresh rate. improving image clarity for all action-packed game sequences and graphic design projects. Comes with an AUDIO audio output interface, supports external headphones and external speaker audio output. ",
                            Image = "https://m.media-amazon.com/images/I/61sqwnf7fgL._AC_UY327_QL65_.jpg",
                            Name = "CRUA 27 144hz / 165HZ Curved Gaming Monitor",
                            Price = 159.99000000000001,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 11,
                            Category = 3,
                            Description = "24 Diagonal viewable curved screen HDMI, VGA & PC audio in ports Windows 10 compatible Contemporary sleek metal design with the C248W - 1920RN, a slender 1800R screen curvature yields wide - ranging images that seemingly surround you.Protection and comfort are the hallmarks of this design as the metal pattern brush finish is smooth and pleasing to the touch. 1080P resolution(1920 x 1080 pixels) provides stunning color and picture detail on a 24 inch screen.Enjoy HDMI or VGA input to connect all video and gaming devices.Contrast Ratio : 3000: 1",
                            Image = "https://m.media-amazon.com/images/I/71P0M7tKjYL._AC_UY327_QL65_.jpg",
                            Name = "Sceptre 24 Curved 75Hz Gaming LED Monitor",
                            Price = 109.98999999999999,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 12,
                            Category = 3,
                            Description = "Immerse yourself in your favorite games with this fast IPS monitor featuring a 1ms (GtG) response time, wide viewing angles, and high color accuracy with sRGB 99%. See moving objects on the screen more clearly with a high native 144 Hz refresh rate and 1ms Motion Blur Reduction. NVIDIA G-SYNC and AMD FreeSync Premium support virtually eliminates screen tearing and minimize stutter in high-resolution and fast-paced games for a fast and fluid gaming experience with supported video cards. Dynamic Action Sync reduces input lag and elevates your gameplay, allowing you to respond to your opponents quickly, while Black Stabilizer allows you to see them more clearly in the dark. Use the Crosshair feature for enhanced vision and precision in first-person shooters. Adjust the tilt, height, and pivot for the best ergonomics, ensuring that you have the most comfortable viewing position to play your games.",
                            Image = "https://m.media-amazon.com/images/I/81dAe2wXIqL._AC_UY327_QL65_.jpg",
                            Name = "LG UltraGear QHD 27-Inch Gaming Monitor",
                            Price = 246.99000000000001,
                            Quantity = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 13,
                            Category = 4,
                            Description = "Efomao Office has been focusing on providing the most cost - effective office chairs for 10 years.Our chairs are sold to many countries, including the U.S., Canada, Europe, Japan and other countries.They are popular with local consumers.The biggest special feature of this chair is its comfort. When you sit on it, you will feel the whole person is wrapped in the soft cushion, you will feel very comfortable.And it also looks very beautiful.",
                            Image = "https://m.media-amazon.com/images/I/71oTC9OzoFL._AC_UL600_QL65_.jpg",
                            Name = "Efomao Desk Office Chair",
                            Price = 111.98999999999999,
                            Quantity = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 14,
                            Category = 4,
                            Description = "Ergonomic office chair home office desk chairs study chair computer chair ",
                            Image = "https://m.media-amazon.com/images/I/81kRleg-keL._AC_UL600_QL65_.jpg",
                            Name = "Monhey Office Chair - Ergonomic Office Chair",
                            Price = 105.98999999999999,
                            Quantity = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 15,
                            Category = 4,
                            Description = "SIHOO focuses on the field of ergonomics, our ergonomic office chairs are designed with fashionable modern office chair to sit health life as design purposes, scientifically measure health and comfortable seats, provide you with a comfortable, reasonable, scientific Health sitting posture experience.",
                            Image = "https://m.media-amazon.com/images/I/61DJ4TR8FQL._AC_UL600_QL65_.jpg",
                            Name = "SIHOO M18 Ergonomic Office Chair",
                            Price = 169.99000000000001,
                            Quantity = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 16,
                            Category = 5,
                            Description = " The MONOMI height adjustable desk helps create a healthier work environment by allowing you to move throughout your day. Switching between sitting and standing throughout a long workday provides several health benefits for the body, such as increased blood flow and enhanced posture.Our electric standing desk is made of good quality and each has been tested more than ten inspection processes before assembling to the desk.The motor is uses an advanced motor with longer service life,each motor can be used more than 10,000 times and durable. ",
                            Image = "https://m.media-amazon.com/images/I/61eXhYo0p8L._AC_UL600_QL65_.jpg",
                            Name = "Monomi Electric Standing Desk, Height Adjustable Desk",
                            Price = 239.99000000000001,
                            Quantity = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 17,
                            Category = 5,
                            Description = "Enjoy the moment with your new computer desk, inject a bit of glam into everday life.",
                            Image = "https://m.media-amazon.com/images/I/81Fzr+gckSL._AC_UL600_QL65_.jpg",
                            Name = "CubiCubi 40 Inch Small L Shaped Computer Desk",
                            Price = 89.989999999999995,
                            Quantity = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 18,
                            Category = 5,
                            Description = "Our table is made of high-quality board and iron. The unique engineering design allows the table to have more storage space while being more stable and sturdy, meeting the requirements of daily use and being more durable.",
                            Image = "https://m.media-amazon.com/images/I/81i4FGL17CL._AC_UL600_QL65_.jpg",
                            Name = "JOISCOPE Home Office Computer",
                            Price = 79.989999999999995,
                            Quantity = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 19,
                            Category = 6,
                            Description = "This USB powered light, which stands at approximately 8 inches tall, is in the design of the iconic dinosaur Yoshi’s egg from the Super Mario game series. Fans will love the warming glow it will add to their nightstand, desk, man cave, nursery, or playroom!",
                            Image = "https://m.media-amazon.com/images/I/61fb4nCU6dL._AC_UL600_QL65_.jpg",
                            Name = "Paladone Yoshi Egg Light 8 in x 7",
                            Price = 29.989999999999998,
                            Quantity = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 20,
                            Category = 6,
                            Description = "202 built-in nostalgic games bring back the fun of an arcade in this handheld gaming cabinet. 5 inch color display. Joystick and button controls for realistic arcade machine play, Plus full color hires, 2.5” LCD screen makes all of the games come alive portable, play in your hands for convenience or on a table/desk for gaming stability. Authentic game sounds to enhance play, Plus a volume control to make mom Happy! Runs on 3 AA standard alkaline batteries for hours of – running, shooting, driving high speed, sports, and education games; data storage drive capacity: No built-in storage",
                            Image = "https://m.media-amazon.com/images/I/61iL+huvXrL._AC_UL600_QL65_.jpg",
                            Name = "My Arcade Retro Machine Playable Mini Arcade",
                            Price = 26.989999999999998,
                            Quantity = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 21,
                            Category = 6,
                            Description = "Young gamers can now join forces and game with their favorite characters from the Super Mario series.",
                            Image = "https://m.media-amazon.com/images/I/71fjY3yAy9L._AC_UL600_QL65_.jpg",
                            Name = "X Rocker Official Super Mario Video Rocker",
                            Price = 97.989999999999995,
                            Quantity = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 22,
                            Category = 6,
                            Description = "Your setup is your world. From broadcasting and editing to designing, developing, networking - everything you need one interface to control your myriad apps and tools.",
                            Image = "https://m.media-amazon.com/images/I/71AsjjEAwqL._AC_UY327_QL65_.jpg",
                            Name = "Elgato Stream Deck MK.2 – Studio Controller",
                            Price = 149.99000000000001,
                            Quantity = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 23,
                            Category = 6,
                            Description = "Pixel Frames bring iconic moments from your favorite video games out of the screen and into your living room! These officially licensed shadow boxes are snapshots that perfectly convey your love for retro gaming - bringing a bit of nostalgia to life! Available in 6x6 and 9x9 frames.",
                            Image = "https://m.media-amazon.com/images/I/81czjCT0zFL._AC_UL600_QL65_.jpg",
                            Name = "Pixel Frames: Sonic The Hedgehog Loop Scene",
                            Price = 29.989999999999998,
                            Quantity = 1,
                            Type = 2
                        },
                        new
                        {
                            Id = 24,
                            Category = 6,
                            Description = " These DNDND 100 sided metal dice, 50MM diameter, net weight of 420 grams, very good feel and balance very well.Packed with a metal case and a velvet bag.Great Gift idea for dnd player and dice collector! ",
                            Image = "https://m.media-amazon.com/images/I/811C83EEz7L._AC_UL600_QL65_.jpg",
                            Name = "DNDND Old Brass D100 Dice Metal Single",
                            Price = 39.990000000000002,
                            Quantity = 1,
                            Type = 2
                        });
                });

            modelBuilder.Entity("HackerU.FinalProject.NadavArania.Store.Db.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Herzal 5",
                            City = "Tel Aviv",
                            Email = "admin@email.com",
                            Password = "ya12!mmo",
                            Phone = "0567811234",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Address = "Yamim 18",
                            City = "Netanya",
                            Email = "regUser@email.com",
                            Password = "4rt@4abc",
                            Phone = "0538912341",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Address = "Giborim 9",
                            City = "Beersheva",
                            Email = "mike_north154@email.com",
                            Password = "i8per!mn",
                            Phone = "0529088453",
                            Type = 1
                        });
                });

            modelBuilder.Entity("HackerU.FinalProject.NadavArania.Store.Db.Models.Order", b =>
                {
                    b.HasOne("HackerU.FinalProject.NadavArania.Store.Db.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HackerU.FinalProject.NadavArania.Store.Db.Models.OrderProduct", b =>
                {
                    b.HasOne("HackerU.FinalProject.NadavArania.Store.Db.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackerU.FinalProject.NadavArania.Store.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("HackerU.FinalProject.NadavArania.Store.Db.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
