using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketModels.Entities;
using TicketService.interfaces;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class PloegController : Controller
    {
        private PloegIService<Ploeg> _ploegService;
        private readonly IMapper _mapper;

        public PloegController(IMapper mapper, PloegIService<Ploeg> ploegService)
        {
            _ploegService = ploegService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _ploegService.GetAll();
            List<PloegVM> listVM = _mapper.Map<List<PloegVM>>(list);

            return View(listVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ploeg = await _ploegService.FindById(id);
            PloegVM plogVM = _mapper.Map<PloegVM>(ploeg);

            return View(plogVM);
        }
    }
}
