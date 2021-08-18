using System.Data.Common;
using System.Data.Entity;
using UnipCRUD.Models;

namespace UnipCRUD.Database
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbConnection existingConnection, bool contextOwnsConnection = true)
            : base(existingConnection, contextOwnsConnection) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO: move configurations to EntityTypeConfiguration file

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Code);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Category)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(5, 2)
                .IsRequired();
        }
    }
}
