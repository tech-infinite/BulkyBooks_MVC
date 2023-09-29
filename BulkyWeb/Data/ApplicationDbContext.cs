﻿using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            // creates these 3 records in the DB
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Science-Fiction", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Drama", DisplayOrder = 3 }
                );
        }
    }
}
