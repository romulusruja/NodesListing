﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodesListing.API.Data;

#nullable disable

namespace NodesListing.API.Migrations
{
    [DbContext(typeof(NodeListingDbContext))]
    partial class NodeListingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NodesListing.API.Data.Country", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Code = "RO",
                            Name = "Romania"
                        });
                });

            modelBuilder.Entity("NodesListing.API.Data.HostConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DirectoryServicePort")
                        .HasColumnType("int");

                    b.Property<string>("Hostname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OnionServicePort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HostConfigurations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectoryServicePort = 8080,
                            Hostname = "localhost",
                            OnionServicePort = 3000
                        },
                        new
                        {
                            Id = 2,
                            DirectoryServicePort = 8081,
                            Hostname = "localhost",
                            OnionServicePort = 3001
                        });
                });

            modelBuilder.Entity("NodesListing.API.Data.Node", b =>
                {
                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("HostConfigurationId")
                        .HasColumnType("int");

                    b.Property<string>("PublicKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Address");

                    b.HasIndex("CountryCode");

                    b.HasIndex("HostConfigurationId")
                        .IsUnique()
                        .HasFilter("[HostConfigurationId] IS NOT NULL");

                    b.ToTable("Nodes");

                    b.HasData(
                        new
                        {
                            Address = "node-1",
                            CountryCode = "RO",
                            HostConfigurationId = 1,
                            PublicKey = "public-key-1"
                        },
                        new
                        {
                            Address = "node-2",
                            CountryCode = "RO",
                            HostConfigurationId = 2,
                            PublicKey = "public-key-2"
                        });
                });

            modelBuilder.Entity("NodesListing.API.Data.Node", b =>
                {
                    b.HasOne("NodesListing.API.Data.Country", "Country")
                        .WithMany("Nodes")
                        .HasForeignKey("CountryCode");

                    b.HasOne("NodesListing.API.Data.HostConfiguration", "HostConfiguration")
                        .WithOne("Node")
                        .HasForeignKey("NodesListing.API.Data.Node", "HostConfigurationId");

                    b.Navigation("Country");

                    b.Navigation("HostConfiguration");
                });

            modelBuilder.Entity("NodesListing.API.Data.Country", b =>
                {
                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("NodesListing.API.Data.HostConfiguration", b =>
                {
                    b.Navigation("Node");
                });
#pragma warning restore 612, 618
        }
    }
}
