﻿// <auto-generated />
using System;
using Creative_Harmony.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Creative_Harmony.Migrations
{
    [DbContext(typeof(HarmonyContext))]
    partial class HarmonyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Creative_Harmony.Models.Employees", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.HasKey("ID");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Creative_Harmony.Models.InternalWorks", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<int?>("OurWorksID");

                    b.HasKey("ID");

                    b.HasIndex("OurWorksID");

                    b.ToTable("InternalWorks");
                });

            modelBuilder.Entity("Creative_Harmony.Models.OurWorks", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ourWorks");
                });

            modelBuilder.Entity("Creative_Harmony.Models.Partners", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("partners");
                });

            modelBuilder.Entity("Creative_Harmony.Models.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Creative_Harmony.Models.InternalWorks", b =>
                {
                    b.HasOne("Creative_Harmony.Models.OurWorks")
                        .WithMany("internalWorks")
                        .HasForeignKey("OurWorksID");
                });
#pragma warning restore 612, 618
        }
    }
}
