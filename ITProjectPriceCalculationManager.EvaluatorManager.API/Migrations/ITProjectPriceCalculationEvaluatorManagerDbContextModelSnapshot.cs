﻿// <auto-generated />
using System;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Migrations
{
    [DbContext(typeof(ITProjectPriceCalculationEvaluatorManagerDbContext))]
    partial class ITProjectPriceCalculationEvaluatorManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction.BelongingFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BelongingFunction");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter.EvaluateParameter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BelongingFunctionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParameterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BelongingFunctionId");

                    b.HasIndex("ParameterId")
                        .IsUnique();

                    b.ToTable("EvaluateParameter");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue.ParameterValue", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("A")
                        .HasColumnType("real");

                    b.Property<float>("B")
                        .HasColumnType("real");

                    b.Property<float>("C")
                        .HasColumnType("real");

                    b.Property<float>("D")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("ParameterValue");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters.Parameters", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParameterValueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter.EvaluateParameter", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction.BelongingFunction", "BelongingFunction")
                        .WithMany("EvaluateParameters")
                        .HasForeignKey("BelongingFunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters.Parameters", "Parameter")
                        .WithOne("EvaluateParameter")
                        .HasForeignKey("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter.EvaluateParameter", "ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BelongingFunction");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue.ParameterValue", b =>
                {
                    b.HasOne("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters.Parameters", "Parameter")
                        .WithOne("ParameterValue")
                        .HasForeignKey("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue.ParameterValue", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction.BelongingFunction", b =>
                {
                    b.Navigation("EvaluateParameters");
                });

            modelBuilder.Entity("ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters.Parameters", b =>
                {
                    b.Navigation("EvaluateParameter")
                        .IsRequired();

                    b.Navigation("ParameterValue")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
