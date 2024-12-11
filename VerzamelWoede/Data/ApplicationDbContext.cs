using Humanizer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VerzamelWoede.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VerzamelWoede.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Collection>()
            .HasKey(c => new { c.ItemId, c.UserId });

            builder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c =>c.Items)
                .HasForeignKey(i => i.CategoryId);

            builder.Entity<ApplicationUser>()
                .HasMany(p => p.Collections)
                .WithOne(c => c.User)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Item>()
                .HasMany(i => i.Collections)
                .WithOne(c => c.Item)
                .HasForeignKey(c => c.ItemId);
        }
    }
}
