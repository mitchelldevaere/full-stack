namespace TicketVerkoop.ViewModels
{
    public class CartVM
    {
        public int ReserveringId { get; set; }
        public string Thuisploeg { get; set; }
        public string Uitploeg { get; set; }
        public string Stadion { get; set; }
        public string Vaknaam { get; set; }
        public int Aantal { get; set; }
        public float? Prijs { get; set; }
        public string? Type { get; set; }
        public bool? Cancelled { get; set; }
        public DateTime? Datum { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? MatchId { get; set; }
        public string? UserId { get; set; }
        public int? VakId { get; set; }
        public int? Abbonnement { get; set; }
    }

    public class ShoppingCartVM
    {
        public List<CartVM>? Cart { get; set; }
    }
}
