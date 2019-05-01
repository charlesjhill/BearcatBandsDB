﻿// <auto-generated />
using System;
using BearcatBands.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BearcatBands.Migrations
{
    [DbContext(typeof(BearcatBandsContext))]
    partial class BearcatBandsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BearcatBands.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnsembleID");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("EnsembleID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("BearcatBands.Models.Ensemble", b =>
                {
                    b.Property<int>("EnsembleID");

                    b.Property<int>("Credits");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("EnsembleID");

                    b.ToTable("Ensembles");
                });

            modelBuilder.Entity("BearcatBands.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName")
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BearcatBands.Models.Enrollment", b =>
                {
                    b.HasOne("BearcatBands.Models.Ensemble", "Ensemble")
                        .WithMany("Enrollments")
                        .HasForeignKey("EnsembleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BearcatBands.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
