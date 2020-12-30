using System;
using eShop_Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eShop_Backend.Core
{
    public partial class eShopContext : DbContext
    {
        public eShopContext()
        {
        }

        public eShopContext(DbContextOptions<eShopContext> options)
            : base(options)
        {
            // test
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Line1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("line1");

                entity.Property(e => e.Line2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("line2");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Pincode).HasColumnName("pincode");

                entity.Property(e => e.State)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__addresses__user___5165187F");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__user_id__52593CB8");
            });

            modelBuilder.Entity<OrdersDetail>(entity =>
            {
                entity.ToTable("orders_details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Price)
                   .HasColumnName("price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__orders_de__order__5441852A");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__orders_de__produ__534D60F1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("image");

                entity.Property(e => e.Images)
                    .HasColumnType("text")
                    .HasColumnName("images");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.ShortDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("short_desc");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__products__cat_id__5535A963");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasDefaultValueSql("('18')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("password_hash");

                entity.Property(e => e.PasswordSalt)
                 .IsRequired()
                 .HasColumnName("password_salt");

                entity.Property(e => e.PhotoUrl)
                    .HasColumnType("text")
                    .HasColumnName("photoUrl");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('555')");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type")
                    .HasDefaultValueSql("('local')");
            
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
