using System.ComponentModel.DataAnnotations;

namespace TicketVerkoop.ViewModels
{
    public class ContactVM
    {
        [Required, Display(Name = "jouw naam")]
        public string subject { get; set; }
        [Required, Display(Name = "jouw email"), EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string message { get; set; }
    }
}
