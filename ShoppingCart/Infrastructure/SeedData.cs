using Microsoft.EntityFrameworkCore;
using ShoppingCart.Models;

namespace ShoppingCart.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            // Apply any pending migrations
            context.Database.Migrate();

            // Check if the categories are already populated
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Electronics",
                        Slug = "electronics"
                    },
                    new Category
                    {
                        Name = "Clothing",
                        Slug = "clothing"
                    }
                );

                context.SaveChanges();
            }

            // Check if the products are already populated
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Smartphone",
                        Slug = "smartphone",
                        Description = "A high-end smartphone with great features.",
                        Price = 699.99m,
                        CategoryId = context.Categories.Single(c => c.Slug == "electronics").Id,
                        Image = "smartphone.jpg"
                    },
                    new Product
                    {
                        Name = "Laptop",
                        Slug = "laptop",
                        Description = "A powerful laptop for work and play.",
                        Price = 999.99m,
                        CategoryId = context.Categories.Single(c => c.Slug == "electronics").Id,
                        Image = "laptop.jpg"
                    },
                    new Product
                    {
                        Name = "T-Shirt",
                        Slug = "t-shirt",
                        Description = "A comfortable cotton t-shirt.",
                        Price = 19.99m,
                        CategoryId = context.Categories.Single(c => c.Slug == "clothing").Id,
                        Image = "tshirt.jpg"
                    },
                    new Product
                    {
                        Name = "Jeans",
                        Slug = "jeans",
                        Description = "Stylish denim jeans.",
                        Price = 49.99m,
                        CategoryId = context.Categories.Single(c => c.Slug == "clothing").Id,
                        Image = "jeans.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
