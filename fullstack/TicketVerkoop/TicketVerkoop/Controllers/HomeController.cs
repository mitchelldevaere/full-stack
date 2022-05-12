using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using TicketService.interfaces;
using TicketVerkoop.Models;
using TicketVerkoop.Util.Mail;
using TicketVerkoop.ViewModels;

namespace TicketVerkoop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSend _sender;

        public HomeController(IEmailSend sender)
        {
            _sender = sender;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Contact()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Contact(ContactVM contact)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _sender.SendEmailAsync(contact.email, contact.subject, contact.message, null);
        //            return View("Thanks", contact);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.ToString());

        //        }
        //    }
        //    return View();
        //}
    }
}