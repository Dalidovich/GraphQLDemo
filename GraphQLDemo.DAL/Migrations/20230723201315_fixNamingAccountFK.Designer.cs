﻿// <auto-generated />
using System;
using GraphQLDemo.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GraphQLDemo.DAL.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20230723201315_fixNamingAccountFK")]
    partial class fixNamingAccountFK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GraphQLDemo.Domain.Entities.Account", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_account_id");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("login");

                    b.Property<Guid>("StatisticsId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_statistics_id");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("StatisticsId");

                    b.ToTable("accounts", (string)null);
                });

            modelBuilder.Entity("GraphQLDemo.Domain.Entities.Statistics", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_statistics_id");

                    b.Property<short>("Age")
                        .HasColumnType("smallint")
                        .HasColumnName("age");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_active");

                    b.Property<double>("rating")
                        .HasColumnType("float8")
                        .HasColumnName("rating");

                    b.HasKey("Id");

                    b.ToTable("statistics", (string)null);
                });

            modelBuilder.Entity("GraphQLDemo.Domain.Entities.Account", b =>
                {
                    b.HasOne("GraphQLDemo.Domain.Entities.Statistics", "Statistics")
                        .WithMany()
                        .HasForeignKey("StatisticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}