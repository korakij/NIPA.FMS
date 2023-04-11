using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{ 
    public class ChemicalCompositionInLadle
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        public string Description { get; set; }
        public Single? CCEMax { get; set; }
        public Single? CCEMin { get; set; }
        public Single? CMax { get; set; }
        public Single? CMin { get; set; }
        public Single? SiMax { get; set; }
        public Single? SiMin { get; set; }
        public Single? MnMax { get; set; }
        public Single? MnMin { get; set; }
        public Single? MgMax { get; set; }
        public Single? MgMin { get; set; }
        public Single? SMax { get; set; }
        public Single? SMin { get; set; }
        public Single? AlMax { get; set; }
        public Single? AlMin { get; set; }
        public Single? CuMax { get; set; }
        public Single? CuMin { get; set; }
        public Single? SnMax { get; set; }
        public Single? SnMin { get; set; }
        public Single? CrMax { get; set; }
        public Single? CrMin { get; set; }
        public Single? PMax { get; set; }
        public Single? PMin { get; set; }
        public Single? MoMax { get; set; }
        public Single? MoMin { get; set; }
        public Single? NiMax { get; set; }
        public Single? NiMin { get; set; }
        public Single? VMax { get; set; }
        public Single? VMin { get; set; }
        public Single? TiMax { get; set; }
        public Single? TiMin { get; set; }
        public Single? TeMax { get; set; }
        public Single? TeMin { get; set; }

        public virtual ICollection<ControlPlan> ControlPlans { get; set; }
            = new HashSet<ControlPlan>();
    }
}
