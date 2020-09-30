using Microsoft.EntityFrameworkCore;
using NewProjectStash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProjectStash.Data
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Breadcakecokkie", Description = "Freshly Baked Choco chip Cookies", Price = 25.50f, ImageName = "bread_cakecookie.jpg" },
                new Product { Id = 2, Name = "CoffeeCup", Description = " Fresh chocolate Coffee", Price = 55.50f, ImageName = "CoffeeCup.jpg" },
                new Product { Id = 3, Name = "SmallCookies", Description = "Jully cookies", Price = 25.50f, ImageName = "SmallCookies.jpg" }
                );

            return builder;
        }
    }
}
