using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MNG.Models
{
    public class Setting
    {
        [Key]
        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        public string API_URL { get; set; }
        public string Result_Path { get; set; }
        public string Path { get; set; }
        public string PowerMeterIP { get; set; }
        public int RefreshRate { get; set; }
        public bool IsSelected { get; set; }

    }
}
