﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoVagas.Data;

#nullable disable

namespace ProjetoVagas.Migrations
{
    [DbContext(typeof(VagaDbContext))]
    [Migration("20241112152903_primeirapserver")]
    partial class primeirapserver
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoVagas.Models.Vaga", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Redirect_url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("ProjetoVagas.Models.Vaga", b =>
                {
                    b.OwnsOne("Company", "Company", b1 =>
                        {
                            b1.Property<string>("VagaId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Display_name")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)")
                                .HasColumnName("Company_Display_name");

                            b1.HasKey("VagaId");

                            b1.ToTable("Vagas");

                            b1.WithOwner()
                                .HasForeignKey("VagaId");
                        });

                    b.OwnsOne("Location", "Location", b1 =>
                        {
                            b1.Property<string>("VagaId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Display_name")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)")
                                .HasColumnName("Location_Display_name");

                            b1.HasKey("VagaId");

                            b1.ToTable("Vagas");

                            b1.WithOwner()
                                .HasForeignKey("VagaId");
                        });

                    b.Navigation("Company");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
