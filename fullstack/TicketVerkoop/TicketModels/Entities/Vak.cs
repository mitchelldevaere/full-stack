using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Vak
    {
        public Vak()
        {
            Plaats = new HashSet<Plaat>();
        }

        public int VakId { get; set; }
        public float? Prijs { get; set; }
        public int? StadionId { get; set; }
        public string? VakNaam { get; set; }
        public int? MaxPlaatsen { get; set; }

        public virtual Stadion? Stadion { get; set; }
        public virtual ICollection<Plaat> Plaats { get; set; }
    }
}
