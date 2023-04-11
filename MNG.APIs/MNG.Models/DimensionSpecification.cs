using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.Models
{
    public class DimensionSpeicification
    {
        [Key]
        [StringLength(20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public string MeasurementType { get; set; }
        public float Nominal { get; set; }
        public float PositiveTolerance { get; set; }
        public float NegativeTolerance { get; set; }

    }
}
