using Microsoft.EntityFrameworkCore;
using MNG.Models;
using MNG.Models.Productions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Services.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            //
        }

        public virtual DbSet<ChemicalCompositionInFurnace> ChemicalCompositionsInFurnaces { get; set; }
        public virtual DbSet<ChemicalCompositionInLadle> ChemicalCompositionsInLadles { get; set; }
        public virtual DbSet<ControlPlan> ControlPlans { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DimensionSpeicification> DimensionSpecifications { get; set; }
        public virtual DbSet<Furnace> Furnaces { get; set; }
        public virtual DbSet<Kanban> Kanbans { get; set; }
        public virtual DbSet<LotNo> LotNos { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialSpecification> MaterialSpecifications { get; set; }
        public virtual DbSet<MeltStandard> MeltStandards { get; set; }
        public virtual DbSet<MoldStandard> MoldStandards { get; set; }
        public virtual DbSet<PourStandard> PourStandards { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShotBlastStandard> ShotBlastStandards { get; set; }
        public virtual DbSet<TestChemicalComposition> TestChemicalCompositions { get; set; }
        public virtual DbSet<Tooling> Toolings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Charging> Chargings { get; set; }
        public virtual DbSet<TestLog> TestLogs { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbQuery<TestNoByLotNo> TestNoByLotNo { get; set; }
        public virtual DbSet<Pouring> Pourings { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<RawMaterial> RawMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestChemicalComposition>().OwnsOne(x => x.Result);
            modelBuilder.Entity<TestChemicalComposition>().OwnsOne(x => x.Validation);
            modelBuilder.Entity<Kanban>().OwnsOne(x => x.Result);
            modelBuilder.Entity<Kanban>().OwnsOne(x => x.Validation);
            modelBuilder.Entity<Kanban>().OwnsOne(x => x.MatValidation);
            modelBuilder.Entity<Pouring>().OwnsOne(x => x.Defect).OwnsOne(x => x.MeltDefect);
            modelBuilder.Entity<Pouring>().OwnsOne(x => x.Defect).OwnsOne(x => x.MoldDefect);
            modelBuilder.Entity<Pouring>().OwnsOne(x => x.Defect).OwnsOne(x => x.PourDefect);
            modelBuilder.Entity<Pouring>().OwnsOne(x => x.Defect).OwnsOne(x => x.FinDefect);
            modelBuilder.Entity<Pouring>().OwnsOne(x => x.Defect).OwnsOne(x => x.EngDefect);
            modelBuilder.Entity<Pouring>().OwnsOne(x => x.Defect).OwnsOne(x => x.CoreDefect);
            modelBuilder.Entity<Pouring>().OwnsOne(x => x.Defect);
        }
    }
}
