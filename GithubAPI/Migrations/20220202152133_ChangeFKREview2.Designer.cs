﻿// <auto-generated />
using System;
using GithubAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GithubAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220202152133_ChangeFKREview2")]
    partial class ChangeFKREview2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GithubAPI.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("GithubAPI.Entities.Pull", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Closed_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPull")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Merged_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("RepoFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pull");
                });

            modelBuilder.Entity("GithubAPI.Entities.Repository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Repository");
                });

            modelBuilder.Entity("GithubAPI.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Author_association")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Html_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PullId")
                        .HasColumnType("int");

                    b.Property<int>("PullNumber")
                        .HasColumnType("int");

                    b.Property<string>("Pull_request_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Submitted_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PullId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("GithubAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Avatar_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gravatar_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Html_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Node_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GithubAPI.Entities.Pull", b =>
                {
                    b.HasOne("GithubAPI.Entities.User", "User")
                        .WithMany("Pulls")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GithubAPI.Entities.Repository", b =>
                {
                    b.HasOne("GithubAPI.Entities.Group", "Group")
                        .WithMany("Repository")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("GithubAPI.Entities.Review", b =>
                {
                    b.HasOne("GithubAPI.Entities.Pull", "Pull")
                        .WithMany("Reviews")
                        .HasForeignKey("PullId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("GithubAPI.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pull");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GithubAPI.Entities.Group", b =>
                {
                    b.Navigation("Repository");
                });

            modelBuilder.Entity("GithubAPI.Entities.Pull", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GithubAPI.Entities.User", b =>
                {
                    b.Navigation("Pulls");
                });
#pragma warning restore 612, 618
        }
    }
}
