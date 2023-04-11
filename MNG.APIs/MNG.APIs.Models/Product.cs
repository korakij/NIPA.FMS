using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.APIs.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string PartNo { get; set; }

        [StringLength(50)]
        public string PartName { get; set; }

        public int MatId { get; set; }
        public double Weight { get; set; }
        public int CustId { get; set; }
        public string FileName { get; set; }
    }
}
