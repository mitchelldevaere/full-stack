using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Plaat
    {
        public Plaat()
        {
            Reserverings = new HashSet<Reservering>();
        }

        public float PlaatsId { get; set; }
        public int? VakId { get; set; }
        public int? StadionId { get; set; }
        public bool? Isbezet { get; set; }

        public virtual Stadion? Stadion { get; set; }
        public virtual Vak? Vak { get; set; }
        public virtual ICollection<Reservering> Reserverings { get; set; }
    }
}
