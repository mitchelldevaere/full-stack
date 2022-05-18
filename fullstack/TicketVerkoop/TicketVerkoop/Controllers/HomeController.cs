using AutoMapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TicketService.interfaces;
using TicketVerkoop.Models;
using TicketVerkoop.Util.Mail;
using TicketVerkoop.Util.PDF.Interface;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSend _sender;
        private readonly IReportService _reportService;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IEmailSend sender, IReportService reportService, IStringLocalizer<HomeController> localizer)
        {
            _sender = sender;
            _reportService = reportService;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactVM contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var pdfFile = _reportService.GeneratePDFReport();

                    _sender.SendEmailAsync(contact.email, contact.subject, contact.message, null);
                    return View("Thanks", contact);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());

                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult SetAppLanguage(string lang, string returnUrl)
        {
            // er wordt een cookie aangemaakt met de naam .AspNetCore.Culture (zie browser cookie)
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(lang)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}