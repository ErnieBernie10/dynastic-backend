﻿// <auto-generated />
using System;
using Dynastic.Architecture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dynastic.Architecture.Migrations.Dynastic
{
    [DbContext(typeof(DynasticContext))]
    [Migration("20210320162327_AddUserDynastyKey")]
    partial class AddUserDynastyKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Dynastic.Architecture.Models.Dynasty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("HeadId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HeadId");

                    b.ToTable("Dynasties");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DynastyId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("FatherId")
                        .HasColumnType("uuid");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<string>("Middlename")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("MotherId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DynastyId");

                    b.HasIndex("FatherId");

                    b.HasIndex("MotherId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.Relationship", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uuid");

                    b.HasKey("PersonId", "PartnerId");

                    b.HasIndex("PartnerId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.UserDynasties", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<Guid>("DynastyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DynastyId");

                    b.ToTable("UserDynasties");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.Dynasty", b =>
                {
                    b.HasOne("Dynastic.Architecture.Models.Person", "Head")
                        .WithMany()
                        .HasForeignKey("HeadId");

                    b.Navigation("Head");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.Person", b =>
                {
                    b.HasOne("Dynastic.Architecture.Models.Dynasty", null)
                        .WithMany("Members")
                        .HasForeignKey("DynastyId");

                    b.HasOne("Dynastic.Architecture.Models.Person", "Father")
                        .WithMany("FathersChildren")
                        .HasForeignKey("FatherId");

                    b.HasOne("Dynastic.Architecture.Models.Person", "Mother")
                        .WithMany("MothersChildren")
                        .HasForeignKey("MotherId");

                    b.Navigation("Father");

                    b.Navigation("Mother");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.Relationship", b =>
                {
                    b.HasOne("Dynastic.Architecture.Models.Person", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dynastic.Architecture.Models.Person", "Person")
                        .WithMany("Relationships")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.UserDynasties", b =>
                {
                    b.HasOne("Dynastic.Architecture.Models.Dynasty", "Dynasty")
                        .WithMany()
                        .HasForeignKey("DynastyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dynasty");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.Dynasty", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Dynastic.Architecture.Models.Person", b =>
                {
                    b.Navigation("FathersChildren");

                    b.Navigation("MothersChildren");

                    b.Navigation("Relationships");
                });
#pragma warning restore 612, 618
        }
    }
}
