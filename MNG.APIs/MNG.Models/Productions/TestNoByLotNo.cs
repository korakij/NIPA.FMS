using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MNG.Models.Productions
{
    [Table("ViewTestByLotNo")]
    public class TestNoByLotNo
    {
        public string LotCode { get; set; }
        public string TestCode { get; set; }
    }
}
