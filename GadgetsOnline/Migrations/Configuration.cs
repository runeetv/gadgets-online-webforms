namespace GadgetsOnline.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using GadgetsOnline.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<GadgetsOnline.Models.GadgetsOnlineEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GadgetsOnline.Models.GadgetsOnlineEntities context)
        {
            // Add Categories
            var categories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Mobile Phones", Description = "Latest collection of Mobile Phones" },
                new Category { CategoryId = 2, Name = "Laptops", Description = "Latest Laptops in 2022" },
                new Category { CategoryId = 3, Name = "Desktops", Description = "Latest Desktops in 2022" },
                new Category { CategoryId = 4, Name = "Audio", Description = "Latest audio devices" },
                new Category { CategoryId = 5, Name = "Accessories", Description = "USB Cables, Mobile chargers and Keyboards etc" },
            };

            context.Categories.AddOrUpdate(c => c.CategoryId, categories.ToArray());

            // Add Products
            var products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,Name="Phone 12",Price=699.00M,ProductArtUrl="/Content/Images/Mobile/1.jpg"},
                new Product{ProductId=2,CategoryId=1,Name="Phone 13 Pro",Price=999.00M,ProductArtUrl="/Content/Images/Mobile/2.jpg"},
                new Product{ProductId=3,CategoryId=1,Name="Phone 13 Pro Max",Price=1199.00M,ProductArtUrl="/Content/Images/Mobile/3.jpg"},
                new Product{ProductId=4,CategoryId=2,Name="XTS 13'",Price=899.00M,ProductArtUrl="/Content/Images/Laptop/1.jpg"},
                new Product{ProductId=5,CategoryId=2,Name="PC 15.5'",Price=479.00M,ProductArtUrl="/Content/Images/Laptop/2.jpg"},
                new Product{ProductId=6,CategoryId=2,Name="Notebook 14",Price=169.00M,ProductArtUrl="/Content/Images/Laptop/3.jpg"},
                new Product{ProductId=7,CategoryId=3,Name="The IdeaCenter",Price=539.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=8,CategoryId=3,Name="COMP 22-df003w",Price=389.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=9,CategoryId=4,Name="Bluetooth Headphones Over Ear",Price=28.00M,ProductArtUrl="/Content/Images/Headphones/1.png"},
                new Product{ProductId=10,CategoryId=4,Name="ZX Series ",Price=10.00M,ProductArtUrl="/Content/Images/Headphones/2.png"},
                new Product{ProductId=11,CategoryId=5,Name="Charging Cable",Price=23.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=12,CategoryId=5,Name="Mouse Pad",Price=13.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=13,CategoryId=5,Name="Keyboard Cable",Price=9.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=14,CategoryId=5,Name="Gaming Keyboard",Price=89.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=15,CategoryId=5,Name="PC Case",Price=99.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=16,CategoryId=5,Name="Gaming Head Set",Price=199.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=17,CategoryId=5,Name="Screen 27'",Price=319.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=18,CategoryId=3,Name="PC-E series",Price=599.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=19,CategoryId=1,Name="5G Mobile Phone",Price=1299.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{ProductId=20,CategoryId=1,Name="Basic Phone ",Price=99.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
            };

            context.Products.AddOrUpdate(p => p.ProductId, products.ToArray());

            // Create default admin user
            var defaultAdminUser = new AdminUser
            {
                UserId = 1,
                Username = "admin",
                PasswordHash = HashPassword("admin"),
                Email = "admin@gadgetsonline.com",
                IsActive = true,
                CreatedDate = System.DateTime.Now
            };

            context.AdminUsers.AddOrUpdate(u => u.Username, defaultAdminUser);

            context.SaveChanges();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
