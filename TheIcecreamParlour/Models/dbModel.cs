namespace TheIcecreamParlour.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<icecream> icecreams { get; set; }
        public virtual DbSet<store_info> store_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<icecream>()
                .Property(e => e.Flavour)
                .IsUnicode(false);

            modelBuilder.Entity<icecream>()
                .HasMany(e => e.store_info)
                .WithRequired(e => e.icecream)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<store_info>()
                .Property(e => e.StoreName)
                .IsUnicode(false);

            modelBuilder.Entity<store_info>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<store_info>()
                .Property(e => e.City)
                .IsUnicode(false);
        }
    }
}
