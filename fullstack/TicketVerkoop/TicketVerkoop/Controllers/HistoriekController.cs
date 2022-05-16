using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketModels.Entities;
using TicketService.interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class HistoriekController : Controller
    {
        private ReserveringIService<Reservering> _reserveringhService;
        private UserIService<AspNetUser> _userService;
        private VakIService<Vak> _VakService;
        private readonly IMapper _mapper;

        public HistoriekController(ReserveringIService<Reservering> reserveringhService, IMapper mapper, UserIService<AspNetUser> userService, VakIService<Vak> VakService)
        {
            _reserveringhService = reserveringhService;
            _userService = userService;
            _VakService = VakService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = await _reserveringhService.GetAll(User.Identity.Name);
            List<ReserveringVM> listVM = _mapper.Map<List<ReserveringVM>>(list);

            return View(listVM);
        }

        public async Task<IActionResult> Select (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var reservering = await _reserveringhService.FindById(Convert.ToInt32(id));

            var vak = await _VakService.FindById(Convert.ToInt32(reservering.VakId));
            vak.MaxPlaatsen = vak.MaxPlaatsen + 1;
            await _VakService.Update(vak);

            reservering.Cancelled = true;
            await _reserveringhService.Update(reservering);

            var list = await _reserveringhService.GetAll(User.Identity.Name);
            List<ReserveringVM> listVM = _mapper.Map<List<ReserveringVM>>(list);

            return View("Index", listVM);
        }
    }
}
