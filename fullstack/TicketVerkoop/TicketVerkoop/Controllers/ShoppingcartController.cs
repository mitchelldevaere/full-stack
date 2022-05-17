using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketModels.Entities;
using TicketService.interfaces;
using TicketVerkoop.Extensions;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class ShoppingcartController : Controller
    {
        private ReserveringIService<Reservering> _reserveringservice;
        private VakIService<Vak> _Vakservice;
        private UserIService<AspNetUser> _userService;
        private SeizoenIService<Seizoen> _seizoenService;
        private readonly IMapper _mapper;

        private int countPlaatsen = 0;

        public ShoppingcartController(IMapper mapper, ReserveringIService<Reservering> reserveringservice, VakIService<Vak> vakservice, UserIService<AspNetUser> userService, SeizoenIService<Seizoen> seizoenService)
        {
            _mapper = mapper;
            _reserveringservice = reserveringservice;
            _Vakservice = vakservice;
            _userService = userService;
            _seizoenService = seizoenService;
        }

        public IActionResult Index()
        {
            ShoppingCartVM? cartlist = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
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
        public async Task<ActionResult> Payment(int id)
        {
            ShoppingCartVM carts = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
            List<CartVM> cartItems = carts.Cart;

            //controle voor de datum van de aankoop
            foreach (var item in cartItems)
            {
                var vak =  await _Vakservice.FindById(Convert.ToInt32(item.VakId));

                countPlaatsen += item.Aantal;

                //datum controleren
                if (item.Type == "Ticket")
                {
                    DateTime t1 = DateTime.Now.AddMonths(1);
                    DateTime t2 = Convert.ToDateTime(item.Datum);

                    if(t1 > t2) // vergelijken of aankoopdatum al voorbij is
                    {
                        ViewBag.Message = "U kunt geen ticket kopen voor een wedstrijd die al gespeeld is!";
                        return View();
                    }

                    if (t1 > t2) // vergelijken of de aankoopdatum niet meer dan 1maand voor de wedstrijd is
                    {
                        ViewBag.Message = "U kunt maximaal 1 maand voor de wedstrijd tickets kopen!";
                        return View();
                    }

                    if (countPlaatsen >= vak.MaxPlaatsen)// controleren of er nog genoeg plaatsen zijn.
                    {
                        ViewBag.Message = "Alle plaatsen in dit gedeelte van het stadion zijn volzet!";
                        return View();
                    }
                }

                var seizoen = await _seizoenService.FindById(1);


                //controle datum abbonement
                if (item.Type == "Abbo")
                {
                    DateTime t1 = DateTime.Now;
                    DateTime t2 = Convert.ToDateTime(seizoen.BeginDatum);

                    if (t1 > t2) // vergelijken of de aankoopdatum voor de eerste wedstrijd valt
                    {
                        ViewBag.Message = "U moet uw abonnement voor het begin van het seizoen kopen!";
                        return View();
                    }
                }
            }

            //wegschrijven naar databank
            foreach (var item in cartItems)
            {
                for (int i = 0; i < item.Aantal; i++)
                {
                    var list = await _reserveringservice.GetAllTrue(User.Identity.Name, false);

                    var vak = await _Vakservice.FindById(Convert.ToInt32(item.VakId));
                    var plaatsen = vak.MaxPlaatsen;

                    //controle geen plaatsen meer
                    if(plaatsen == 0)
                    {
                        ViewBag.Message = "Het vak dat je hebt gekozen zit vol. Je zult een andere plaats moeten kiezen";
                        return View();
                    }

                    if (list.Count() >= 4)
                    {
                        ViewBag.Message = "Je heb je maximum aantal tickets bereikt. Je mag maar 4 Tickets kopen";
                        return View();
                    }

                    if (item.Type == "Ticket")
                    {
                        Reservering reservering = new Reservering
                        {
                            UserId = User.Identity.Name,
                            MatchId = item.MatchId,
                            VakId = item.VakId,
                            Abbonnement = null,
                            Datum = item.Datum,
                            Type = item.Type,
                            Cancelled = item.Cancelled,
                            Plaatsnummer = plaatsen,
                            Prijs = item.Prijs
                        };
                        plaatsen = plaatsen - 1;

                        await _reserveringservice.Add(reservering);
                    }
                    else if(item.Type == "Abbo")
                    {
                        Reservering reservering = new Reservering
                        {
                            UserId = User.Identity.Name,
                            MatchId = item.MatchId,
                            VakId = item.VakId,
                            Abbonnement = item.Abbonnement,
                            Datum = item.Datum,
                            Type = item.Type,
                            Cancelled = item.Cancelled,
                            Plaatsnummer = plaatsen
                        };
                        plaatsen = plaatsen - 1;

                        await _reserveringservice.Add(reservering);
                    } else
                    {
                        ViewBag.Message = "Er is een fout gebeurd in de regeistratie van je aankopen!";
                        return View();
                    }
                    vak.MaxPlaatsen = plaatsen;
                    await _Vakservice.Update(vak);
                }
            }

            //leegmaken winkelmandje
            HttpContext.Session.SetObjects("ShoppingCart", null);

            ViewBag.Message = "Bedankt voor uw aankopen! Uw aankopen zullen spoedig in uw mailbox terechtkomen!";
            return View();
        }
    }
}
