using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_IMDb_Clone.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor() { Id = 1, FullName = "Full Name 1", BirthDay = "01/01/1941" },
                new Actor() { Id = 2, FullName = "Full Name 2", BirthDay = "01/01/1941" },
                new Actor() { Id = 3, FullName = "Full Name 3", BirthDay = "01/01/1941" },
                new Actor() { Id = 4, FullName = "Full Name 4", BirthDay = "01/01/1941" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, CategoryName = "Category1" },
                new Category() { Id = 2, CategoryName = "Category2" },
                new Category() { Id = 3, CategoryName = "Category3" }
                );

            modelBuilder.Entity<Movies>().HasData(
                new Movies() { Id = 1, DirectorFullName = "Director Name", MovieName = "Movie Name 1", Description = "Descrip descrip", ReleaseDate = "01/01/2021" },
                 new Movies() { Id = 2, DirectorFullName = "Director Name", MovieName = "Movie Name 2", Description = "Descrip descrip", ReleaseDate = "01/01/2021" },
                 new Movies() { Id = 3, DirectorFullName = "Director Name", MovieName = "Movie Name 3", Description = "Descrip descrip", ReleaseDate = "01/01/2021" }
                );

            modelBuilder.Entity<Production>().HasData(
                new Production() { Id = 1, ProductionName = "A Company" },
                new Production() { Id = 2, ProductionName = "B Company" }
                );
        }


        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Production> Productions { get; set; }


    }
}
