using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class SwitchboardItem
    {
        public int SwitchboardId { get; set; }
        public short ItemNumber { get; set; }
        public string? ItemText { get; set; }
        public short? Command { get; set; }
        public string? Argument { get; set; }
    }
}
