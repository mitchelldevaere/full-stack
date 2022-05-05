using Microsoft.AspNetCore.Mvc;

namespace TicketVerkoop.Controllers
{
    public class KalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
