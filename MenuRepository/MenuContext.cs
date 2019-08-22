
using MenuRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuRepository
{
    internal class MenuContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemOption> ItemOptions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Selection> Selections { get; set; }

        public MenuContext(DbContextOptions<MenuContext> options)
              : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Item>()
                .HasIndex(i=>i.ShopID);
            modelBuilder.Entity<Item>()
                .HasIndex(c => new { c.ShopID, c.Name })
                .IsUnique();
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Shop)
                .WithMany(s => s.Items)
                .HasForeignKey(i => i.ShopID);
            
            modelBuilder.Entity<ItemOption>()
               .HasIndex(c => new { c.ID, c.ItemID, c.OptionID })
               .IsUnique();
            modelBuilder.Entity<ItemOption>()
                .HasOne(i => i.Item)
                .WithMany(s => s.ItemOptions)
                .HasForeignKey(i => i.ItemID);
            modelBuilder.Entity<ItemOption>()
                .HasOne(i => i.Option)
                .WithMany(s => s.ItemOptions)
                .HasForeignKey(i => i.OptionID);

            modelBuilder.Entity<Selection>()
                .HasOne(i => i.Option)
                .WithMany(s => s.Selections)
                .HasForeignKey(i => i.OptionID);
        }
    }
}
