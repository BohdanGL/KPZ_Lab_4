// <auto-generated />
using System;
using Lab_KPZ_3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab_KPZ_3.Migrations
{
    [DbContext(typeof(CarpentryShopDbContext))]
    partial class CarpentryShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "UQ__Carts__1788CC4DBE505F56")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ItemId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UserId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("TypeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.ItemMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ItemMaterials");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.ItemType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "OrderId" }, "UQ__Payments__C3905BCEA65F9B84")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Cart", b =>
                {
                    b.HasOne("Lab_KPZ_3.Data.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Lab_KPZ_3.Data.Models.Cart", "UserId")
                        .HasConstraintName("FK__Carts__UserId__2180FB33")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.CartItem", b =>
                {
                    b.HasOne("Lab_KPZ_3.Data.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .HasConstraintName("FK__CartItems__CartI__245D67DE")
                        .IsRequired();

                    b.HasOne("Lab_KPZ_3.Data.Models.Item", "Item")
                        .WithMany("CartItems")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK__CartItems__ItemI__25518C17")
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Feedback", b =>
                {
                    b.HasOne("Lab_KPZ_3.Data.Models.Item", "Item")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK__Feedbacks__ItemI__3587F3E0")
                        .IsRequired();

                    b.HasOne("Lab_KPZ_3.Data.Models.User", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Feedbacks__UserI__3493CFA7")
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Item", b =>
                {
                    b.HasOne("Lab_KPZ_3.Data.Models.ItemMaterial", "Material")
                        .WithMany("Items")
                        .HasForeignKey("MaterialId")
                        .HasConstraintName("FK__Items__MaterialI__1DB06A4F")
                        .IsRequired();

                    b.HasOne("Lab_KPZ_3.Data.Models.ItemType", "Type")
                        .WithMany("Items")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK__Items__TypeId__1CBC4616")
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Order", b =>
                {
                    b.HasOne("Lab_KPZ_3.Data.Models.OrderStatus", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK__Orders__StatusId__2B0A656D")
                        .IsRequired();

                    b.HasOne("Lab_KPZ_3.Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Orders__UserId__2A164134")
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.OrderItem", b =>
                {
                    b.HasOne("Lab_KPZ_3.Data.Models.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK__OrderItem__ItemI__2EDAF651")
                        .IsRequired();

                    b.HasOne("Lab_KPZ_3.Data.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderItem__Order__2DE6D218")
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Payment", b =>
                {
                    b.HasOne("Lab_KPZ_3.Data.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Lab_KPZ_3.Data.Models.Payment", "OrderId")
                        .HasConstraintName("FK__Payments__OrderI__3B40CD36")
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Item", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Feedbacks");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.ItemMaterial", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.ItemType", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.Order", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Lab_KPZ_3.Data.Models.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
