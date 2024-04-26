using System;
using System.Collections.Generic;

namespace GSB_GCR.Models
{
    public partial class Praticien
    {
        public Praticien()
        {
            Inviters = new HashSet<Inviter>();
            Posseders = new HashSet<Posseder>();
            RapportVisites = new HashSet<RapportVisite>();
        }

        public short PraNum { get; set; }
        public string? PraNom { get; set; }
        public string? PraPrenom { get; set; }
        public string? PraAdresse { get; set; }
        public string? PraCp { get; set; }
        public string? PraVille { get; set; }
        public float? PraCoefnotoriete { get; set; }
        public string TypCode { get; set; } = null!;
        public byte[] SsmaTimeStamp { get; set; } = null!;

        public virtual TypePraticien TypCodeNavigation { get; set; } = null!;
        public virtual ICollection<Inviter> Inviters { get; set; }
        public virtual ICollection<Posseder> Posseders { get; set; }
        public virtual ICollection<RapportVisite> RapportVisites { get; set; }
    }
}
