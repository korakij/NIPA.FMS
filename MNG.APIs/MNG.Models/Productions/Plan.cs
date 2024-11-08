using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models.Productions
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code 
        {
            get
            {
                return $"{DateCreated.Date.ToString("yyyyMMdd")}-{Factory}-{Shift}";
            }
        }

        [Required]
        public DateTime DateCreated { get; set; }
        [StringLength(1)]
        public string Shift { get; set; }
        public int Factory { get; set; }

        public string Creator {  get; set; }

        // Navigation property to represent the relationship with PlanDetails
        public ICollection<PlanDetail> PlanDetails { get; set; }
    }
}
