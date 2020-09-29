using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewProjectStash.Data.Configurations;
using NewProjectStash.Models;



namespace NewProjectStash.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            builder.ApplyConfiguration(new ProductConfiguration()).SeedData();
            // ModelBuilderExtension.SeedData(builder);
            base.OnModelCreating(builder);
        }
    }
}
