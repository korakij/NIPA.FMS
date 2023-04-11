﻿// <auto-generated />
using System;
using MNG.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MNG.Services.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("20190313164805_FurnaceNavOnLotNoModel2")]
    partial class FurnaceNavOnLotNoModel2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MNG.Models.ChemicalCompositionInFurnace", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<float?>("AlMax");

                    b.Property<float?>("AlMin");

                    b.Property<float?>("CCEMax");

                    b.Property<float?>("CCEMin");

                    b.Property<float?>("CMax");

                    b.Property<float?>("CMin");

                    b.Property<float?>("CrMax");

                    b.Property<float?>("CrMin");

                    b.Property<float?>("CuMax");

                    b.Property<float?>("CuMin");

                    b.Property<float?>("MgMax");

                    b.Property<float?>("MgMin");

                    b.Property<float?>("MnMax");

                    b.Property<float?>("MnMin");

                    b.Property<float?>("MoMax");

                    b.Property<float?>("MoMin");

                    b.Property<float?>("NiMax");

                    b.Property<float?>("NiMin");

                    b.Property<float?>("PMax");

                    b.Property<float?>("PMin");

                    b.Property<float?>("SMax");

                    b.Property<float?>("SMin");

                    b.Property<float?>("SiMax");

                    b.Property<float?>("SiMin");

                    b.Property<float?>("SnMax");

                    b.Property<float?>("SnMin");

                    b.Property<float?>("TeMax");

                    b.Property<float?>("TeMin");

                    b.Property<float?>("TiMax");

                    b.Property<float?>("TiMin");

                    b.Property<float?>("VMax");

                    b.Property<float?>("VMin");

                    b.HasKey("Code");

                    b.ToTable("ChemicalCompositionsInFurnaces");
                });

            modelBuilder.Entity("MNG.Models.ControlPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChemicalCompositionInFurnaceCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("MaterialSpecificationCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("MeltingCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("MoldingCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("PouringCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("ProductId");

                    b.Property<string>("Revision")
                        .HasMaxLength(50);

                    b.Property<string>("ShotBlastingCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("ToolingCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("ChemicalCompositionInFurnaceCode");

                    b.HasIndex("MaterialSpecificationCode");

                    b.HasIndex("MeltingCode");

                    b.HasIndex("MoldingCode");

                    b.HasIndex("PouringCode");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShotBlastingCode");

                    b.HasIndex("ToolingCode");

                    b.ToTable("ControlPlans");
                });

            modelBuilder.Entity("MNG.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MNG.Models.DimensionSpeicification", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<string>("MeasurementType");

                    b.Property<float>("NegativeTolerance");

                    b.Property<float>("Nominal");

                    b.Property<float>("PositiveTolerance");

                    b.HasKey("Code");

                    b.ToTable("DimensionSpecifications");
                });

            modelBuilder.Entity("MNG.Models.Material", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.HasKey("Code");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("MNG.Models.MaterialSpecification", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<float?>("CementiteMax");

                    b.Property<float?>("CementiteMin");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<float?>("Elongation");

                    b.Property<float?>("FerriteMax");

                    b.Property<float?>("FerriteMin");

                    b.Property<float?>("GraphiteA");

                    b.Property<int?>("HBMax");

                    b.Property<int?>("HBMin");

                    b.Property<float?>("NodularityMin");

                    b.Property<float?>("NoduleCount");

                    b.Property<float?>("PearliteMax");

                    b.Property<float?>("PearliteMin");

                    b.Property<float?>("SizeMax");

                    b.Property<float?>("SizeMin");

                    b.Property<int?>("Tensile");

                    b.Property<float?>("Yield");

                    b.HasKey("Code");

                    b.ToTable("MaterialSpecifications");
                });

            modelBuilder.Entity("MNG.Models.MeltStandard", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<float?>("C_FC");

                    b.Property<float?>("C_FCD");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<float?>("Fe_Mn");

                    b.Property<float?>("Fe_Mo");

                    b.Property<float?>("Fe_Ni");

                    b.Property<float?>("Fe_Si");

                    b.Property<float?>("HC_Cr");

                    b.Property<float?>("PigFC");

                    b.Property<float?>("PigFCD");

                    b.Property<float?>("RS");

                    b.Property<float?>("SS");

                    b.HasKey("Code");

                    b.ToTable("MeltStandards");
                });

            modelBuilder.Entity("MNG.Models.MoldStandard", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<int>("CSE");

                    b.Property<int>("CompressiveMax");

                    b.Property<int>("CompressiveMin");

                    b.Property<float>("CoreSettingTime");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<float>("ExtendedSqueezeTime");

                    b.Property<int>("MoldHBMin");

                    b.Property<float>("MoldPositionCorr");

                    b.Property<int>("MoldSizeMax");

                    b.Property<int>("MoldSizeMin");

                    b.Property<float>("MoldThicknessCorr");

                    b.Property<float>("PPStrippingAcc");

                    b.Property<float>("PPStrippingDist");

                    b.Property<float>("SPStrippingAcc");

                    b.Property<float>("SPStrippingDist");

                    b.Property<float>("ShotPressure");

                    b.Property<float>("ShotTimeCorr");

                    b.Property<float>("SqueezePressure");

                    b.HasKey("Code");

                    b.ToTable("MoldStandards");
                });

            modelBuilder.Entity("MNG.Models.PourStandard", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<float>("Cu");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<float>("FirstTemp");

                    b.Property<float>("Inoculant");

                    b.Property<float>("LastTemp");

                    b.Property<int>("NoOfMoldPerLadle");

                    b.Property<float>("PouringTime");

                    b.Property<float>("Sn");

                    b.Property<float>("WiredInoc");

                    b.Property<float>("WiredMg");

                    b.HasKey("Code");

                    b.ToTable("PourStandards");
                });

            modelBuilder.Entity("MNG.Models.Product", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int?>("ActiveControlPlanId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("CustomerPartNo")
                        .HasMaxLength(100);

                    b.Property<string>("DimensionCode");

                    b.Property<string>("MaterialCode")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PictureFileName");

                    b.Property<float>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("ActiveControlPlanId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DimensionCode");

                    b.HasIndex("MaterialCode");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MNG.Models.Productions.Charging", b =>
                {
                    b.Property<string>("ChargeNo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<float?>("C_FC");

                    b.Property<float?>("C_FCD");

                    b.Property<DateTime?>("ChargeTime");

                    b.Property<float?>("Fe_Mn");

                    b.Property<float?>("Fe_Mo");

                    b.Property<float?>("Fe_Ni");

                    b.Property<float?>("Fe_Si");

                    b.Property<float?>("HC_Cr");

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("LotNoCode")
                        .IsRequired();

                    b.Property<int?>("MaxTemp");

                    b.Property<float?>("MaxTempKwHr");

                    b.Property<DateTime?>("MaxTempTime");

                    b.Property<float?>("PigFC");

                    b.Property<float?>("PigFCD");

                    b.Property<float?>("RS");

                    b.Property<float?>("SS");

                    b.Property<float?>("StartKwHr");

                    b.HasKey("ChargeNo");

                    b.HasIndex("LotNoCode");

                    b.ToTable("Chargings");
                });

            modelBuilder.Entity("MNG.Models.Productions.Furnace", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("Brand");

                    b.Property<int>("Capacity");

                    b.Property<string>("Name");

                    b.Property<int>("Power");

                    b.HasKey("Code");

                    b.ToTable("Furnaces");
                });

            modelBuilder.Entity("MNG.Models.Productions.Kanban", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<float>("KwHr");

                    b.Property<string>("TestChemicalCompositionCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Time");

                    b.Property<float>("Weight");

                    b.HasKey("Code");

                    b.HasIndex("TestChemicalCompositionCode");

                    b.ToTable("Kanbans");
                });

            modelBuilder.Entity("MNG.Models.Productions.LotNo", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsCompleted");

                    b.Property<int>("Shift");

                    b.HasKey("Code");

                    b.ToTable("LotNos");
                });

            modelBuilder.Entity("MNG.Models.Productions.TestChemicalComposition", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("ChargingCode")
                        .IsRequired();

                    b.Property<bool>("IsCompleted");

                    b.Property<int?>("ProductId")
                        .IsRequired();

                    b.Property<DateTime?>("Time");

                    b.HasKey("Code");

                    b.HasIndex("ChargingCode");

                    b.HasIndex("ProductId");

                    b.ToTable("TestChemicalCompositions");
                });

            modelBuilder.Entity("MNG.Models.ShotBlastStandard", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<float>("BallSize");

                    b.Property<int>("Current");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<int>("ShakeOutTemp");

                    b.Property<DateTime>("ShotTime");

                    b.Property<int>("UltraSonic");

                    b.HasKey("Code");

                    b.ToTable("ShotBlastStandards");
                });

            modelBuilder.Entity("MNG.Models.Tooling", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20);

                    b.Property<string>("CBId");

                    b.Property<string>("CSEId");

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.Property<float>("MinDistance");

                    b.Property<float>("PPHeight");

                    b.Property<string>("PPId");

                    b.Property<float>("PPThickness");

                    b.Property<float>("SPHeight");

                    b.Property<string>("SPId");

                    b.Property<float>("SPThickness");

                    b.HasKey("Code");

                    b.ToTable("Toolings");
                });

            modelBuilder.Entity("MNG.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MNG.Models.ControlPlan", b =>
                {
                    b.HasOne("MNG.Models.ChemicalCompositionInFurnace", "ChemicalCompositionInFurnace")
                        .WithMany("ControlPlans")
                        .HasForeignKey("ChemicalCompositionInFurnaceCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.MaterialSpecification", "MaterialSpecification")
                        .WithMany("ControlPlans")
                        .HasForeignKey("MaterialSpecificationCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.MeltStandard", "Melting")
                        .WithMany("ControlPlans")
                        .HasForeignKey("MeltingCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.MoldStandard", "Molding")
                        .WithMany("ControlPlans")
                        .HasForeignKey("MoldingCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.PourStandard", "Pouring")
                        .WithMany("ControlPlans")
                        .HasForeignKey("PouringCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.Product", "Product")
                        .WithMany("ControlPlans")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.ShotBlastStandard", "ShotBlasting")
                        .WithMany("ControlPlans")
                        .HasForeignKey("ShotBlastingCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.Tooling", "Tooling")
                        .WithMany("ControlPlans")
                        .HasForeignKey("ToolingCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MNG.Models.Product", b =>
                {
                    b.HasOne("MNG.Models.ControlPlan", "ActiveControlPlan")
                        .WithMany()
                        .HasForeignKey("ActiveControlPlanId");

                    b.HasOne("MNG.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.DimensionSpeicification", "Dimension")
                        .WithMany()
                        .HasForeignKey("DimensionCode");

                    b.HasOne("MNG.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MNG.Models.Productions.Charging", b =>
                {
                    b.HasOne("MNG.Models.Productions.LotNo", "LotNo")
                        .WithMany("Chargings")
                        .HasForeignKey("LotNoCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MNG.Models.Productions.Kanban", b =>
                {
                    b.HasOne("MNG.Models.Productions.TestChemicalComposition", "TestChemicalComposition")
                        .WithMany("Kanbans")
                        .HasForeignKey("TestChemicalCompositionCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MNG.Models.Productions.TestChemicalComposition", b =>
                {
                    b.HasOne("MNG.Models.Productions.Charging", "Charging")
                        .WithMany("TestChemicalCompositions")
                        .HasForeignKey("ChargingCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MNG.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("MNG.Models.Productions.ChemicalComposition", "Result", b1 =>
                        {
                            b1.Property<string>("TestChemicalCompositionCode");

                            b1.Property<float?>("Al");

                            b1.Property<float?>("C");

                            b1.Property<float?>("CCE");

                            b1.Property<float?>("Cr");

                            b1.Property<float?>("Cu");

                            b1.Property<float?>("Mg");

                            b1.Property<float?>("Mn");

                            b1.Property<float?>("Mo");

                            b1.Property<float?>("Ni");

                            b1.Property<float?>("P");

                            b1.Property<float?>("S");

                            b1.Property<float?>("Si");

                            b1.Property<float?>("Sn");

                            b1.Property<float?>("Te");

                            b1.Property<float?>("Ti");

                            b1.Property<float?>("V");

                            b1.ToTable("TestChemicalCompositions");

                            b1.HasOne("MNG.Models.Productions.TestChemicalComposition")
                                .WithOne("Result")
                                .HasForeignKey("MNG.Models.Productions.ChemicalComposition", "TestChemicalCompositionCode")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
