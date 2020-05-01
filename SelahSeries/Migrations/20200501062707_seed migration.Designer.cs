﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelahSeries.Data;

namespace SelahSeries.Migrations
{
    [DbContext(typeof(SelahSeriesDataContext))]
    [Migration("20200501062707_seed migration")]
    partial class seedmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SelahSeries.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Title");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SelahSeries.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(50);

                    b.Property<int?>("CommentId1");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("ParentId");

                    b.Property<int>("PostId");

                    b.HasKey("CommentId");

                    b.HasIndex("CommentId1");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SelahSeries.Models.HardBook", b =>
                {
                    b.Property<int>("HardBookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(50);

                    b.Property<int?>("CategoryId");

                    b.Property<int>("CatergoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("HardBookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("HardBooks");
                });

            modelBuilder.Entity("SelahSeries.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int?>("HardBookId");

                    b.Property<decimal>("Price");

                    b.Property<int>("ShippingAddress");

                    b.Property<int>("quantity");

                    b.HasKey("OrderId");

                    b.HasIndex("HardBookId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SelahSeries.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(50);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int?>("ParentId");

                    b.Property<bool>("Published");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("TitleImageUrl")
                        .HasMaxLength(100);

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SelahSeries.Models.SoftBook", b =>
                {
                    b.Property<int>("SoftBookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(50);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("Downloads");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100);

                    b.Property<string>("Location")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("SoftBookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SoftBooks");
                });

            modelBuilder.Entity("SelahSeries.Models.Comment", b =>
                {
                    b.HasOne("SelahSeries.Models.Comment")
                        .WithMany("ChildrenComments")
                        .HasForeignKey("CommentId1");

                    b.HasOne("SelahSeries.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SelahSeries.Models.HardBook", b =>
                {
                    b.HasOne("SelahSeries.Models.Category")
                        .WithMany("HardBooks")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("SelahSeries.Models.Order", b =>
                {
                    b.HasOne("SelahSeries.Models.HardBook", "HardBook")
                        .WithMany()
                        .HasForeignKey("HardBookId");
                });

            modelBuilder.Entity("SelahSeries.Models.Post", b =>
                {
                    b.HasOne("SelahSeries.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SelahSeries.Models.SoftBook", b =>
                {
                    b.HasOne("SelahSeries.Models.Category")
                        .WithMany("SoftBooks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
