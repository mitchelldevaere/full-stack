using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketModels.Entities;
using TicketService.interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class TicketController : Controller
    {
        private IService<Match> _matchService;
        private readonly IMapper _mapper;

        public TicketController(IMapper mapper, IService<Match> matchservice)
        {
            _mapper = mapper;
            _matchService = matchservice;
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

            ReserveringVM reservering = new ReserveringVM
            {
                Thuisploeg = matchVM.ThuisploegNaam,
                Uitploeg = matchVM.UitploegNaam,
                Datum = matchVM.Datum,
                Stadion = matchVM.StadionNaam,
                Aantal = 0
            };

            return View(reservering);
        }
    }
}
