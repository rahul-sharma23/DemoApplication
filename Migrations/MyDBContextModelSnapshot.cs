﻿// <auto-generated />
using System;
using DemoApplication.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoApplication.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("DemoApplication.Models.PartyContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PartyIdentityId")
                        .HasColumnType("int");

                    b.Property<int?>("PartyIdentityId1")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_PartyContacts");

                    b.HasIndex("PartyIdentityId");

                    b.HasIndex("PartyIdentityId1");

                    b.ToTable("PartyContacts");
                });

            modelBuilder.Entity("DemoApplication.Models.PartyIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK_PartyIdentities");

                    b.ToTable("PartyIdentities");
                });

            modelBuilder.Entity("DemoApplication.Models.PartyContact", b =>
                {
                    b.HasOne("DemoApplication.Models.PartyIdentity", null)
                        .WithMany()
                        .HasForeignKey("PartyIdentityId")
                        .HasConstraintName("FK_PartyContacts_PartyIdentities")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DemoApplication.Models.PartyIdentity", "PartyIdentity")
                        .WithMany()
                        .HasForeignKey("PartyIdentityId1");

                    b.Navigation("PartyIdentity");
                });
#pragma warning restore 612, 618
        }
    }
}
