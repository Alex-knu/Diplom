﻿// <auto-generated />
using System;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Migrations
{
    [DbContext(typeof(ITProjectPriceCalculationManagerDbContext))]
    [Migration("20230425185423_AddNewModels")]
    partial class AddNewModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageCostLabor")
                        .HasColumnType("double precision");

                    b.Property<double>("AverageMonthlyRateWorkingHours")
                        .HasColumnType("double precision");

                    b.Property<int>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<double>("Overhead")
                        .HasColumnType("double precision");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("Profit")
                        .HasColumnType("double precision");

                    b.Property<double>("SocialInsurance")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEstimators.ApplicationToEstimators", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<double>("Coeficient")
                        .HasColumnType("double precision");

                    b.Property<int>("EstimatorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("EstimatorId");

                    b.ToTable("ApplicationToEstimators");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator.Estimator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Estimators");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AttributeId")
                        .HasColumnType("integer");

                    b.Property<int>("EstimatorId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("EstimatorId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage.ProgramLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("SLOC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProgramLanguages");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr.ProgramsParametr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<int>("ProgramLanguageId")
                        .HasColumnType("integer");

                    b.Property<int>("SLOC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ProgramLanguageId");

                    b.ToTable("ProgramsParametrs");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProgramsParametrId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectAreaElementId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProgramsParametrId");

                    b.HasIndex("SubjectAreaElementId");

                    b.ToTable("ProgramsParametrToSubjectAreaElements");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.SubjectAreaElement.SubjectAreaElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<int>("DifficultyLevelsType")
                        .HasMaxLength(256)
                        .HasColumnType("integer");

                    b.Property<int>("SubjectAreaType")
                        .HasMaxLength(256)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SubjectAreaElements");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application.Application", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator.Estimator", "Creator")
                        .WithMany("Applications")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEstimators.ApplicationToEstimators", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application.Application", "Application")
                        .WithMany("ApplicationToEstimators")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator.Estimator", "Estimator")
                        .WithMany("ApplicationToEstimators")
                        .HasForeignKey("EstimatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Estimator");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department.Department", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department.Department", "Parent")
                        .WithMany("SubDepartment")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator.Estimator", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department.Department", "Department")
                        .WithMany("Estimators")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Profile.Profile", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute.Attribute", "Attribute")
                        .WithMany("Profiles")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator.Estimator", "Estimator")
                        .WithMany("Profiles")
                        .HasForeignKey("EstimatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("Estimator");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr.ProgramsParametr", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application.Application", "Application")
                        .WithMany("ProgramsParametrs")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage.ProgramLanguage", "ProgramLanguage")
                        .WithMany("ProgramsParametrs")
                        .HasForeignKey("ProgramLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("ProgramLanguage");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr.ProgramsParametr", "ProgramsParametr")
                        .WithMany("ProgramsParametrToSubjectAreaElements")
                        .HasForeignKey("ProgramsParametrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.SubjectAreaElement.SubjectAreaElement", "SubjectAreaElement")
                        .WithMany("ProgramsParametrToSubjectAreaElements")
                        .HasForeignKey("SubjectAreaElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramsParametr");

                    b.Navigation("SubjectAreaElement");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application.Application", b =>
                {
                    b.Navigation("ApplicationToEstimators");

                    b.Navigation("ProgramsParametrs");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Attribute.Attribute", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department.Department", b =>
                {
                    b.Navigation("Estimators");

                    b.Navigation("SubDepartment");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator.Estimator", b =>
                {
                    b.Navigation("ApplicationToEstimators");

                    b.Navigation("Applications");

                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage.ProgramLanguage", b =>
                {
                    b.Navigation("ProgramsParametrs");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr.ProgramsParametr", b =>
                {
                    b.Navigation("ProgramsParametrToSubjectAreaElements");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.SubjectAreaElement.SubjectAreaElement", b =>
                {
                    b.Navigation("ProgramsParametrToSubjectAreaElements");
                });
#pragma warning restore 612, 618
        }
    }
}