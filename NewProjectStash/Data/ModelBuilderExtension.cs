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
                new Product { Id = 1, Name = "breadcakecokkie", Description = "Freshly Baked Choco chip Cookies", Price = 25.50f, ImageName = "bread_cakecokkie.jpg" },
                new Product { Id = 2, Name = "CoffeeCup", Description = "Delicious Baked Croissant", Price = 55.50f, ImageName = "CoffeeCup.jpg" },
                new Product { Id = 3, Name = "SmallCookies", Description = "Chololate Donut", Price = 25.50f, ImageName = "SmallCookies.jpg" }
                );

            return builder;
        }
    }
}
