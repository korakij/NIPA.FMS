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
    [Migration("20190219043240_Update19.1")]
    partial class Update191
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MNG.Models.ChemCompSpecification", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(1024);

                    b.HasKey("Code");

                    b.ToTable("Specifications");
                });

            modelBuilder.Entity("MNG.Models.ControlPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("SpecificationCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ToolingCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("MaterialSpecificationCode");

                    b.HasIndex("MeltingCode");

                    b.HasIndex("MoldingCode");

                    b.HasIndex("PouringCode");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShotBlastingCode");

                    b.HasIndex("SpecificationCode");

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

                    b.Property<string>("DimensionCose");

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

                    b.Property<float?>("Fe_Mn");

                    b.Property<float?>("Fe_Mo");

                    b.Property<float?>("Fe_Ni");

                    b.Property<float?>("Fe_Si");

                    b.Property<float?>("HC_Cr");

                    b.Property<float?>("KwHr");

                    b.Property<float?>("PigFC");

                    b.Property<float?>("PigFCD");

                    b.Property<int?>("ProductId")
                        .IsRequired();

                    b.Property<float?>("RS");

                    b.Property<float?>("SS");

                    b.Property<DateTime?>("StartTime");

                    b.Property<DateTime?>("StopTime");

                    b.HasKey("ChargeNo");

                    b.HasIndex("ProductId");

                    b.ToTable("Chargings");
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

            modelBuilder.Entity("MNG.Models.ChemCompSpecification", b =>
                {
                    b.OwnsOne("MNG.Models.ChemicalCompositionSpec", "Furnace", b1 =>
                        {
                            b1.Property<string>("ChemCompSpecificationCode");

                            b1.Property<float?>("AlMax");

                            b1.Property<float?>("AlMin");

                            b1.Property<float?>("CCEMax");

                            b1.Property<float?>("CCEMin");

                            b1.Property<float?>("CMax");

                            b1.Property<float?>("CMin");

                            b1.Property<float?>("CrMax");

                            b1.Property<float?>("CrMin");

                            b1.Property<float?>("CuMax");

                            b1.Property<float?>("CuMin");

                            b1.Property<float?>("MgMax");

                            b1.Property<float?>("MgMin");

                            b1.Property<float?>("MnMax");

                            b1.Property<float?>("MnMin");

                            b1.Property<float?>("MoMax");

                            b1.Property<float?>("MoMin");

                            b1.Property<float?>("NiMax");

                            b1.Property<float?>("NiMin");

                            b1.Property<float?>("PMax");

                            b1.Property<float?>("PMin");

                            b1.Property<float?>("SMax");

                            b1.Property<float?>("SMin");

                            b1.Property<float?>("SiMax");

                            b1.Property<float?>("SiMin");

                            b1.Property<float?>("SnMax");

                            b1.Property<float?>("SnMin");

                            b1.Property<float?>("TeMax");

                            b1.Property<float?>("TeMin");

                            b1.Property<float?>("TiMax");

                            b1.Property<float?>("TiMin");

                            b1.Property<float?>("VMax");

                            b1.Property<float?>("VMin");

                            b1.ToTable("Specifications");

                            b1.HasOne("MNG.Models.ChemCompSpecification")
                                .WithOne("Furnace")
                                .HasForeignKey("MNG.Models.ChemicalCompositionSpec", "ChemCompSpecificationCode")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MNG.Models.ChemicalCompositionSpec", "Ladle", b1 =>
                        {
                            b1.Property<string>("ChemCompSpecificationCode");

                            b1.Property<float?>("AlMax");

                            b1.Property<float?>("AlMin");

                            b1.Property<float?>("CCEMax");

                            b1.Property<float?>("CCEMin");

                            b1.Property<float?>("CMax");

                            b1.Property<float?>("CMin");

                            b1.Property<float?>("CrMax");

                            b1.Property<float?>("CrMin");

                            b1.Property<float?>("CuMax");

                            b1.Property<float?>("CuMin");

                            b1.Property<float?>("MgMax");

                            b1.Property<float?>("MgMin");

                            b1.Property<float?>("MnMax");

                            b1.Property<float?>("MnMin");

                            b1.Property<float?>("MoMax");

                            b1.Property<float?>("MoMin");

                            b1.Property<float?>("NiMax");

                            b1.Property<float?>("NiMin");

                            b1.Property<float?>("PMax");

                            b1.Property<float?>("PMin");

                            b1.Property<float?>("SMax");

                            b1.Property<float?>("SMin");

                            b1.Property<float?>("SiMax");

                            b1.Property<float?>("SiMin");

                            b1.Property<float?>("SnMax");

                            b1.Property<float?>("SnMin");

                            b1.Property<float?>("TeMax");

                            b1.Property<float?>("TeMin");

                            b1.Property<float?>("TiMax");

                            b1.Property<float?>("TiMin");

                            b1.Property<float?>("VMax");

                            b1.Property<float?>("VMin");

                            b1.ToTable("Specifications");

                            b1.HasOne("MNG.Models.ChemCompSpecification")
                                .WithOne("Ladle")
                                .HasForeignKey("MNG.Models.ChemicalCompositionSpec", "ChemCompSpecificationCode")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MNG.Models.ControlPlan", b =>
                {
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

                    b.HasOne("MNG.Models.ChemCompSpecification", "Specification")
                        .WithMany("ControlPlans")
                        .HasForeignKey("SpecificationCode")
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
                    b.HasOne("MNG.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("MNG.Models.Productions.ChemicalComposition", "ChemicalActual", b1 =>
                        {
                            b1.Property<string>("ChargingChargeNo");

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

                            b1.Property<DateTime>("TestDate");

                            b1.Property<float?>("Ti");

                            b1.Property<float?>("V");

                            b1.ToTable("Chargings");

                            b1.HasOne("MNG.Models.Productions.Charging")
                                .WithOne("ChemicalActual")
                                .HasForeignKey("MNG.Models.Productions.ChemicalComposition", "ChargingChargeNo")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
