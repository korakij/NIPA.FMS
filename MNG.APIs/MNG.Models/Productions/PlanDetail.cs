using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class PlanDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int NoOfLadle { get; set; }

        // Foreign key relationship to Plan
        [Required]
        public int PlanId { get; set; }
        public Plan Plan { get; set; }

        public string Status { get; set; }
    }
}
