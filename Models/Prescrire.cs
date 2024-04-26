using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Prescrire
    {
        public string MedDepotlegal { get; set; } = null!;
        public string TinCode { get; set; } = null!;
        public string DosCode { get; set; } = null!;
        public string? PrePosologie { get; set; }

        public virtual Dosage DosCodeNavigation { get; set; } = null!;
        public virtual Medicament MedDepotlegalNavigation { get; set; } = null!;
        public virtual TypeIndividu TinCodeNavigation { get; set; } = null!;
    }
}
