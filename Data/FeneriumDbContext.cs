using Core.Entities;
using Core.Entities.Bases;
using Core.Entities.Categories;
using Core.Entities.Clothes;
using Core.Entities.Colors;
using Core.Entities.ManyToManys;
using Core.Entities.Slider;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Data
{
    public class FeneriumDbContext : IdentityDbContext<AppUser>
    {
        public FeneriumDbContext(DbContextOptions<FeneriumDbContext> options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Kazak> Kazaks { get; set; }
        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
        public DbSet<Mayo> Mayos { get; set; }
        public DbSet<Shorts> Shorts { get; set; }
        public DbSet<Socks> Socks { get; set; }
        public DbSet<Sweetshirt> Sweetshirts { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
    }
}