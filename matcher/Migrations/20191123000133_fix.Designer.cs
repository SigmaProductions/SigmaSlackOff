﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sigmaslackoff;

namespace matcher.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191123000133_fix")]
    partial class fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("sigmaslackoff.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("game")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("sigmaslackoff.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .HasColumnType("TEXT");

                    b.Property<string>("roomId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("roomId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("sigmaslackoff.User", b =>
                {
                    b.HasOne("sigmaslackoff.Room", "room")
                        .WithMany("users")
                        .HasForeignKey("roomId");
                });
#pragma warning restore 612, 618
        }
    }
}
