using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MNG.Models.Productions
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string Source { get; set; }
        public string Application { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public DateTime Time { get; set; }
    }
}
