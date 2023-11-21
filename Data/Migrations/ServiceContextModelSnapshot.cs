﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ServiceContext))]
    partial class ServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Gallery1Item", b =>
                {
                    b.Property<int>("Id_gallery1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_gallery1"));

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_gallery1");

                    b.ToTable("Gallery1", (string)null);
                });

            modelBuilder.Entity("Entities.Gallery2Item", b =>
                {
                    b.Property<int>("Id_gallery2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_gallery2"));

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_gallery2");

                    b.ToTable("Gallery2", (string)null);
                });

            modelBuilder.Entity("Entities.MembersItems", b =>
                {
                    b.Property<int>("Id_Members")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Members"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("holder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iban")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("members")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("services")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("termsAccepted")
                        .HasColumnType("bit");

                    b.HasKey("Id_Members");

                    b.ToTable("Members", (string)null);
                });

            modelBuilder.Entity("Entities.NewsItem", b =>
                {
                    b.Property<int>("Id_News")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_News"));

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_News");

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("Entities.UsersItems", b =>
                {
                    b.Property<int>("Id_Users")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Users"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Users");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Entities.VolunteersItems", b =>
                {
                    b.Property<int>("Id_Volunteers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Volunteers"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birthdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shift")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("termsAccepted")
                        .HasColumnType("bit");

                    b.HasKey("Id_Volunteers");

                    b.ToTable("Volunteers", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
