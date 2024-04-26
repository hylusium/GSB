using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Inviter
    {
        public int AcNum { get; set; }
        public short PraNum { get; set; }
        public bool? Specialisteon { get; set; }
        public byte[] SsmaTimeStamp { get; set; } = null!;

        public virtual ActiviteCompl AcNumNavigation { get; set; } = null!;
        public virtual Praticien PraNumNavigation { get; set; } = null!;
    }
}
