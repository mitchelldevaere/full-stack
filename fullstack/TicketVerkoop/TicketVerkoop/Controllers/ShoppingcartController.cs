using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketVerkoop.Extensions;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class ShoppingcartController : Controller
    {
        public IActionResult Index()
        {
            ShoppingCartVM? cartlist = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            //call SessionID
            //var SessionID = httpContext.Session.Id

            return View(cartlist);
        }

        public async Task<IActionResult> Delete(int? reserveringID)
        {

            ShoppingCartVM shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            if (reserveringID != null)
            {
                for (int i = 0; i < shopping.Cart.Count; i++)
                {
                    if (shopping.Cart[i].ReserveringId == reserveringID)
                    {
                        shopping.Cart.Remove(shopping.Cart[i]);
                    }
                }
                HttpContext.Session.SetObjects("ShoppingCart", shopping);
            }
            else
            {
                return NotFound();
            }

            if (shopping.Cart.Count == 0)
            {
                return View("Index", null);
            }
            return View("Index", shopping);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Payment(List<CartVM> carts)
        {
            return View();
        }
    }
}
