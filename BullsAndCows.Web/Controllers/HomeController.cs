using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BullsAndCows.Web.Models;

namespace BullsAndCows.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult TakeGuess(Guess guess)
        {
            var results = new[] {Guid.NewGuid().ToString(), Guid.NewGuid().ToString()};

            return PartialView("_PastGuesses", results);
        }
    }
}