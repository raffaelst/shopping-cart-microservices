using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogs.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Brand", "Description", "Price", "Stock", "Thumbnail", "Title" },
                values: new object[,]
                {
                    { 1L, "Apple", "An apple mobile which is nothing like apple", 549m, 94, "https://dummyjson.com/image/i/products/1/thumbnail.jpg", "iPhone9" },
                    { 2L, "Apple", "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...", 899m, 34, "https://dummyjson.com/image/i/products/2/thumbnail.jpg", "iPhone X" },
                    { 3L, "Samsung", "Samsung's new variant which goes beyond Galaxy to the Universe", 1249m, 36, "https://dummyjson.com/image/i/products/3/thumbnail.jpg", "Samsung Universe 9" },
                    { 4L, "OPPO", "OPPO F19 is officially announced on April 2021.", 280m, 123, "https://dummyjson.com/image/i/products/4/thumbnail.jpg", "OPPOF19" },
                    { 5L, "Huawei", "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.", 499m, 32, "https://dummyjson.com/image/i/products/5/thumbnail.jpg", "Huawei P30" },
                    { 6L, "Apple", "MacBook Pro 2021 with mini-LED display may launch between September, November", 1749m, 83, "https://dummyjson.com/image/i/products/6/thumbnail.png", "MacBook Pro" },
                    { 7L, "Samsung", "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched", 1499m, 50, "https://dummyjson.com/image/i/products/7/thumbnail.jpg", "Samsung Galaxy Book" },
                    { 8L, "Microsoft Surface", "Style and speed. Stand out on HD video calls backed by Studio Mics. Capture ideas on the vibrant touchscreen.", 1499m, 68, "https://dummyjson.com/image/i/products/8/thumbnail.jpg", "Microsoft Surface Laptop 4" },
                    { 9L, "Infinix", "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty", 1099m, 96, "https://dummyjson.com/image/i/products/9/thumbnail.jpg", "Infinix INBOOK" },
                    { 10L, "HP Pavilion", "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10", 1099m, 89, "https://dummyjson.com/image/i/products/10/thumbnail.jpeg", "HP Pavilion 15-DK1056WM" },
                    { 11L, "Impression of Acqua Di Gio", "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil", 13m, 65, "https://dummyjson.com/image/i/products/11/thumbnail.jpg", "perfume Oil" },
                    { 12L, "Royal_Mirage", "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml", 40m, 52, "https://dummyjson.com/image/i/products/12/thumbnail.jpg", "Brown Perfume" },
                    { 13L, "Fog Scent Xpressio", "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men", 13m, 61, "https://dummyjson.com/image/i/products/13/thumbnail.webp", "Fog Scent Xpressio Perfume" },
                    { 14L, "Al Munakh", "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil", 120m, 114, "https://dummyjson.com/image/i/products/14/thumbnail.jpg", "Non-Alcoholic Concentrated Perfume Oil" },
                    { 15L, "Lord - Al-Rehab", "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality", 30m, 105, "https://dummyjson.com/image/i/products/15/thumbnail.jpg", "Eau De Perfume Spray" },
                    { 16L, "L'Oreal Paris", "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic Acid", 19m, 110, "https://dummyjson.com/image/i/products/16/thumbnail.jpg", "Hyaluronic Acid Serum" },
                    { 17L, "Hemani Tea", "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria,", 12m, 78, "https://dummyjson.com/image/i/products/17/thumbnail.jpg", "Tree Oil 30ml" },
                    { 18L, "ROREC White Rice", "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramides, hyaluronic acid & sunscreen.", 40m, 88, "https://dummyjson.com/image/i/products/18/thumbnail.jpg", "Oil Free Moisturizer 100ml" },
                    { 19L, "ROREC White Rice", "Product name: rorec collagen hyaluronic acid white face serum riceNet weight: 15 m", 46m, 54, "https://dummyjson.com/image/i/products/19/thumbnail.jpg", "Skin Beauty Serum" },
                    { 20L, "Fair & Clear", "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no side effects.", 70m, 140, "https://dummyjson.com/image/i/products/20/thumbnail.jpg", "Freckle Treatment Cream- 15gm" },
                    { 21L, "Saaf & Khaas", "Fine quality Branded Product Keep in a cool and dry place", 20m, 133, "https://dummyjson.com/image/i/products/21/thumbnail.png", "Daal Masoor 500 grams" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
