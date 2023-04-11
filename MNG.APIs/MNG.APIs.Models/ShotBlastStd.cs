using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNG.APIs.Models
{
    public class ShotBlastStd
    {
        [Key]
        public string Code { get; set; }

        [StringLength(50)]
        public string Desc { get; set; }

        public int ShakeOutTemp { get; set; }
        public float BallSize { get; set; }
        public DateTime ShotTime { get; set; }
        public int Current { get; set; }
        public int UltraSonic { get; set; }
    }
}
