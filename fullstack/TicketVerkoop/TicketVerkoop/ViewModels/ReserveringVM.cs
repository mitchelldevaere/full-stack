namespace TicketVerkoop.ViewModels
{
    public class ReserveringVM
    {
        public int ReserveringId { get; set; }
        public string Thuisploeg { get; set; }
        public string Uitploeg { get; set; }
        public DateTime? Datum { get; set; }
        public string Stadion { get; set; }
        public string Vaknaam { get; set; }
        public int? Aantal { get; set; }
        public string? Type { get; set; }
    }
}
