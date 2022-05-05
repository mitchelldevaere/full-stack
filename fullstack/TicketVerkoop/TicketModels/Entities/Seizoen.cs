using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Seizoen
    {
        public Seizoen()
        {
            Abbonements = new HashSet<Abbonement>();
        }

        public int SeizoenId { get; set; }
        public DateTime? BeginDatum { get; set; }
        public DateTime? EindDatum { get; set; }

        public virtual ICollection<Abbonement> Abbonements { get; set; }
    }
}
