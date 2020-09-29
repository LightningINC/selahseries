﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelahSeries.Data;

namespace SelahSeries.Migrations
{
    [DbContext(typeof(SelahSeriesDataContext))]
    partial class SelahSeriesDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SelahSeries.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasMaxLength(50);

                    b.Property<string>("BookUrl")
                        .HasMaxLength(100);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100);

                    b.Property<bool>("IsHardBook");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("Price");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");
                });

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

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<int?>("ParentCommentId");

                    b.Property<int>("PostId");

                    b.HasKey("CommentId");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SelahSeries.Models.EmailSubscription", b =>
                {
                    b.Property<int>("EmailSubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ConfirmEmail");

                    b.Property<string>("ConfirmationCode");

                    b.Property<string>("SubscriberEmail");

                    b.HasKey("EmailSubscriptionId");

                    b.ToTable("EmailSubscriptions");
                });

            modelBuilder.Entity("SelahSeries.Models.HardBook", b =>
                {
                    b.Property<int>("HardBookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Price");

                    b.HasKey("HardBookId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("CategoryId");

                    b.ToTable("HardBooks");
                });

            modelBuilder.Entity("SelahSeries.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<bool>("Read");

                    b.Property<string>("Title");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SelahSeries.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int?>("HardBookId");

                    b.Property<double>("Price");

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

                    b.Property<string>("FacebookPostLink");

                    b.Property<string>("LinkedInPostLink");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<int?>("ParentId");

                    b.Property<bool>("Published");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("TitleImageUrl")
                        .HasMaxLength(100);

                    b.Property<string>("TwitterPostLink");

                    b.HasKey("PostId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SelahSeries.Models.PostClap", b =>
                {
                    b.Property<int>("PostClapId");

                    b.Property<int>("Claps");

                    b.HasKey("PostClapId");

                    b.ToTable("PostClaps");
                });

            modelBuilder.Entity("SelahSeries.Models.SoftBook", b =>
                {
                    b.Property<int>("SoftBookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int?>("CategoryId");

                    b.Property<int>("Downloads");

                    b.Property<string>("Location");

                    b.HasKey("SoftBookId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("CategoryId");

                    b.ToTable("SoftBooks");
                });

            modelBuilder.Entity("SelahSeries.Models.Book", b =>
                {
                    b.HasOne("SelahSeries.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SelahSeries.Models.Comment", b =>
                {
                    b.HasOne("SelahSeries.Models.Comment", "Parent")
                        .WithMany("Replies")
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("SelahSeries.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SelahSeries.Models.HardBook", b =>
                {
                    b.HasOne("SelahSeries.Models.Book", "Book")
                        .WithOne("HardBook")
                        .HasForeignKey("SelahSeries.Models.HardBook", "BookId")
                        .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity("SelahSeries.Models.PostClap", b =>
                {
                    b.HasOne("SelahSeries.Models.Post", "Post")
                        .WithOne("postClap")
                        .HasForeignKey("SelahSeries.Models.PostClap", "PostClapId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SelahSeries.Models.SoftBook", b =>
                {
                    b.HasOne("SelahSeries.Models.Book", "Book")
                        .WithOne("SoftBook")
                        .HasForeignKey("SelahSeries.Models.SoftBook", "BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SelahSeries.Models.Category")
                        .WithMany("SoftBooks")
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
