using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    public class Line
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public string Name { get; set; }
        public string Size { get; set; }

        public virtual ICollection<Pouring> Pourings { get; set; }
            = new HashSet<Pouring>();
    }
}
