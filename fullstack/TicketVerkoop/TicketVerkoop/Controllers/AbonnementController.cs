using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketModels.Entities;
using TicketService.interfaces;
using TicketVerkoop.Extensions;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class AbonnementController : Controller
    {
        private SeizoenIService<Seizoen> _seizoenService;
        private PloegIService<Ploeg> _ploegService;
        private VakIService<Vak> _vakService;
        private AbbonementIService<Abbonement> _abbonementService;
        private readonly IMapper _mapper;

        public AbonnementController(SeizoenIService<Seizoen> seizoenService, IMapper mapper, PloegIService<Ploeg> ploegService, VakIService<Vak> vakService, AbbonementIService<Abbonement> abbonementService)
        {
            _seizoenService = seizoenService;
            _ploegService = ploegService;
            _vakService = vakService;
            _abbonementService = abbonementService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _ploegService.GetAll();
            List<PloegVM> listVM = _mapper.Map<List<PloegVM>>(list);

            ViewBag.lstPloegen = new SelectList(await _ploegService.GetAll(), "PloegId", "PloegNaam");

            return View(listVM);
        }


        public async Task<IActionResult> Select(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ploeg = await _ploegService.FindById(Convert.ToInt32(id));

            ViewBag.lstVakken = new SelectList(await _vakService.GetAll(Convert.ToInt16(ploeg.StadionId)), "VakId", "VakNaam");
            ViewBag.lstSeizoenen = new SelectList(await _seizoenService.GetAll(), "SeizoenId", "BeginDatum");

            ReserveringVM reservering = new ReserveringVM
            {
                Thuisploeg = ploeg.PloegNaam,
                Stadion = ploeg.Stadion.StadionNaam,
                Aantal = 0,
                Type = "Abbo",
                Cancelled = false,
            };

            return View(reservering);
        }

        [HttpPost]
        public async Task<IActionResult> Select(ReserveringVM reservering, int vakID, int seizoenID)
        {
            if(vakID == null)
            {
                return NotFound();
            }

            if (seizoenID == null)
            {
                return NotFound();
            }

            if (reservering == null)
            {
                return NotFound();
            }

            var vak = await _vakService.FindById(vakID);
            VakVM vakVM = _mapper.Map<VakVM>(vak);

            var seizoen = await _seizoenService.FindById(seizoenID);

            var ploeg = await _ploegService.FindByName(reservering.Thuisploeg);

            var abbo = await _abbonementService.FindById(ploeg.PloegId, seizoen.SeizoenId);

            CartVM item = new CartVM
            {
                Thuisploeg = reservering.Thuisploeg,
                Uitploeg = "geen uitploeg",
                Datum = DateTime.Now,
                DateCreated = DateTime.Now,
                Stadion = reservering.Stadion,
                Aantal = 1,
                Vaknaam = vakVM.VakNaam,
                Prijs = vakVM.Prijs * 4,
                Type = "Abbo",
                Cancelled = false,
                VakId = vakID,
                Abbonnement = abbo.AbbonementId,
                UserId = null
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
