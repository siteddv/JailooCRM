﻿// <auto-generated />
using System;
using JailooCRM.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JailooCRM.DAL.Migrations
{
    [DbContext(typeof(PgContext))]
    [Migration("20230424142448_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JailooCRM.DAL.BankAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("JailooCRM.DAL.ClientPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClientPlaces");
                });

            modelBuilder.Entity("JailooCRM.DAL.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("JailooCRM.DAL.LoyalityItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("SpentMoneyAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("LoyalityItems");
                });

            modelBuilder.Entity("JailooCRM.DAL.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int?>("ClientPlaceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateClosed")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("WaiterId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClientPlaceId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("JailooCRM.DAL.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("JailooCRM.DAL.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("JailooCRM.DAL.PersonBankAccount", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.Property<string>("BankAccountId")
                        .HasColumnType("text");

                    b.HasKey("PersonId", "BankAccountId");

                    b.HasIndex("BankAccountId");

                    b.ToTable("PersonBankAccounts");
                });

            modelBuilder.Entity("JailooCRM.DAL.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Portion")
                        .HasColumnType("double precision");

                    b.Property<decimal>("PricePerPortion")
                        .HasColumnType("numeric");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeOfPortion")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("JailooCRM.DAL.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTimeUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Specialization")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("JailooCRM.DAL.Chief", b =>
                {
                    b.HasBaseType("JailooCRM.DAL.Person");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("DeprtmentId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsHead")
                        .HasColumnType("boolean");

                    b.Property<int>("Specialization")
                        .HasColumnType("integer");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("Chief");
                });

            modelBuilder.Entity("JailooCRM.DAL.Client", b =>
                {
                    b.HasBaseType("JailooCRM.DAL.Person");

                    b.Property<string>("LoyalityItemId")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("JailooCRM.DAL.Waiter", b =>
                {
                    b.HasBaseType("JailooCRM.DAL.Person");

                    b.Property<decimal>("ServicePercent")
                        .HasColumnType("numeric");

                    b.HasDiscriminator().HasValue("Waiter");
                });

            modelBuilder.Entity("JailooCRM.DAL.LoyalityItem", b =>
                {
                    b.HasOne("JailooCRM.DAL.Client", "Client")
                        .WithOne("LoyalityItem")
                        .HasForeignKey("JailooCRM.DAL.LoyalityItem", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("JailooCRM.DAL.Order", b =>
                {
                    b.HasOne("JailooCRM.DAL.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId");

                    b.HasOne("JailooCRM.DAL.ClientPlace", "ClientPlace")
                        .WithMany("Orders")
                        .HasForeignKey("ClientPlaceId");

                    b.HasOne("JailooCRM.DAL.Waiter", "Waiter")
                        .WithMany("Orders")
                        .HasForeignKey("WaiterId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ClientPlace");

                    b.Navigation("Waiter");
                });

            modelBuilder.Entity("JailooCRM.DAL.OrderItem", b =>
                {
                    b.HasOne("JailooCRM.DAL.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JailooCRM.DAL.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("JailooCRM.DAL.PersonBankAccount", b =>
                {
                    b.HasOne("JailooCRM.DAL.BankAccount", "BankAccount")
                        .WithMany("PersonBankAccounts")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JailooCRM.DAL.Person", "Person")
                        .WithMany("PersonBankAccounts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BankAccount");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("JailooCRM.DAL.Product", b =>
                {
                    b.HasOne("JailooCRM.DAL.Department", "Department")
                        .WithMany("Products")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JailooCRM.DAL.Subcategory", "Subcategory")
                        .WithMany("Products")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("JailooCRM.DAL.Subcategory", b =>
                {
                    b.HasOne("JailooCRM.DAL.Department", "Department")
                        .WithMany("Subcategories")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("JailooCRM.DAL.Chief", b =>
                {
                    b.HasOne("JailooCRM.DAL.Department", "Department")
                        .WithMany("Chief")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("JailooCRM.DAL.BankAccount", b =>
                {
                    b.Navigation("PersonBankAccounts");
                });

            modelBuilder.Entity("JailooCRM.DAL.ClientPlace", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JailooCRM.DAL.Department", b =>
                {
                    b.Navigation("Chief");

                    b.Navigation("Products");

                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("JailooCRM.DAL.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("JailooCRM.DAL.Person", b =>
                {
                    b.Navigation("PersonBankAccounts");
                });

            modelBuilder.Entity("JailooCRM.DAL.Subcategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("JailooCRM.DAL.Client", b =>
                {
                    b.Navigation("LoyalityItem")
                        .IsRequired();

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JailooCRM.DAL.Waiter", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
