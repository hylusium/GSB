using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Travailler
    {
        public string VisMatricule { get; set; } = null!;
        public DateTime Jjmmaa { get; set; }
        public string RegCode { get; set; } = null!;
        public string? TraRole { get; set; }

        public virtual Region RegCodeNavigation { get; set; } = null!;
        public virtual Visiteur VisMatriculeNavigation { get; set; } = null!;
    }
}
