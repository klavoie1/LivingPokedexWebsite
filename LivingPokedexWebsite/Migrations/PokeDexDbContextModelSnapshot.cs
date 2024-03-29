﻿// <auto-generated />
using System;
using LivingPokedexWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LivingPokedexWebsite.Migrations
{
    [DbContext(typeof(PokeDexDbContext))]
    partial class PokeDexDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LivingPokedexWebsite.Models.Domain.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FormName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokeDexNum")
                        .HasColumnType("int");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
