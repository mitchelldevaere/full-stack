using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Abbonement
    {
        public Abbonement()
        {
            Reserverings = new HashSet<Reservering>();
        }

        public int AbbonementId { get; set; }
        public int? PloegId { get; set; }
        public int? SeizoenId { get; set; }

        public virtual Ploeg? Ploeg { get; set; }
        public virtual Seizoen? Seizoen { get; set; }
        public virtual ICollection<Reservering> Reserverings { get; set; }
    }
}
