using MNG.Services.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MNG.Services
{
    public class App
    {

        internal readonly AppDb db;

        public App(AppDb db)
        {
            this.db = db;
            ChemicalCompositionInFurnaces = new ChemicalCompositionInFurnaceService(db);
            ChemicalCompositionInLadles = new ChemicalCompositionInLadleService(db);
            ControlPlans = new ControlPlanService(db);
            Customers = new CustomerService(db);
            Dimensions = new DimensionSpecificationService(db);
            Furnaces = new FurnaceService(db);
            Kanbans = new KanbanService(db);
            LotNos = new LotNoService(db);
            Materials = new MaterialService(db);
            MaterialSpecification = new MaterialSpecificationService(db);
            MeltStandards = new MeltStandardService(db);
            MoldStandards = new MoldStandardService(db);
            PourStandards = new PourStandardService(db);
            Products = new ProductService(db);
            ShotBlastStandards = new ShotBlastStandardService(db);
            TestChemicalCompositions = new TestChemicalCompositionService(db);
            Toolings = new ToolingService(db);
            Users = new UserService(db);
            Pourings = new PouringService(db);
            Chargings = new ChargingService(db);
            TestNoByLotNo = new TestNoByLotNoService(db);
            TestLogs = new TestLogService(db);
            Notifications = new NotificationService(db);
            Settings = new SettingService(db);
        }

        public ChemicalCompositionInFurnaceService ChemicalCompositionInFurnaces { get; set; }
        public ChemicalCompositionInLadleService ChemicalCompositionInLadles { get; set; }
        public ControlPlanService ControlPlans { get; set; }
        public CustomerService Customers { get; set; }
        public DimensionSpecificationService Dimensions { get; set; }
        public FurnaceService Furnaces { get; set; }
        public KanbanService Kanbans { get; set; }
        public LotNoService LotNos { get; set; }
        public MaterialService Materials { get; }
        public MaterialSpecificationService MaterialSpecification { get; set; }
        public MeltStandardService MeltStandards { get; set; }
        public MoldStandardService MoldStandards { get; set; }
        public PourStandardService PourStandards { get; set; }
        public ProductService Products { get; }
        public ShotBlastStandardService ShotBlastStandards { get; set; }
        public TestChemicalCompositionService TestChemicalCompositions { get; set; }
        public ToolingService Toolings { get; set; }
        public UserService Users { get; }
        public PouringService Pourings { get; set; }

        public ChargingService Chargings { get; set; }
        public TestNoByLotNoService TestNoByLotNo { get; set; }
        public TestLogService TestLogs { get; set; }
        public NotificationService Notifications { get; set; }
        public SettingService Settings { get; set; }

        public int SaveChanges() => db.SaveChanges();
        public async Task<int> SaveChangesAsync() => await db.SaveChangesAsync();
    }
}
