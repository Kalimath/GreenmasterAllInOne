﻿// <auto-generated />
using System;
using Greenmaster.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Greenmaster.Persistence.Migrations
{
    [DbContext(typeof(BotanicalDbContext))]
    partial class BotanicalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Greenmaster.Domain.Entities.Bloom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("AttractsPollinators")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEdible")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFragrant")
                        .HasColumnType("boolean");

                    b.Property<int[]>("Period")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("integer[]");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Blooms");
                });

            modelBuilder.Entity("Greenmaster.Domain.Entities.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BloomId")
                        .HasColumnType("uuid");

                    b.Property<string>("CommonName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cultivar")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("Greenmaster.Domain.Entities.SymbioticRelation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("SymbiontAId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SymbiontBId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SymbiontAId");

                    b.HasIndex("SymbiontBId");

                    b.ToTable("SymbioticRelations");
                });

            modelBuilder.Entity("Greenmaster.Domain.Entities.SymbioticRelation", b =>
                {
                    b.HasOne("Greenmaster.Domain.Entities.Plant", "SymbiontA")
                        .WithMany()
                        .HasForeignKey("SymbiontAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Greenmaster.Domain.Entities.Plant", "SymbiontB")
                        .WithMany()
                        .HasForeignKey("SymbiontBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SymbiontA");

                    b.Navigation("SymbiontB");
                });
#pragma warning restore 612, 618
        }
    }
}
