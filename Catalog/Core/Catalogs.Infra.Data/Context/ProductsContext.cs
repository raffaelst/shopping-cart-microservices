using Catalogs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Catalogs.Infra.Data.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
        protected ProductsContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProductsContext).Assembly);

            builder
                .Entity<Product>(u =>
                {
                    u.HasKey(b => b.ProductId);
                    u.Property(b => b.ProductId).UseIdentityColumn();
                });

            builder.Entity<Product>().ToTable("Products").HasData(
                new Product { ProductId = 1, Title = "iPhone9", Price = 549, Stock = 94, Brand = "Apple", Thumbnail = "https://dummyjson.com/image/i/products/1/thumbnail.jpg", Description = "An apple mobile which is nothing like apple" },
                new Product { ProductId = 2, Title = "iPhone X", Price = 899, Stock = 34, Brand = "Apple", Thumbnail = "https://dummyjson.com/image/i/products/2/thumbnail.jpg", Description = "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ..." },
                new Product { ProductId = 3, Title = "Samsung Universe 9", Price = 1249, Stock = 36, Brand = "Samsung", Thumbnail = "https://dummyjson.com/image/i/products/3/thumbnail.jpg", Description = "Samsung's new variant which goes beyond Galaxy to the Universe" },
                new Product { ProductId = 4, Title = "OPPOF19", Price = 280, Stock = 123, Brand = "OPPO", Thumbnail = "https://dummyjson.com/image/i/products/4/thumbnail.jpg", Description = "OPPO F19 is officially announced on April 2021." },
                new Product { ProductId = 5, Title = "Huawei P30", Price = 499, Stock = 32, Brand = "Huawei", Thumbnail = "https://dummyjson.com/image/i/products/5/thumbnail.jpg", Description = "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK." },
                new Product { ProductId = 6, Title = "MacBook Pro", Price = 1749, Stock = 83, Brand = "Apple", Thumbnail = "https://dummyjson.com/image/i/products/6/thumbnail.png", Description = "MacBook Pro 2021 with mini-LED display may launch between September, November" },
                new Product { ProductId = 7, Title = "Samsung Galaxy Book", Price = 1499, Stock = 50, Brand = "Samsung", Thumbnail = "https://dummyjson.com/image/i/products/7/thumbnail.jpg", Description = "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched" },
                new Product { ProductId = 8, Title = "Microsoft Surface Laptop 4", Price = 1499, Stock = 68, Brand = "Microsoft Surface", Thumbnail = "https://dummyjson.com/image/i/products/8/thumbnail.jpg", Description = "Style and speed. Stand out on HD video calls backed by Studio Mics. Capture ideas on the vibrant touchscreen." },
                new Product { ProductId = 9, Title = "Infinix INBOOK", Price = 1099, Stock = 96, Brand = "Infinix", Thumbnail = "https://dummyjson.com/image/i/products/9/thumbnail.jpg", Description = "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty" },
                new Product { ProductId = 10, Title = "HP Pavilion 15-DK1056WM", Price = 1099, Stock = 89, Brand = "HP Pavilion", Thumbnail = "https://dummyjson.com/image/i/products/10/thumbnail.jpeg", Description = "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10" },
                new Product { ProductId = 11, Title = "perfume Oil", Price = 13, Stock = 65, Brand = "Impression of Acqua Di Gio", Thumbnail = "https://dummyjson.com/image/i/products/11/thumbnail.jpg", Description = "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil" },
                new Product { ProductId = 12, Title = "Brown Perfume", Price = 40, Stock = 52, Brand = "Royal_Mirage", Thumbnail = "https://dummyjson.com/image/i/products/12/thumbnail.jpg", Description = "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml" },
                new Product { ProductId = 13, Title = "Fog Scent Xpressio Perfume", Price = 13, Stock = 61, Brand = "Fog Scent Xpressio", Thumbnail = "https://dummyjson.com/image/i/products/13/thumbnail.webp", Description = "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men" },
                new Product { ProductId = 14, Title = "Non-Alcoholic Concentrated Perfume Oil", Price = 120, Stock = 114, Brand = "Al Munakh", Thumbnail = "https://dummyjson.com/image/i/products/14/thumbnail.jpg", Description = "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil" },
                new Product { ProductId = 15, Title = "Eau De Perfume Spray", Price = 30, Stock = 105, Brand = "Lord - Al-Rehab", Thumbnail = "https://dummyjson.com/image/i/products/15/thumbnail.jpg", Description = "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality" },
                new Product { ProductId = 16, Title = "Hyaluronic Acid Serum", Price = 19, Stock = 110, Brand = "L'Oreal Paris", Thumbnail = "https://dummyjson.com/image/i/products/16/thumbnail.jpg", Description = "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic Acid" },
                new Product { ProductId = 17, Title = "Tree Oil 30ml", Price = 12, Stock = 78, Brand = "Hemani Tea", Thumbnail = "https://dummyjson.com/image/i/products/17/thumbnail.jpg", Description = "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria," },
                new Product { ProductId = 18, Title = "Oil Free Moisturizer 100ml", Price = 40, Stock = 88, Brand = "ROREC White Rice", Thumbnail = "https://dummyjson.com/image/i/products/18/thumbnail.jpg", Description = "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramides, hyaluronic acid & sunscreen." },
                new Product { ProductId = 19, Title = "Skin Beauty Serum", Price = 46, Stock = 54, Brand = "ROREC White Rice", Thumbnail = "https://dummyjson.com/image/i/products/19/thumbnail.jpg", Description = "Product name: rorec collagen hyaluronic acid white face serum riceNet weight: 15 m" },
                new Product { ProductId = 20, Title = "Freckle Treatment Cream- 15gm", Price = 70, Stock = 140, Brand = "Fair & Clear", Thumbnail = "https://dummyjson.com/image/i/products/20/thumbnail.jpg", Description = "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no side effects." },
                new Product { ProductId = 21, Title = "Daal Masoor 500 grams", Price = 20, Stock = 133, Brand = "Saaf & Khaas", Thumbnail = "https://dummyjson.com/image/i/products/21/thumbnail.png", Description = "Fine quality Branded Product Keep in a cool and dry place" });
        }


        public void MigrateDB()
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(10, r => TimeSpan.FromSeconds(10))
                .Execute(() => Database.Migrate());
        }
    }
}
