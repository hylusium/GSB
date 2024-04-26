using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Offrir
    {
        public string VisMatricule { get; set; } = null!;
        public int RapNum { get; set; }
        public string MedDepotlegal { get; set; } = null!;
        public short? OffQte { get; set; }

        public virtual Medicament MedDepotlegalNavigation { get; set; } = null!;
        public virtual RapportVisite RapportVisite { get; set; } = null!;
    }
}
