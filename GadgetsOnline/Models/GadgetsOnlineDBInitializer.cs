using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;


namespace GadgetsOnline.Models
{
    public class GadgetsOnlineDBInitializer : DropCreateDatabaseIfModelChanges<GadgetsOnlineEntities>
    {
        protected override void Seed(GadgetsOnlineEntities context)
        {
            IList<Category> categories = new List<Category>
            {
                new Category { Name = "Mobile Phones", Description = "Latest collection of Mobile Phones" } ,
                new Category { Name = "Laptops", Description = "Latest Laptops in 2022" } ,
                new Category { Name = "Desktops", Description = "Latest Desktops in 2022" } ,
                new Category { Name = "Audio", Description = "Latest audio devices" } ,
                new Category { Name = "Accessories", Description = "USB Cables, Mobile chargers and Keyboards etc" } ,
            };

            context.Categories.AddRange(categories);

            IList<Product> products = new List<Product>
            {
                new Product{CategoryId=1,Name="Phone 12",Price=699.00M,ProductArtUrl="/Content/Images/Mobile/1.jpg"},
                new Product{CategoryId=1,Name="Phone 13 Pro",Price=999.00M,ProductArtUrl="/Content/Images/Mobile/2.jpg"},
                new Product{CategoryId=1,Name="Phone 13 Pro Max",Price=1199.00M,ProductArtUrl="/Content/Images/Mobile/3.jpg"},
                new Product{CategoryId=2,Name="XTS 13'",Price=899.00M,ProductArtUrl="/Content/Images/Laptop/1.jpg"},
                new Product{CategoryId=2,Name="PC 15.5'",Price=479.00M,ProductArtUrl="/Content/Images/Laptop/2.jpg"},
                new Product{CategoryId=2,Name="Notebook 14",Price=169.00M,ProductArtUrl="/Content/Images/Laptop/3.jpg"},
                new Product{CategoryId=3,Name="The IdeaCenter",Price=539.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=3,Name="COMP 22-df003w",Price=389.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=4,Name="Bluetooth Headphones Over Ear",Price=28.00M,ProductArtUrl="/Content/Images/Headphones/1.png"},
                new Product{CategoryId=4,Name="ZX Series ",Price=10.00M,ProductArtUrl="/Content/Images/Headphones/2.png"},

                new Product{CategoryId=5,Name="Charging Cable",Price=23.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=5,Name="Mouse Pad",Price=13.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=5,Name="Keyboard Cable",Price=9.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=5,Name="Gaming Keyboard",Price=89.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=5,Name="PC Case",Price=99.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=5,Name="Gaming Head Set",Price=199.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=5,Name="Screen 27'",Price=319.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=3,Name="PC-E series",Price=599.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=1,Name="5G Mobile Phone",Price=1299.00M,ProductArtUrl="/Content/Images/placeholder.gif"},
                new Product{CategoryId=1,Name="Basic Phone ",Price=99.00M,ProductArtUrl="/Content/Images/placeholder.gif"},

            };

            context.Products.AddRange(products);

            // Create default admin user
            var defaultAdminUser = new AdminUser
            {
                Username = "admin",
                PasswordHash = HashPassword("admin"),
                Email = "admin@gadgetsonline.com",
                IsActive = true,
                CreatedDate = System.DateTime.Now
            };

            context.AdminUsers.Add(defaultAdminUser);

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