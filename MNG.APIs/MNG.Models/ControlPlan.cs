using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models
{
    public class ControlPlan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        public string Type { get; set; }

        [InverseProperty("ControlPlans")]
        public virtual Product Product { get; set; }
        [Required]
        public int ProductId { get; set; }

        public virtual ChemicalCompositionInFurnace ChemicalCompositionInFurnace { get; set; }
        [StringLength(20)]
        public string ChemicalCompositionInFurnaceCode { get; set; }

        public virtual ChemicalCompositionInLadle ChemicalCompositionInLadle { get; set; }
        [StringLength(20)]
        public string ChemicalCompositionInLadleCode { get; set; }

        public virtual MeltStandard Melting { get; set; }
        [StringLength(20)]
        public string MeltingCode { get; set; }

        public virtual PourStandard Pouring { get; set; }
        [StringLength(20)]
        public string PouringCode { get; set; }

        public virtual MoldStandard Molding { get; set; }
        [StringLength(20)]
        public string MoldingCode { get; set; }

        public virtual ShotBlastStandard ShotBlasting { get; set; }
        [StringLength(20)]
        public string ShotBlastingCode { get; set; }

        public virtual Tooling Tooling { get; set; }
        [StringLength(20)]
        public string ToolingCode { get; set; }

        public virtual MaterialSpecification MaterialSpecification { get; set; }
        [StringLength(20)]
        public string MaterialSpecificationCode { get; set; }

        [StringLength(50)]
        public string Revision { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
