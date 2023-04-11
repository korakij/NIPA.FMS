using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(100)]
        public string CustomerPartNo { get; set; }

        public float Weight { get; set; }
        public byte[] Image { get; set; }
        public string Drawing { get; set; }

        // Navigation property
        public Material Material { get; set; }
        [Required]
        public string MaterialCode { get; set; }

        public Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }

        public DimensionSpeicification Dimension { get; set; }
        public string DimensionCode { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<ControlPlan> ControlPlans { get; set; }
            = new HashSet<ControlPlan>();

        public virtual ControlPlan ActiveControlPlan { get; set; }
        public int? ActiveControlPlanId { get; set; }
    }
}
