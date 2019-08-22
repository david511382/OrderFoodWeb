﻿// <auto-generated />
using MenuRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MenuRepository.Migrations
{
    [DbContext(typeof(MenuContext))]
    [Migration("20190803021825_MenuInitialCreate")]
    partial class MenuInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MenuRepository.Models.Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Price");

                    b.Property<int>("ShopID");

                    b.HasKey("ID");

                    b.HasIndex("ShopID");

                    b.HasIndex("ShopID", "Name")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("MenuRepository.Models.ItemOption", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemID");

                    b.Property<int>("OptionID");

                    b.HasKey("ID");

                    b.HasIndex("ItemID");

                    b.HasIndex("OptionID");

                    b.HasIndex("ID", "ItemID", "OptionID")
                        .IsUnique();

                    b.ToTable("ItemOptions");
                });

            modelBuilder.Entity("MenuRepository.Models.Option", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SelectNum");

                    b.HasKey("ID");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("MenuRepository.Models.Selection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("OptionID");

                    b.Property<int>("Price");

                    b.HasKey("ID");

                    b.HasIndex("OptionID");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("MenuRepository.Models.Shop", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("MenuRepository.Models.Item", b =>
                {
                    b.HasOne("MenuRepository.Models.Shop", "Shop")
                        .WithMany("Items")
                        .HasForeignKey("ShopID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MenuRepository.Models.ItemOption", b =>
                {
                    b.HasOne("MenuRepository.Models.Item", "Item")
                        .WithMany("ItemOptions")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MenuRepository.Models.Option", "Option")
                        .WithMany("ItemOptions")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MenuRepository.Models.Selection", b =>
                {
                    b.HasOne("MenuRepository.Models.Option", "Option")
                        .WithMany("Selections")
                        .HasForeignKey("OptionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
