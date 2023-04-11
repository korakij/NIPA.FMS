using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class Furnace
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Capacity { get; set; }
        public int Power { get; set; }

        public virtual ICollection<LotNo> LotNos { get; set; }
            = new HashSet<LotNo>();

    }
}
