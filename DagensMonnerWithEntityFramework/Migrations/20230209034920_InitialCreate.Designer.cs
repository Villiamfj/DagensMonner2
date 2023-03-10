// <auto-generated />
using System;
using DagensMonnerWithEntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DagensMonnerWithEntityFramework.Migrations
{
    [DbContext(typeof(MonnerContext))]
    [Migration("20230209034920_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DagensMonnerWithEntityFramework.Models.LogState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MonnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MonnerId");

                    b.ToTable("LogStates");
                });

            modelBuilder.Entity("DagensMonnerWithEntityFramework.Models.Monner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TimesTaken")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Monners");
                });

            modelBuilder.Entity("DagensMonnerWithEntityFramework.Models.LogState", b =>
                {
                    b.HasOne("DagensMonnerWithEntityFramework.Models.Monner", "Monner")
                        .WithMany()
                        .HasForeignKey("MonnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monner");
                });
#pragma warning restore 612, 618
        }
    }
}
