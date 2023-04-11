using System;
using System.Collections.Generic;
using System.Text;

namespace MNG.Models.Productions
{
    public class MaterialQuantityValidation
    {
        public bool? IsOk_Inoculant { get; set; }
        public bool? IsOk_WireInoculant { get; set; }
        public bool? IsOk_Magnesium { get; set; }
        public bool? IsOk_WireMagnesium { get; set; }
        public bool? IsOk_Copper { get; set; }
        public bool? IsOk_Tin { get; set; }
        public bool? IsOk_FeedTemp { get; set; }
        public bool? IsOk_Chill { get; set; }
    }
}
