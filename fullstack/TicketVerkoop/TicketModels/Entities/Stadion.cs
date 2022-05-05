using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Stadion
    {
        public Stadion()
        {
            Matches = new HashSet<Match>();
            Plaats = new HashSet<Plaat>();
            Ploegs = new HashSet<Ploeg>();
            Vaks = new HashSet<Vak>();
        }

        public int StadionId { get; set; }
        public string StadionNaam { get; set; } = null!;
        public int PloegId { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Plaat> Plaats { get; set; }
        public virtual ICollection<Ploeg> Ploegs { get; set; }
        public virtual ICollection<Vak> Vaks { get; set; }
    }
}
