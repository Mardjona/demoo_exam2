using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demo_exam.Models;

namespace demo_exam.Context;

public partial class User11028Context : DbContext
{
    public User11028Context()
    {
    }

    public User11028Context(DbContextOptions<User11028Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159;Database=user11028;Username=user11028;password=58271");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("order_pk");

            entity.ToTable("order");

            entity.Property(e => e.OrderId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("order_id");
            entity.Property(e => e.OrderDeliveryDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("order_delivery_date");
            entity.Property(e => e.OrderPickupPoint).HasColumnName("order_pickup_point");
            entity.Property(e => e.OrderStatus)
                .HasColumnType("character varying")
                .HasColumnName("order_status");

            entity.HasMany(d => d.Products).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "Orderproduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("orderproduct_product_fk"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("orderproduct_order_fk"),
                    j =>
                    {
                        j.HasKey("OrderId", "ProductId").HasName("orderproduct_pk");
                        j.ToTable("orderproduct");
                        j.IndexerProperty<int>("OrderId")
                            .ValueGeneratedOnAdd()
                            .UseIdentityAlwaysColumn()
                            .HasColumnName("order_id");
                        j.IndexerProperty<int>("ProductId")
                            .ValueGeneratedOnAdd()
                            .UseIdentityAlwaysColumn()
                            .HasColumnName("product_id");
                    });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_pk");

            entity.ToTable("product");

            entity.Property(e => e.ProductId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("product_id");
            entity.Property(e => e.ProdductDscription)
                .HasColumnType("character varying")
                .HasColumnName("prodduct_dscription");
            entity.Property(e => e.ProductArticle)
                .HasColumnType("character varying")
                .HasColumnName("product_article");
            entity.Property(e => e.ProductCategory)
                .HasColumnType("character varying")
                .HasColumnName("product_category");
            entity.Property(e => e.ProductCost).HasColumnName("product_cost");
            entity.Property(e => e.ProductDiscountAmount).HasColumnName("product_discount_amount");
            entity.Property(e => e.ProductFacturer).HasColumnName("product_facturer");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPhoto)
                .HasColumnType("character varying")
                .HasColumnName("product_photo");
            entity.Property(e => e.ProductQuantityInstock).HasColumnName("product_quantity_instock");
            entity.Property(e => e.ProductStatus).HasColumnName("product_status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pk");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasColumnType("character varying")
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("user_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserLogin)
                .HasColumnType("character varying")
                .HasColumnName("user_login");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
            entity.Property(e => e.UserPassword)
                .HasColumnType("character varying")
                .HasColumnName("user_password");
            entity.Property(e => e.UserPatronomic)
                .HasColumnType("character varying")
                .HasColumnName("user_patronomic");
            entity.Property(e => e.UserSurname)
                .HasColumnType("character varying")
                .HasColumnName("user_surname");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_role_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
