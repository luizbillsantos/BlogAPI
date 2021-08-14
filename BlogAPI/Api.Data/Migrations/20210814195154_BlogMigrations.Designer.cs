﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210814195154_BlogMigrations")]
    partial class BlogMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("GeoId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Suite")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("GeoId");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Lapa",
                            CreateAt = new DateTime(2021, 8, 14, 16, 51, 53, 979, DateTimeKind.Local).AddTicks(3556),
                            GeoId = 1,
                            Street = "Estrada do Lara",
                            Suite = "Casa",
                            UpdateAt = new DateTime(2021, 8, 14, 16, 51, 53, 979, DateTimeKind.Local).AddTicks(3562),
                            ZipCode = "83750-000"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.AlbumEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(244)
                        .HasColumnType("nvarchar(244)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Api.Domain.Entities.BlogPostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(244)
                        .HasColumnType("nvarchar(244)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("BlogPost");
                });

            modelBuilder.Entity("Api.Domain.Entities.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(244)
                        .HasColumnType("nvarchar(244)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Api.Domain.Entities.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bs")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CatchPhrase")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(244)
                        .HasColumnType("nvarchar(244)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bs = "Meu Teste Técnico",
                            CatchPhrase = "Teste",
                            CreateAt = new DateTime(2021, 8, 14, 16, 51, 53, 976, DateTimeKind.Local).AddTicks(2403),
                            Name = "BillSoft",
                            UpdateAt = new DateTime(2021, 8, 14, 16, 51, 53, 977, DateTimeKind.Local).AddTicks(2661)
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.GeoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Lat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Lng")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Geo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateAt = new DateTime(2021, 8, 14, 16, 51, 53, 979, DateTimeKind.Local).AddTicks(2489),
                            Lat = -25.722589m,
                            Lng = -49.763019m,
                            UpdateAt = new DateTime(2021, 8, 14, 16, 51, 53, 979, DateTimeKind.Local).AddTicks(2519)
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.PhotoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasMaxLength(244)
                        .HasColumnType("nvarchar(244)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(244)
                        .HasColumnType("nvarchar(244)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(244)
                        .HasColumnType("nvarchar(244)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WebSite")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            CompanyId = 1,
                            CreateAt = new DateTime(2021, 8, 14, 16, 51, 53, 979, DateTimeKind.Local).AddTicks(7691),
                            Email = "luizbillsantos@gmail.com",
                            Name = "Administrador",
                            UpdateAt = new DateTime(2021, 8, 14, 16, 51, 53, 979, DateTimeKind.Local).AddTicks(7703),
                            UserName = "luizbillsantos"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.AddressEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.GeoEntity", "Geo")
                        .WithMany("Addressess")
                        .HasForeignKey("GeoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Geo");
                });

            modelBuilder.Entity("Api.Domain.Entities.AlbumEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.UserEntity", "User")
                        .WithMany("Albums")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Entities.BlogPostEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.UserEntity", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Entities.CommentEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.BlogPostEntity", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Api.Domain.Entities.PhotoEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.AlbumEntity", "Album")
                        .WithMany("Photos")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.AddressEntity", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.CompanyEntity", "Company")
                        .WithMany("User")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Api.Domain.Entities.AlbumEntity", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Api.Domain.Entities.BlogPostEntity", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Api.Domain.Entities.CompanyEntity", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.Domain.Entities.GeoEntity", b =>
                {
                    b.Navigation("Addressess");
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
