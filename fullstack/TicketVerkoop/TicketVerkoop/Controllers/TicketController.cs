using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketModels.Entities;
using TicketService.interfaces;
using TicketVerkoop.Extensions;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class TicketController : Controller
    {
        private IService<Match> _matchService;
        private VakIService<Vak> _vakService;
        private readonly IMapper _mapper;

        public TicketController(IMapper mapper, IService<Match> matchservice, VakIService<Vak> vakService)
        {
            _mapper = mapper;
            _matchService = matchservice;
            _vakService = vakService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _matchService.GetAll();
            List<MatchVM> listVM = _mapper.Map<List<MatchVM>>(list);
            return View(listVM);
        }

        public async Task<IActionResult> Select(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _matchService.FindById(Convert.ToInt16(id));
            MatchVM matchVM = _mapper.Map<MatchVM>(match);

            var list = await _vakService.GetAll(Convert.ToInt16(match.StadionId));
            List<VakVM> listVM = _mapper.Map<List<VakVM>>(list);

            ViewBag.lstVakken = new SelectList(await _vakService.GetAll(Convert.ToInt16(match.StadionId)), "VakId", "VakNaam");

            ReserveringVM reservering = new ReserveringVM
            {
                Thuisploeg = matchVM.ThuisploegNaam,
                Uitploeg = matchVM.UitploegNaam,
                Datum = matchVM.Datum,
                Stadion = matchVM.StadionNaam,
                Aantal = 0,
                Vaknaam = null
            };

            return View(reservering);
        }

        [HttpPost]
        public async Task<IActionResult> Select(ReserveringVM reservering, int vakID)
        {
            if(vakID == null)
            {
                return NotFound();
            }

            if (reservering == null)
            {
                return NotFound();
            }

            var vak = await _vakService.FindById(vakID);
            VakVM vakVM = _mapper.Map<VakVM>(vak);

            CartVM item = new CartVM
            {
                Thuisploeg = reservering.Thuisploeg,
                Uitploeg = reservering.Uitploeg,
                Datum = reservering.Datum,
                DateCreated = DateTime.Now,
                Stadion = reservering.Stadion,
                Aantal = reservering.Aantal,
                Vaknaam = vakVM.VakNaam,
                Prijs = vakVM.Prijs
            };

            ShoppingCartVM? shopping;

            if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
            {
                shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
            }
            else
            {
                shopping = new ShoppingCartVM();
                shopping.Cart = new List<CartVM>();
            }
            shopping.Cart.Add(item);
            HttpContext.Session.SetObjects("ShoppingCart", shopping);

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
