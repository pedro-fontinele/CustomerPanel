﻿// <auto-generated />
using CustomerPanel.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerPanel.Data.Migrations.MigrationsEF
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.19");

            modelBuilder.Entity("CustomerPanel.Domain.Entity.Model.Client", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("LegalName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("LegalName");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Mail");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("CustomerPanel.Domain.Entity.Model.Telephone", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<uint>("ClientId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ClientId");

                    b.Property<uint>("DDD")
                        .HasColumnType("INTEGER")
                        .HasColumnName("DDD");

                    b.Property<ulong>("Number")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Number");

                    b.Property<string>("TypeNumber")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("TypeNumber");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Telephone", (string)null);
                });

            modelBuilder.Entity("CustomerPanel.Domain.Entity.Model.Telephone", b =>
                {
                    b.HasOne("CustomerPanel.Domain.Entity.Model.Client", null)
                        .WithMany("Telephone")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerPanel.Domain.Entity.Model.Client", b =>
                {
                    b.Navigation("Telephone");
                });
#pragma warning restore 612, 618
        }
    }
}