﻿// <auto-generated />
using System;
using AwesomeRequestTracker.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AwesomeRequestTracker.Migrations
{
    [DbContext(typeof(AwesomeRequestTrackerContext))]
    partial class AwesomeRequestTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AwesomeRequestTracker.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Person", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Registry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("HashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Registry", (string)null);
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RequestClosedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestRaisedById")
                        .HasColumnType("int");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequestClosedBy");

                    b.HasIndex("RequestRaisedById");

                    b.ToTable("Requests", (string)null);
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.RequestSolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSolved")
                        .HasColumnType("bit");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("RequestRaiserComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolvedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("SolvedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("SolvedBy");

                    b.ToTable("RequestSolutions", (string)null);
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.SolutionFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeedbackBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SolutionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeedbackBy");

                    b.HasIndex("SolutionId");

                    b.ToTable("SolutionFeedbacks", (string)null);
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Employee", b =>
                {
                    b.HasBaseType("AwesomeRequestTracker.Models.Person");

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ramu@gmail.com",
                            Name = "ramu",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "somu@gmail.com",
                            Name = "somu",
                            Role = 4
                        },
                        new
                        {
                            Id = 3,
                            Email = "vembu@gmail.com",
                            Name = "vembu",
                            Role = 2
                        });
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.User", b =>
                {
                    b.HasBaseType("AwesomeRequestTracker.Models.Person");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Email = "sugu@gmail.com",
                            Name = "sugu",
                            Role = 1
                        });
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Registry", b =>
                {
                    b.HasOne("AwesomeRequestTracker.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Request", b =>
                {
                    b.HasOne("AwesomeRequestTracker.Models.Employee", "RequestClosedByEmployee")
                        .WithMany("RequestsClosed")
                        .HasForeignKey("RequestClosedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AwesomeRequestTracker.Models.Person", "RaisedBy")
                        .WithMany("RequestsRaised")
                        .HasForeignKey("RequestRaisedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RaisedBy");

                    b.Navigation("RequestClosedByEmployee");
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.RequestSolution", b =>
                {
                    b.HasOne("AwesomeRequestTracker.Models.Request", "RequestRaised")
                        .WithMany("RequestSolutions")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AwesomeRequestTracker.Models.Employee", "SolvedByEmployee")
                        .WithMany("SolutionPrvided")
                        .HasForeignKey("SolvedBy")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RequestRaised");

                    b.Navigation("SolvedByEmployee");
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.SolutionFeedback", b =>
                {
                    b.HasOne("AwesomeRequestTracker.Models.Person", "FeedbackByPerson")
                        .WithMany("FeedbacksGiven")
                        .HasForeignKey("FeedbackBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AwesomeRequestTracker.Models.RequestSolution", "Solution")
                        .WithMany("Feedbacks")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FeedbackByPerson");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Employee", b =>
                {
                    b.HasOne("AwesomeRequestTracker.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("AwesomeRequestTracker.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.User", b =>
                {
                    b.HasOne("AwesomeRequestTracker.Models.Person", null)
                        .WithOne()
                        .HasForeignKey("AwesomeRequestTracker.Models.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Person", b =>
                {
                    b.Navigation("FeedbacksGiven");

                    b.Navigation("RequestsRaised");
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Request", b =>
                {
                    b.Navigation("RequestSolutions");
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.RequestSolution", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("AwesomeRequestTracker.Models.Employee", b =>
                {
                    b.Navigation("RequestsClosed");

                    b.Navigation("SolutionPrvided");
                });
#pragma warning restore 612, 618
        }
    }
}
