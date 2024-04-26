using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Posseder
    {
        public short PraNum { get; set; }
        public string SpeCode { get; set; } = null!;
        public string? PosDiplome { get; set; }
        public float? PosCoefprescription { get; set; }
        public byte[] SsmaTimeStamp { get; set; } = null!;

        public virtual Praticien PraNumNavigation { get; set; } = null!;
        public virtual Specialite SpeCodeNavigation { get; set; } = null!;
    }
}
