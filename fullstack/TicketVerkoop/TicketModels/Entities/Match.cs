using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Match
    {
        public Match()
        {
            Reserverings = new HashSet<Reservering>();
        }

        public int MatchId { get; set; }
        public int ThuisploegId { get; set; }
        public int UitploegId { get; set; }
        public DateTime Datum { get; set; }
        public int StadionId { get; set; }

        public virtual Stadion Stadion { get; set; } = null!;
        public virtual Ploeg Thuisploeg { get; set; } = null!;
        public virtual Ploeg Uitploeg { get; set; } = null!;
        public virtual ICollection<Reservering> Reserverings { get; set; }
    }
}
