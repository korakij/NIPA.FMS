using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MNG.Models.Productions
{
    public class TestLog
    {
        [Key]
        public int Id { get; set; }

        public string TestCode { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
    }
}
