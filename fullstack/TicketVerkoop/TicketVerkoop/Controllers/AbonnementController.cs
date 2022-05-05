using Microsoft.AspNetCore.Mvc;

namespace TicketVerkoop.Controllers
{
    public class AbonnementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
