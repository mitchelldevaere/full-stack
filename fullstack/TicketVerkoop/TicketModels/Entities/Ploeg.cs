using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Ploeg
    {
        public Ploeg()
        {
            Abbonements = new HashSet<Abbonement>();
            MatchThuisploegs = new HashSet<Match>();
            MatchUitploegs = new HashSet<Match>();
        }

        public int PloegId { get; set; }
        public string PloegNaam { get; set; } = null!;
        public int StadionId { get; set; }

        public virtual Stadion Stadion { get; set; } = null!;
        public virtual ICollection<Abbonement> Abbonements { get; set; }
        public virtual ICollection<Match> MatchThuisploegs { get; set; }
        public virtual ICollection<Match> MatchUitploegs { get; set; }
    }
}
