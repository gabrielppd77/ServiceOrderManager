// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceOrderManager.Data;

namespace ServiceOrderManager.Migrations
{
    [DbContext(typeof(ServiceOrderManagerContext))]
    partial class ServiceOrderManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ServiceOrderManager.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Details");

                    b.Property<int>("InternalControl");

                    b.HasKey("Id");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("ServiceOrderManager.Models.OrderService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("EquipmentId");

                    b.Property<DateTime>("Finish");

                    b.Property<DateTime>("Initial");

                    b.Property<int>("InternalControlOS");

                    b.Property<DateTime>("Prevision");

                    b.Property<int>("Priority");

                    b.Property<int>("Status");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.ToTable("OrderService");
                });

            modelBuilder.Entity("ServiceOrderManager.Models.OrderService", b =>
                {
                    b.HasOne("ServiceOrderManager.Models.Equipment", "Equipment")
                        .WithMany("ServiceOrders")
                        .HasForeignKey("EquipmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
