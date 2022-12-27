﻿// <auto-generated />
using System;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mc2.CrudTest.Infrastructure.Migrations
{
    [DbContext(typeof(CrudTestsContext))]
    partial class CrudTestsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mc2.CrudTest.Domain.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BankAccountNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("Firstname", "Lastname", "DateOfBirth")
                        .IsUnique()
                        .HasFilter("[Firstname] IS NOT NULL AND [Lastname] IS NOT NULL");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Mc2.CrudTest.Domain.CustomerAggregate.Customer", b =>
                {
                    b.OwnsOne("Mc2.CrudTest.Domain.CustomerAggregate.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.HasKey("CustomerID");

                            b1.HasIndex("Address")
                                .IsUnique()
                                .HasFilter("[Email_Address] IS NOT NULL");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerID");
                        });

                    b.OwnsOne("Mc2.CrudTest.Domain.CustomerAggregate.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("CustomerID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Number")
                                .HasColumnType("decimal(20,0)");

                            b1.HasKey("CustomerID");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerID");
                        });

                    b.Navigation("Email");

                    b.Navigation("PhoneNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
