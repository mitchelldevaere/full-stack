namespace TicketVerkoop.ViewModels
{
    public class CartVM
    {
        public int ReserveringId { get; set; }
        public string Thuisploeg { get; set; }
        public string Uitploeg { get; set; }
        public string Stadion { get; set; }
        public string Vaknaam { get; set; }
        public int? Aantal { get; set; }
        public float? Prijs { get; set; }
        public DateTime? Datum { get; set; }
        public System.DateTime DateCreated { get; set; }
    }

    public class ShoppingCartVM
    {
        public List<CartVM>? Cart { get; set; }
    }
}
