using System;
using System.Collections.Generic;

namespace TicketModels.Entities
{
    public partial class Reservering
    {
        public int ReserveringId { get; set; }
        public int? MatchId { get; set; }
        public string? UserId { get; set; }
        public int? VakId { get; set; }
        public int? Abbonnement { get; set; }
        public DateTime? Datum { get; set; }
        public string? Type { get; set; }
        public bool? Cancelled { get; set; }
        public int? Plaatsnummer { get; set; }
        public float? Prijs { get; set; }

        public virtual Abbonement? AbbonnementNavigation { get; set; }
        public virtual Match? Match { get; set; }
        public virtual AspNetUser? User { get; set; }
        public virtual Vak? Vak { get; set; }
    }
}
