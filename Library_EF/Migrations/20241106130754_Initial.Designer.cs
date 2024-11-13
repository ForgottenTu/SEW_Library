﻿// <auto-generated />
using System;
using Library_DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_EF.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20241106130754_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Library_DB.AItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AvailableCopies")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AItem");

                    b.HasDiscriminator<string>("BookType").HasValue("AItem");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Library_DB.Fantasy", b =>
                {
                    b.HasBaseType("Library_DB.AItem");

                    b.HasDiscriminator().HasValue("Fantasy");
                });

            modelBuilder.Entity("Library_DB.Mystery", b =>
                {
                    b.HasBaseType("Library_DB.AItem");

                    b.HasDiscriminator().HasValue("Mystery");
                });

            modelBuilder.Entity("Library_DB.NonFiction", b =>
                {
                    b.HasBaseType("Library_DB.AItem");

                    b.HasDiscriminator().HasValue("NonFiction");
                });

            modelBuilder.Entity("Library_DB.Novel", b =>
                {
                    b.HasBaseType("Library_DB.AItem");

                    b.HasDiscriminator().HasValue("Novel");
                });

            modelBuilder.Entity("Library_DB.SciFi", b =>
                {
                    b.HasBaseType("Library_DB.AItem");

                    b.HasDiscriminator().HasValue("SciFi");
                });

            modelBuilder.Entity("Library_DB.Textbook", b =>
                {
                    b.HasBaseType("Library_DB.AItem");

                    b.HasDiscriminator().HasValue("Textbook");
                });
#pragma warning restore 612, 618
        }
    }
}
