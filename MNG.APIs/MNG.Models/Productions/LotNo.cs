using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class LotNo
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public DateTime Date { get; set; }

        [StringLength(1)]
        public string Shift { get; set; }

        public bool IsCompleted { get; set; }

        public virtual Furnace Furnace { get; set; }
        public string FurnaceCode { get; set; }

        public virtual ICollection<Charging> Chargings { get; set; }
            = new HashSet<Charging>();

    }
}
